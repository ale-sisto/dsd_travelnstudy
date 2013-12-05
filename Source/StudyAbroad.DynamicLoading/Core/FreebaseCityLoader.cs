using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DynamicLoading.Framework;
using StudyAbroad.DynamicLoading.ApiUtilities;

namespace StudyAbroad.DynamicLoading.Core
{
    public class FreebaseCityLoader : Loader<City>
    {
        private const string NOT_REPORTED = "Not reported";
        private const int NO_VALUE = -1000;

        private ParameterCollection _readParameters;

        public FreebaseCityLoader(LoaderConfiguration inConfiguration)
            : base(inConfiguration)
        {
            FreebaseClient.InitiateMqlObject(Configuration.GetParameter("Mid"), Configuration.GetParameter("Type"));
            _readParameters = new ParameterCollection();
        }

        public override void Load(List<City> items)
        {
            throw new Exception("No loading of cities is implemented from the Freebase data source.");
        }

        public override void Update(City obj, ParameterCollection parameters)
        {
            if (parameters.HasParameter(CityParameters.ShortDescription))
            {
                GetShortDescription(obj);
                _readParameters.AddParameter(CityParameters.ShortDescription);
            }

            if (parameters.HasParameter(CityParameters.Description) || parameters.HasParameter(CityParameters.WikipediaUri))
            {
                //initiate the article object
                dynamic articleObj = new ExpandoObject();
                articleObj.id = null;
                articleObj.source_uri = null;
                articleObj.limit = 1;
                articleObj.optional = true;

                //assign query parameters
                if (parameters.HasParameter(CityParameters.Description))
                    _readParameters.AddParameter(CityParameters.Description);
                if (parameters.HasParameter(CityParameters.WikipediaUri))
                    _readParameters.AddParameter(CityParameters.WikipediaUri);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/common/topic/article", articleObj));
            }

            if (parameters.HasParameter(CityParameters.ImageURL))
            {
                //initiate the image object
                dynamic imageObj = new ExpandoObject();
                imageObj.id = null;
                imageObj.limit = 1;
                imageObj.optional = true;

                _readParameters.AddParameter(CityParameters.ImageURL);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/common/topic/image", imageObj));
            }

            if (parameters.HasParameter(CityParameters.Area))
            {
                //initiate the area object
                dynamic areaObj = new ExpandoObject();
                areaObj.value = null;
                areaObj.optional = true;

                _readParameters.AddParameter(CityParameters.Area);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/location/location/area", areaObj));
            }

            if (parameters.HasParameter(CityParameters.Population))
            {

                //initiate the population object
                dynamic populationObj = new ExpandoObject();
                populationObj.number = null;
                populationObj.year = null;
                //populationObj.sort = "-year";
                //populationObj.optional = true;

                //FreebaseClient.ActiveQuery.population = new object[] { populationObj };
                //FreebaseClient.QueryPropertiesCount++;

                _readParameters.AddParameter(CityParameters.Population);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/location/statistical_region/population", new object[] { populationObj }));
                //ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/location/statistical_region/population", populationObj));
            }

            if (parameters.HasParameter(CityParameters.Geolocation))
            {
                //initiate the geolocation object
                dynamic geolocationObj = new ExpandoObject();
                geolocationObj.latitude = null;
                geolocationObj.longitude = null;
                geolocationObj.optional = true;

                _readParameters.AddParameter(CityParameters.Geolocation);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/location/location/geolocation", geolocationObj));
            }

            if (parameters.HasParameter(CityParameters.Climate))
            {
                dynamic climateObj = new ExpandoObject();
                climateObj.month = null;
                climateObj.average_max_temp_c = null;
                climateObj.average_min_temp_c = null;
                climateObj.average_rainfall_mm = null;
                climateObj.optional = true;

                _readParameters.AddParameter(CityParameters.Climate);
                ExecuteActiveQuery(obj,
                                   FreebaseClient.AddMqlProperty("/travel/travel_destination/climate",
                                                                 new object[] { climateObj }));
            }

            if (parameters.HasParameter(CityParameters.TouristAttractions))
            {
                //initiate the geolocation object
                dynamic geolocationObj = new ExpandoObject();
                geolocationObj.latitude = null;
                geolocationObj.longitude = null;
                geolocationObj.optional = true;

                dynamic touristObj = new ExpandoObject();
                touristObj.name = null;
                (touristObj as IDictionary<String, Object>).Add("/common/topic/official_website", null);
                (touristObj as IDictionary<String, Object>).Add("/location/location/geolocation", geolocationObj);
                touristObj.optional = true;

                _readParameters.AddParameter(CityParameters.TouristAttractions);
                ExecuteActiveQuery(obj,
                                   FreebaseClient.AddMqlProperty("/travel/travel_destination/tourist_attractions",
                                                                 new object[] { touristObj }));
            }
            ExecuteActiveQuery(obj, true);
        }

        private void ParseQueryResult(City obj, dynamic result)
        {
            if (_readParameters.HasParameter(CityParameters.Description))
                GetDescription(result, obj);
            if (_readParameters.HasParameter(CityParameters.WikipediaUri))
                GetWikipediaUri(result, obj);
            if (_readParameters.HasParameter(CityParameters.ImageURL))
                GetImageURL(result, obj);
            if (_readParameters.HasParameter(CityParameters.Area))
                GetArea(result, obj);
            if (_readParameters.HasParameter(CityParameters.Geolocation))
                GetGeoLocation(result, obj);
            if (_readParameters.HasParameter(CityParameters.Population))
                GetPopulation(result, obj);
            if (_readParameters.HasParameter(CityParameters.Climate))
                GetClimate(result, obj);
            if (_readParameters.HasParameter(CityParameters.TouristAttractions))
                GetTouristAttractions(result, obj);

            _readParameters = new ParameterCollection();
        }



        private void ExecuteActiveQuery(City obj, bool execute)
        {
            if (execute)
            {
                var response = FreebaseClient.MqlRead();
                ParseQueryResult(obj, response.ObjectResult);
                FreebaseClient.InitiateMqlObject(Configuration.GetParameter("Mid"), Configuration.GetParameter("Type"));
                _readParameters = new ParameterCollection();
            }
        }

        private void GetDescription(dynamic objRes, City obj)
        {
            try
            {
                //get article identifier
                var descriptionLink = (string)objRes.result["/common/topic/article"].id;
                //read article
                var descriptionObj = FreebaseClient.MqlText(descriptionLink, "html").ObjectResult;
                obj.Info.Description = (string)descriptionObj.result;
            }
            catch
            {
                obj.Info.Description = NOT_REPORTED;
            }
        }

        private void GetShortDescription(City obj)
        {
            try
            {
                var response = FreebaseClient.MqlText(Configuration.GetParameter("Mid"), "plain", 200);
                obj.Info.Description = response.ObjectResult.result;
            }
            catch
            {
                obj.Info.Description = NOT_REPORTED;
            }
        }

        private void GetWikipediaUri(dynamic objRes, City obj)
        {
            try
            {
                //get full article uri<
                string sourceUri = objRes.result["/common/topic/article"].source_uri;

                var articleNum = sourceUri.Split('/').LastOrDefault();
                obj.Info.FullDescriptionURL = Resources.Content.Uris.Wiki + articleNum;
            }
            catch
            {
                obj.Info.FullDescriptionURL = NOT_REPORTED;
            }
        }

        private void GetImageURL(dynamic objRes, City obj)
        {
            try
            {
                var imageLink = (string)objRes.result["/common/topic/image"].id;
                obj.Info.ImageURL = Resources.Content.Uris.FreebaseRawImage + imageLink + "?maxheight=0" + "&maxwidth=0";
            }
            catch
            {
                obj.Info.ImageURL = "No image";
            }
        }

        private void GetPopulation(dynamic objRes, City obj)
        {
            try
            {
                obj.Info.Population = new SortedList<string, int>();
                foreach (dynamic population in objRes.result["/location/statistical_region/population"])
                {
                    try
                    {
                        int number = population.number;
                        obj.Info.Population.Add(population.year, (int)population.number);
                    }
                    catch
                    {

                    }
                }
                Convert.ToString(objRes.result["/location/statistical_region/population"].number);
            }
            catch
            {

            }
        }

        private void GetArea(dynamic objRes, City inCity)
        {
            try { inCity.Info.Area = Convert.ToString(objRes.result["/location/location/area"].value); }
            catch { inCity.Info.Area = NOT_REPORTED; }
        }

        private void GetGeoLocation(dynamic objRes, City inCity)
        {
            try
            {
                inCity.Info.Latitude = Convert.ToString(objRes.result["/location/location/geolocation"].latitude);
                inCity.Info.Longitude = Convert.ToString(objRes.result["/location/location/geolocation"].longitude);
            }
            catch
            {
                inCity.Info.Latitude = NOT_REPORTED;
                inCity.Info.Longitude = NOT_REPORTED;
            }
        }

        private void GetClimate(dynamic objRes, City obj)
        {
            obj.Info.Climate = new List<ClimateData>();
            try
            {
                foreach (var climateData in objRes.result["/travel/travel_destination/climate"])
                {
                    string month;
                    decimal minTemp, maxTemp, rainfall;

                    try { month = climateData.month; }
                    catch { month = NOT_REPORTED; }
                    try { minTemp = climateData.average_min_temp_c; }
                    catch { minTemp = NO_VALUE; }
                    try { maxTemp = climateData.average_max_temp_c; }
                    catch { maxTemp = NO_VALUE; }
                    try { rainfall = climateData.average_rainfall_mm; }
                    catch { rainfall = NO_VALUE; }

                    obj.Info.Climate.Add(new ClimateData(month, minTemp, maxTemp, rainfall));
                }
            }
            catch
            {
            }
        }

        private void GetTouristAttractions(dynamic objRes, City obj)
        {
            obj.Info.TouristAttractions = new List<TouristAttraction>();
            string name, website;
            decimal latitude, longitude;

            try
            {
                foreach (var attraction in objRes.result["/travel/travel_destination/tourist_attractions"])
                {
                    name = attraction.name;
                    try{website = attraction["/common/topic/official_website"];}
                    catch{website = NOT_REPORTED;}
                    if (website == null)
                        website = NOT_REPORTED;

                    try
                    {
                        latitude = (decimal) attraction["/location/location/geolocation"].latitude;
                        longitude = (decimal) attraction["/location/location/geolocation"].longitude;
                    }
                    catch
                    {
                        latitude = longitude = NO_VALUE;
                    }

                    obj.Info.TouristAttractions.Add(new TouristAttraction(name, website, longitude, latitude));
                }
            }
            catch
            {

            }
        }

    }
}
