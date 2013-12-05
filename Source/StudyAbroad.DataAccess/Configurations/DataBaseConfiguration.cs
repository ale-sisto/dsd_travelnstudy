using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DomainModel.Mapping.MappingDiscriminator;
using System.Linq;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DataAccess.Configurations
{
    public class DataBaseConfiguration
    {
        //This is connected to the TEST joint database on the VM server (not the live one so dont worry)
        //Dont change this to anything but your local database conn string and change it back when you commit to SVN
        private static readonly string CONN_STRING = Resources.Content.ConnStrings.BranimirDefault;
        //public static ISessionFactory SessionFactory { get; private set; }

        //private static ISession _session;

        //public static ISession Session
        //{
        //    get
        //    {
        //        if (_session == null || !_session.IsOpen)
        //            _session = SessionFactory.OpenSession();
        //        return _session;
        //    }
        //}

        public static void CreateDatabase()
        {
            Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(CONN_STRING))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(CreateSchema)
                .BuildConfiguration();
        }

        public static void UpdateDatabase()
        {
            Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(CONN_STRING))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(UpdateSchema)
                .BuildConfiguration();
        }

        public static void CreateSchema(NHibernate.Cfg.Configuration cfg)
        {
            var schema = new SchemaExport(cfg);
            schema.Drop(false, true);
            schema.Create(false, true);
        }

        public static void UpdateSchema(NHibernate.Cfg.Configuration cfg)
        {
            var update = new SchemaUpdate(cfg);
            update.Execute(false, true);
        }

        //public static void CreateFactory()
        //{
        //    SessionFactory = Fluently.Configure()
        //        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(CONN_STRING))
        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
        //        .BuildSessionFactory();
        //}

        public static void Initialize(bool reCreateSchema = false, bool setInitData = false)
        {
            if (reCreateSchema)
                CreateDatabase();
            else
                setInitData = false;

            if (setInitData)
            {
                InitializeLocations();
                RegisterTopWorld();
                RegisterTopContinent();
                RegisterTopCountry();
                RegisterTopState();
                RegisterUniversitiesCountry();
                RegisterUniversitiesState();
            }
        }

        private static void InitializeLocations()
        {
            var localReader = new Core.LocalDataAccess();
            var world = localReader.GetWorldLocal();
            var continents = localReader.GetContinentsLocal();
            var regions = localReader.GetRegionsLocal();
            var countries = localReader.GetCountriesLocal();
            var states = localReader.GetStatesLocal();

            new Framework.DataAccessORM<Location>().Create(world);
            new Framework.DataAccessORM<Continent>().CreateMany(continents);
            new Framework.DataAccessORM<Region>().CreateMany(regions);
            new Framework.DataAccessORM<Country>().CreateMany(countries);
            new Framework.DataAccessORM<State>().CreateMany(states);
        }

        private static void RegisterTopWorld()
        {
            var dal = new Framework.DataAccessORM<Location>();

            var world = dal.FilterFirst(l => l.Name == "World");
            world.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                     Resources.Content.Uris.IcuTopWorld);
            dal.Update(world);
        }

        private static void RegisterTopContinent()
        {
            var dal = new Framework.DataAccessORM<Continent>();

            var africa = dal.FilterFirst(c => c.Name == "Africa");
            var europe = dal.FilterFirst(c => c.Name == "Europe");
            var asia = dal.FilterFirst(c => c.Name == "Asia");
            var oceania = dal.FilterFirst(c => c.Name == "Oceania");
            var americas = dal.FilterFirst(c => c.Name == "Americas");

            africa.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                      Resources.Content.Uris.IcuTopAfrica);
            europe.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                      Resources.Content.Uris.IcuTopEurope);
            asia.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                    Resources.Content.Uris.IcuTopAsia);
            oceania.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                       Resources.Content.Uris.IcuTopOceania);
            americas.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                        Resources.Content.Uris.IcuTopNAmerica);
            americas.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities,
                                        Resources.Content.Uris.IcuTopSAmerica);

            dal.Update(africa);
            dal.Update(europe);
            dal.Update(asia);
            dal.Update(oceania);
            dal.Update(americas);
        }

        private static void RegisterTopCountry()
        {
            var dal = new Framework.DataAccessORM<Country>();

            var countries = dal.ReadAll();
            foreach (var country in countries)
            {
                var codeSufix = country.Code.ToLower() + "/";
                var url = Resources.Content.Uris.IcuBase + codeSufix;
                country.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities, url);
            }

            dal.UpdateMany(countries);
        }

        private static void RegisterTopState()
        {
            var dal = new Framework.DataAccessORM<State>();

            var states = dal.ReadAll();
            foreach (var state in states)
            {
                var countryPreffix = "us/";
                var htmSuffix = ".htm";
                var stateName = state.Name.Replace(' ', '-');
                var url = Resources.Content.Uris.IcuBase + countryPreffix + stateName + htmSuffix;
                state.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities, url);
            }

            dal.UpdateMany(states);
        }


        private static void RegisterUniversitiesCountry()
        {
            var dalCountry = new Framework.DataAccessORM<Country>();
            var dalState = new Framework.DataAccessORM<State>();
            var dalUni = new Framework.DataAccessORM<University>();
            var dalCity = new Framework.DataAccessORM<City>();

            var countries = dalCountry.ReadAll();
            while (countries.Count > 0)
            {
                var tempFailed = new List<Country>();
                Parallel.ForEach(countries, country =>
                                                {
                                                    if (country.Code == "US")
                                                        return;
                                                    var unis = new List<University>();
                                                    try
                                                    {
                                                        DynamicLoading.Factories.LoaderFactory.IcuOrg().Loaders().
                                                            University().TopCountry(country).
                                                            Load(
                                                                unis);
                                                        //Parallel.ForEach(unis, uni =>
                                                        //{
                                                        //    var city =
                                                        //        dalCity.FilterFirst(c => c.Name == uni.Info.CityName);
                                                        //    if (city == null)
                                                        //    {
                                                        //        city = new CityWorld(uni.Info.CityName, country);
                                                        //        dalCity.Create(city);
                                                        //    }
                                                        //    uni.City = city;
                                                        //    DynamicLoading.Factories.LoaderFactory.IcuOrg().Updaters().University().Info(uni).UpdateFull(uni);
                                                        //});
                                                        var unisCities =
                                                            unis.GroupBy(u => u.Info.CityName).ToDictionary(g => g.Key, g => g.ToList());
                                                        Parallel.ForEach(unisCities, unisCity =>
                                                        {
                                                            var city = new CityWorld(unisCity.Key, country);
                                                            dalCity.Create(city);
                                                            var tempUnis = unisCity.Value;
                                                            while (tempUnis.Count > 0)
                                                            {
                                                                var unisNotLoaded = new List<University>();
                                                                Parallel.ForEach(tempUnis, uni =>
                                                                {
                                                                    try
                                                                    {
                                                                        DynamicLoading.Factories.LoaderFactory.IcuOrg().Updaters().University().Info(uni).Update(uni, null);
                                                                        if (uni.Info.GlobalRank == 0)
                                                                            throw new Exception("Cannot load webpage");
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        if (e.Message == "Cannot load webpage")
                                                                        {
                                                                            unisNotLoaded.Add(uni);
                                                                            return;
                                                                        }
                                                                        throw;
                                                                    }
                                                                    uni.City = city;
                                                                });
                                                                tempUnis = unisNotLoaded;
                                                            }                              
                                                        });
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        if (e.Message == "Cannot load webpage")
                                                        {
                                                            tempFailed.Add(country);
                                                            return;
                                                        }
                                                        if (e.Message !=
                                                            "Uri does not lead to university list! Check URI")
                                                            throw;
                                                    }
                                                    dalUni.CreateMany(unis);
                                                });
                countries = tempFailed;
            }

        }

        private static void RegisterUniversitiesState()
        {
            var dalState = new Framework.DataAccessORM<State>();
            var dalUni = new Framework.DataAccessORM<University>();
            var dalCity = new Framework.DataAccessORM<City>();

            var states = dalState.ReadAll();
            while (states.Count > 0)
            {
                var tempFailed = new List<State>();
                Parallel.ForEach(states, state =>
                {
                    var unis = new List<University>();
                    try
                    {
                        DynamicLoading.Factories.LoaderFactory.IcuOrg().Loaders().
                            University().TopState(state).
                            Load(
                                unis);

                        var unisCities =
                            unis.GroupBy(u => u.Info.CityName).ToDictionary(g => g.Key, g => g.ToList());
                        Parallel.ForEach(unisCities, unisCity =>
                        {
                            var city = new CityUSA(unisCity.Key, state);
                            dalCity.Create(city);
                            var tempUnis = unisCity.Value;
                            while (tempUnis.Count > 0)
                            {
                                var unisNotLoaded = new List<University>();
                                Parallel.ForEach(tempUnis, uni =>
                                {
                                    try
                                    {
                                        DynamicLoading.Factories.LoaderFactory.IcuOrg().Updaters().University().Info(uni).Update(uni, null);
                                        if (uni.Info.GlobalRank == 0)
                                            throw new Exception("Cannot load webpage");
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message == "Cannot load webpage")
                                        {
                                            unisNotLoaded.Add(uni);
                                            return;
                                        }
                                        throw;
                                    }
                                    uni.City = city;
                                });
                                tempUnis = unisNotLoaded;
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        if (e.Message == "Cannot load webpage")
                        {
                            tempFailed.Add(state);
                            return;
                        }
                        if (e.Message !=
                            "Uri does not lead to university list! Check URI")
                            throw;
                    }
                    dalUni.CreateMany(unis);
                });
                states = tempFailed;
            }

        }
    }
}
