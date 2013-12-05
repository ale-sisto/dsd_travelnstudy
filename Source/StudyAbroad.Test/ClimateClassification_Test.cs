using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.Test
{
    [TestClass]
    public class ClimateClassification_Test
    {
        private readonly List<City> _allCities = new List<City>();

        public ClimateClassification_Test()
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
        public void ZagrebClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "zagreb");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Temperate,climateCategoryEnum);
        }

        [TestMethod]
        public void MilanoClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "milano");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Temperate, climateCategoryEnum);
        }

        [TestMethod]
        public void HelsinkiClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "helsinki");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Continental, climateCategoryEnum);
        }

        [TestMethod]
        public void MoscowClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "moscow");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Polar, climateCategoryEnum);
        }

        [TestMethod]
        public void RioDeJaneiroClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "rio de janeiro");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Tropical, climateCategoryEnum);
        }

        [TestMethod]
        public void AlexandriaClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "alexandria");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Dry, climateCategoryEnum);
        }

        [TestMethod]
        public void HongKongClimate()
        {
            City city = _allCities.First(t => t.Name.Trim().ToLower() == "hong kong");
            BLLFactory.Location().City().UpdateClimateInfo(city);
            ClimateCategoryEnum climateCategoryEnum = BLLFactory.Location().City().GetClimateCategory(city);
            Assert.AreEqual(ClimateCategoryEnum.Tropical, climateCategoryEnum);
        }
    }
}
