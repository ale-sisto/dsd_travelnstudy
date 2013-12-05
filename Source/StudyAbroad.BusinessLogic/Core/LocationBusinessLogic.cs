using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DataAccess.Core;
using StudyAbroad.DomainModel;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DynamicLoading.Factories;
using StudyAbroad.DynamicLoading.Framework;
using StudyAbroad.BusinessLogic.ClimateClassification;

namespace StudyAbroad.BusinessLogic.Core
{
    public class LocationBusinessLogic : Framework.BusinessLogic<Location>
    {
        private LocationDataAccess _ormDal;

        public LocationBusinessLogic()
        {
            _ormDal = new LocationDataAccess();
        }

        public List<Location> GetAll()
        {
            return Orm.ReadAll();
        }

        public Location GetByCode(string inCode)
        {
            return _ormDal.GetByCode(inCode);
        }

        public Location GetByName(string inName)
        {
            return _ormDal.GetByName(inName);
        }

        public List<Location> GetByContainedBy(Location inContainedBy)
        {
            return _ormDal.GetByContainedBy(inContainedBy);
        }

        public Location GetWorld()
        {
            return GetByCode("world");
        }

        public CityBusinessLogic City()
        {
            return new CityBusinessLogic();
        }

        public CountryBusinessLogic Country()
        {
            return new CountryBusinessLogic();
        }

        public ContinentBusinessLogic Continent()
        {
            return new ContinentBusinessLogic();
        }

        public RegionBusinessLogic Region()
        {
            return new RegionBusinessLogic();
        }
    }

    public class CountryBusinessLogic : Framework.BusinessLogic<Country>
    {
        public List<Country> GetAll()
        {
            return Orm.ReadAll().OrderBy(c => c.Name).ToList();
        }
    }

    public class ContinentBusinessLogic : Framework.BusinessLogic<Continent>
    {
        public List<Continent> GetAll()
        {
            return Orm.ReadAll().OrderBy(c => c.Name).ToList();
        }
    }

    public class RegionBusinessLogic : Framework.BusinessLogic<Region>
    {
        public List<Region> GetAll()
        {
            return Orm.ReadAll().OrderBy(c => c.Name).ToList();
        }

        public List<Region> GetByContinentName(string inContinentName)
        {
            return Orm.FilterAll(r => r.ContainedBy.Name == inContinentName);
        }
    }

    public class CityBusinessLogic : Framework.BusinessLogic<City>
    {
        private LocationDataAccess _ormDal;

        public CityBusinessLogic()
        {
            _ormDal = new LocationDataAccess();
        }

        public City GetByCountry(string cityName, string countryName)
        {
            var possibleCities = _ormDal.GetByNameMany(cityName);
            var city = possibleCities.FirstOrDefault(c => c.ContainedBy.Name == countryName);
            if (city == null)
                throw new Exception("No city was found with that name or that country name!");
            return city.Self as City;
        }

        public void UpdateMany(List<City> inCities, bool inFullUpdate)
        {
            foreach (var city in inCities)
            {
                if (inFullUpdate)
                    UpdateFullInfo(city);
                else
                    UpdateShortInfo(city);
            }
        }

        public void UpdateInfo(City inCity, ParameterCollection inParameters)
        {
            try
            {
                Odsm.Update(LoaderFactory.Freebase().Updaters().City().Info(inCity), inCity, inParameters);
            }
            catch (Exception e)
            {
                if (e.Message == "Search returned with no results!")
                    return;
                throw;
            }
        }

        public void UpdateClimateInfo(City inCity)
        {
            UpdateClimateInfoFreebase(inCity);
            if (inCity.Info.Climate.Count == 0)
            {
                UpdateClimateInfoDataBank(inCity);
            }
            OrderClimateByMonths(inCity);
        }

        public void UpdateClimateInfoDataBank(City inCity)
        {
            Odsm.Update(LoaderFactory.DataBankClimate().Climate(), inCity, null);
        }

        public void UpdateClimateInfoFreebase(City inCity)
        {
            var pars = new ParameterCollection();
            pars.AddParameter(CityParameters.Climate);
            UpdateInfo(inCity, pars);
        }

        public void UpdateFullInfo(City inCity)
        {
            var pars = new CityParameters().GetAllProperties();
            UpdateInfo(inCity, pars);
        }

        public void UpdateShortInfo(City inCity)
        {
            var pars = new CityParameters().GetShortProperties();
            UpdateInfo(inCity, pars);
        }

        public void UpdateManyCostOfLife(List<City> inCities)
        {
            var cities = inCities.Distinct().ToList();
            foreach (var city in cities)
            {
                GetCostOfLife(city);
            }
        }

        public void GetCostOfLife(City inCity)
        {
            Odsm.Update(LoaderFactory.Numbeo().Info(), inCity, null);
        }

        //Goes through a list of cities, takes distinct ones, runs them through freebase, then fills out the ones that have no climate data with data bank data
        public void UpdateManyClimateInfo(List<City> inCities)
        {
            //Create a distinct list of cities
            var distinctCities = inCities.Distinct().ToList();
            //Use freebase to update them
            foreach (var tempCity in distinctCities)
            {
                UpdateClimateInfoFreebase(tempCity);
            }
            //Extract those that still have no data
            var noDataCities = distinctCities.Where(c => c.Info.Climate.Count == 0).ToList();

            //Make a dictionary (key, value) = (country, cities)
            var countryCities = noDataCities.GroupBy(c => c.Country()).ToDictionary(g => g.Key, g => g);

            //Go through all the countries, update 1 city, then update all the rest based on the first city in the country
            foreach (var countryCity in countryCities)
            {
                var firstCity = countryCity.Value.First();
                UpdateClimateInfoDataBank(firstCity);
                foreach (var city in countryCity.Value)
                {
                    city.Info.Climate = firstCity.Info.Climate;
                }
            }

        }

        public ClimateCategoryEnum GetClimateCategory(City inCity)
        {
            //Check if city is updated
            if (inCity.Info.Climate == null)
                UpdateClimateInfo(inCity);

            List<ClimateData> climate = inCity.Info.Climate;

            double avgTemperature = ClimateUtilities.AvgTemp(climate);
            if (avgTemperature>=18)
            {
                double avgPrecipitation = ClimateUtilities.AvgPrecip(climate);
                if (avgPrecipitation>=60)
                {
                    return ClimateCategoryEnum.Tropical;
                }
                else
                {
                    return ClimateCategoryEnum.Dry;
                }
            }

            double avgWarmMonths = ClimateUtilities.AvgWarmMonths(climate, ClimateUtilities.GetHemisphere(inCity)); 
            if (avgWarmMonths >= 10)
            {
                double avgColdMonths = ClimateUtilities.AvgColdMonths(climate, ClimateUtilities.GetHemisphere(inCity));
                if (avgColdMonths >= 0)
                {
                    return ClimateCategoryEnum.Temperate;
                }
                else
                {
                    return ClimateCategoryEnum.Continental;
                }
            }

            return ClimateCategoryEnum.Polar;
        }

        private void OrderClimateByMonths(City inCity)
        {
            if (inCity.Info.Climate == null)
            {
                return;
            }
            List<ClimateData> climateData = inCity.Info.Climate;
            List<ClimateData> orderedList = climateData.Where(data => data.Month.ToLower() == "january").ToList();
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "february"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "march"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "april"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "may"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "june"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "july"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "august"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "september"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "october"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "november"));
            orderedList.AddRange(climateData.Where(data => data.Month.ToLower() == "december"));

            inCity.Info.Climate = orderedList;

        }

    }
}
