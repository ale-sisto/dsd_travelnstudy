using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.DataAccess.Core;
using StudyAbroad.DataAccess.Framework;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.Test
{
    [TestClass]
    public class CRUD
    {
        [TestInitialize]
        public void CreateSession()
        {
            //DataBaseConfiguration.CreateDatabase();
            //DataAccess.Configurations.DataBaseConfiguration.CreateFactory();
        }


        [TestMethod]
        public void InsertUser()
        {
            DataAccessORM<User> dal = new DataAccessORM<User>();

            User user = new User("Jelena", "Krdo", "jelena", "krdoj", null);
            dal.Create(user);

            Assert.AreEqual("Jelena", dal.ReadId(user.Id).Name);

            dal.Delete(user);
            Assert.IsNull(dal.ReadId(user.Id));
        }

        [TestMethod]
        public void UpdateUser()
        {
            DataAccessORM<User> dal = new DataAccessORM<User>();

            User user = new User("Jelena", "Krdo", "jelena", "krdoj", null);
            dal.Create(user);

            User userRead = dal.ReadId(user.Id);
            userRead.Surname = "PrezimeNovo";
            dal.Update(userRead);

            Assert.AreEqual("PrezimeNovo", dal.ReadId(user.Id).Surname);

            dal.Delete(userRead);
            Assert.IsNull(dal.ReadId(user.Id));
        }

        [TestMethod]
        public void InsertLocation()
        {
            DataAccessORM<Location> dal = new DataAccessORM<Location>();

            Location location = new Location("World", null);
            dal.Create(location);

            Assert.AreEqual("World", dal.ReadId(location.Id).Name);

            dal.Delete(location);
            Assert.IsNull(dal.ReadId(location.Id));
        }

        [TestMethod]
        public void InsertCity()
        {
            DataAccessORM<Location> dal = new DataAccessORM<Location>();
            Location world = new Location("World", null);
            dal.Create(world);

            DataAccessORM<Continent> dalCont = new DataAccessORM<Continent>();
            Location continent = new Continent(null, "Europa", world);
            dal.Create(continent);

            DataAccessORM<Region> dalReg = new DataAccessORM<Region>();
            Location region = new Region(null, "East Europe", continent as Continent);
            dal.Create(region);

            DataAccessORM<Country> dalCountry = new DataAccessORM<Country>();
            Location country = new Country(null, "Croatia", region as Region);
            dal.Create(country);

            DataAccessORM<CityWorld> dalCity = new DataAccessORM<CityWorld>();
            Location city = new CityWorld("Zagreb", country as Country);
            dal.Create(city);

            Assert.IsTrue(dalCity.ReadAll().Contains(city as CityWorld));
            Assert.IsFalse(dalCity.ReadAll().Contains(continent as CityWorld));

            dal.Delete(city);
            dal.Delete(country);
            dal.Delete(region);
            dal.Delete(continent);
            dal.Delete(world);
        }
    }
}
