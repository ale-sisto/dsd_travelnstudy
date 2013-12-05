using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Core;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace StudyAbroad.Test
{
    [TestClass]
    public class CityFreebase_Test
    {

        //[TestMethod]
        //public void ZagrebDescription()
        //{
        //    Country loc = new Country("", "Croatia", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Zagreb", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    string uri = "https://www.googleapis.com/freebase/v1/text/m/0fh_7";
        //    var searchClient = new RestClient { BaseUrl = uri };
        //    var request = new RestRequest(Method.GET);
        //    request.RequestFormat = DataFormat.Json;
        //    string cityJson = searchClient.Get(request).Content;

        //    Assert.AreEqual(GetDescriptionFromJson(cityJson),city.Description);
        //}

        //[TestMethod]
        //public void ZagrebDescriptionLink()
        //{
        //    Country loc = new Country("", "Croatia", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Zagreb", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("55906", city.FullDescriptionURL);
        //}

        //[TestMethod]
        //public void BerlinDescription()
        //{
        //    Country loc = new Country("", "Germany", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Berlin", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    string uri = "https://www.googleapis.com/freebase/v1/text/m/01570";
        //    var searchClient = new RestClient { BaseUrl = uri };
        //    var request = new RestRequest(Method.GET);
        //    request.RequestFormat = DataFormat.Json;
        //    string cityJson = searchClient.Get(request).Content;

        //    Assert.AreEqual(GetDescriptionFromJson(cityJson), city.Description);
        //}

        //[TestMethod]
        //public void SaoPauloDescription()
        //{
        //    Country loc = new Country("", "Brasil", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Sao Paulo", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    string uri = "https://www.googleapis.com/freebase/v1/text/m/022pfy";
        //    var searchClient = new RestClient { BaseUrl = uri };
        //    var request = new RestRequest(Method.GET);
        //    request.RequestFormat = DataFormat.Json;
        //    string cityJson = searchClient.Get(request).Content;

        //    Assert.AreEqual(GetDescriptionFromJson(cityJson), city.Description);
        //}

        //[TestMethod]
        //public void ZagrebArea()
        //{
        //    Country loc = new Country("", "Croatia", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Zagreb", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("641", city.Area);
        //}

        //[TestMethod]
        //public void BerlinArea()
        //{
        //    Country loc = new Country("", "Germany", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Berlin", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("891.64", city.Area);
        //}

        //[TestMethod]
        //public void VientianeArea_NoData()
        //{
        //    Country loc = new Country("", "Laos", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Vientiane", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("Not Found", city.Area);
        //}

        //[TestMethod]
        //public void ZagrebCoordinates()
        //{
        //    Country loc = new Country("", "Croatia", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Zagreb", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("45.8167", city.Latitude);
        //    Assert.AreEqual("15.9833", city.Longitude);
        //}


        //[TestMethod]
        //public void SaoPauloCoordinates()
        //{
        //    Country loc = new Country("", "Brasil", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Sao Paulo", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("-23.5", city.Latitude);
        //    Assert.AreEqual("-46.6166666667", city.Longitude);
        //}
        
        //[TestMethod]
        //public void CambridgeCoordinates()
        //{
        //    Country loc = new Country("", "United Kingdom", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Cambridge", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("52.21", city.Latitude);
        //    Assert.AreEqual("0.13", city.Longitude);
        //}

        //[TestMethod]
        //public void ZagrebPopulation()
        //{
        //    Country loc = new Country("", "Croatia", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Zagreb", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("786200", city.Population);
        //}

        //[TestMethod]
        //public void BerlinPopulation()
        //{
        //    Country loc = new Country("", "Germany", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Berlin", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("3515473", city.Population);
        //}
        
        //[TestMethod]
        //public void CambridgePopulation()
        //{
        //    Country loc = new Country("", "United Kingdom", null);
        //    StudyAbroad.DomainModel.Core.City city = new CityWorld("Cambridge", loc);
        //    StudyAbroad.DynamicLoading.Core.FreebaseCityLoader cfb = new FreebaseCityLoader();
        //    cfb.Load(city);

        //    Assert.AreEqual("123900", city.Population);
        //}
        
        //private static string GetDescriptionFromJson(string jsonString)
        //{
        //    JObject o = JObject.Parse(jsonString);
        //    return (string)o["result"];
        //}
    }
}
