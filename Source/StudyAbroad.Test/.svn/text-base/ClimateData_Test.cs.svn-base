using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.BusinessLogic.Factories;

namespace StudyAbroad.Test
{
    [TestClass]
    public class ClimateData_Test
    {
        private readonly List<City> _allCities = new List<City>();
         
        public ClimateData_Test()
        {
            List<Location> inLocation = BLLFactory.Location().GetAll();
            foreach (Location location in inLocation)
            {
                City city = location as City;
                if (city != null)
                {
                    _allCities.Add(city);
                }
            }
        }
        
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(_allCities);
        }

         [TestMethod]
         public void BerlinClimate()
         {
            City city= _allCities.First(t => t.Name.Trim().ToLower()=="berlin");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            List<ClimateData> climate = city.Info.Climate;
            ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
            Assert.AreEqual(2,january.AvgMaxTemp);
            Assert.AreEqual(-3,january.AvgMinTemp);
            Assert.AreEqual(43,january.AvgRainfall);
            ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
            Assert.AreEqual(23, july.AvgMaxTemp);
            Assert.AreEqual(13, july.AvgMinTemp);
            Assert.AreEqual(71, july.AvgRainfall);
            ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
            Assert.AreEqual(3, december.AvgMaxTemp);
            Assert.AreEqual(-1, december.AvgMinTemp);
            Assert.AreEqual(48, december.AvgRainfall);
         }

         [TestMethod]
         public void MilanoClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "milano");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual(4, january.AvgMaxTemp);
             Assert.AreEqual(-2, january.AvgMinTemp);
             Assert.AreEqual(61, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual(29, july.AvgMaxTemp);
             Assert.AreEqual(17, july.AvgMinTemp);
             Assert.AreEqual(68, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual(5, december.AvgMaxTemp);
             Assert.AreEqual(0, december.AvgMinTemp);
             Assert.AreEqual(75, december.AvgRainfall);
         }

         [TestMethod]
         public void ZagrebClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "zagreb");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual((Decimal)0.72193927, january.AvgMaxTemp);
             Assert.AreEqual((Decimal)0.72193927, january.AvgMinTemp);
             Assert.AreEqual((Decimal)70.846725, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual((Decimal)20.881666, july.AvgMaxTemp);
             Assert.AreEqual((Decimal)20.881666, july.AvgMinTemp);
             Assert.AreEqual((Decimal)69.86693, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual((Decimal)2.6411104, december.AvgMaxTemp);
             Assert.AreEqual((Decimal)2.6411104, december.AvgMinTemp);
             Assert.AreEqual((Decimal)98.19703, december.AvgRainfall);
         }

         [TestMethod]
         public void LondonClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "london");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual(7, january.AvgMaxTemp);
             Assert.AreEqual(2, january.AvgMinTemp);
             Assert.AreEqual(61, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual(22, july.AvgMaxTemp);
             Assert.AreEqual(14, july.AvgMinTemp);
             Assert.AreEqual(46, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual(8, december.AvgMaxTemp);
             Assert.AreEqual(3, december.AvgMinTemp);
             Assert.AreEqual(59, december.AvgRainfall);
         }

         [TestMethod]
         public void AlexandriaClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "alexandria");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual((Decimal)13.40452, january.AvgMaxTemp);
             Assert.AreEqual((Decimal)13.40452, january.AvgMinTemp);
             Assert.AreEqual((Decimal)6.145969, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual((Decimal)29.46993, july.AvgMaxTemp);
             Assert.AreEqual((Decimal)29.46993, july.AvgMinTemp);
             Assert.AreEqual((Decimal)2.7361333, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual((Decimal)14.866674, december.AvgMaxTemp);
             Assert.AreEqual((Decimal)14.866674, december.AvgMinTemp);
             Assert.AreEqual((Decimal)5.3568892, december.AvgRainfall);
         }

         [TestMethod]
         public void HongKongClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "hong kong");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual(19, january.AvgMaxTemp);
             Assert.AreEqual(14, january.AvgMinTemp);
             Assert.AreEqual(27, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual(31, july.AvgMaxTemp);
             Assert.AreEqual(27, july.AvgMinTemp);
             Assert.AreEqual(371, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual(20, december.AvgMaxTemp);
             Assert.AreEqual(15, december.AvgMinTemp);
             Assert.AreEqual(25, december.AvgRainfall);
         }

         [TestMethod]
         public void ChicagoClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "chicago");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual(-1, january.AvgMaxTemp);
             Assert.AreEqual(-9, january.AvgMinTemp);
             Assert.AreEqual(48, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual(29, july.AvgMaxTemp);
             Assert.AreEqual(19, july.AvgMinTemp);
             Assert.AreEqual(89, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual(2, december.AvgMaxTemp);
             Assert.AreEqual(-6, december.AvgMinTemp);
             Assert.AreEqual(61, december.AvgRainfall);
         }

         [TestMethod]
         public void CapeTownClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "cape town");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual((Decimal)22.96128, january.AvgMaxTemp);
             Assert.AreEqual((Decimal)22.96128, january.AvgMinTemp);
             Assert.AreEqual((Decimal)64.51735, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual((Decimal)11.2805195, july.AvgMaxTemp);
             Assert.AreEqual((Decimal)11.2805195, july.AvgMinTemp);
             Assert.AreEqual((Decimal)12.659176, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual((Decimal)22.0621, december.AvgMaxTemp);
             Assert.AreEqual((Decimal)22.0621, december.AvgMinTemp);
             Assert.AreEqual((Decimal)58.82522, december.AvgRainfall);
         }

         [TestMethod]
         public void RioDeJaneiroClimate()
         {
             City city = _allCities.First(t => t.Name.Trim().ToLower() == "rio de janeiro");
             BLLFactory.Location().City().UpdateClimateInfo(city);
             List<ClimateData> climate = city.Info.Climate;
             ClimateData january = climate.First(t => t.Month.Trim().ToLower() == "january");
             Assert.AreEqual((Decimal)25.574314, january.AvgMaxTemp);
             Assert.AreEqual((Decimal)25.574314, january.AvgMinTemp);
             Assert.AreEqual((Decimal)224.43515, january.AvgRainfall);
             ClimateData july = climate.First(t => t.Month.Trim().ToLower() == "july");
             Assert.AreEqual((Decimal)23.180391, july.AvgMaxTemp);
             Assert.AreEqual((Decimal)23.180391, july.AvgMinTemp);
             Assert.AreEqual((Decimal)67.97145, july.AvgRainfall);
             ClimateData december = climate.First(t => t.Month.Trim().ToLower() == "december");
             Assert.AreEqual((Decimal)25.618053, december.AvgMaxTemp);
             Assert.AreEqual((Decimal)25.618053, december.AvgMinTemp);
             Assert.AreEqual((Decimal)198.58363, december.AvgRainfall);
         }
    }
}
