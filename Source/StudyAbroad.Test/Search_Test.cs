using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.BusinessLogic.SearchEngine;

namespace StudyAbroad.Test
{
    [TestClass]
    public class Search_Test
    {
        [TestMethod]
        public void SearchCount()
        {

            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Zagreb", 25);
            List<SearchResult> toBig = BLLFactory.SearchEngine().SearchLocation("Zagreb", 100);
            List<SearchResult> ten = BLLFactory.SearchEngine().SearchLocation("Zagreb");
            Assert.AreEqual(results.Count,25);
            Assert.AreNotSame(toBig.Count, 100);
            Assert.IsNotNull(toBig);
            Assert.AreEqual(ten.Count,10);
        }

        [TestMethod]
        public void SerchZagreb()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Zagreb");
            bool city=false;
            bool university=false;
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Zagreb"))
            {
                city = true;
            }
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Sveucilište u Zagrebu"))
            {
                university = true;
            }
            Assert.IsTrue(city);
            Assert.IsTrue(university);
        }

        [TestMethod]
        public void SerchSveucilisteUZagrebu()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Sveuciliste u Zagreb");
            bool city = false;
            bool university = false;
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Sveucilište u Zagrebu"))
            {
                university = true;
            }
            Assert.IsTrue(university);
        }

        [TestMethod]
        public void SerchMilano()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Milan");
            bool city = false;
            bool university = false;
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Milano"))
            {
                city = true;
            }
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Politecnico di Milano"))
            {
                university = true;
            }
            Assert.IsTrue(city);
            Assert.IsTrue(university);
        }

        [TestMethod]
        public void SerchVasteras()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Vasteras");
            bool city = false;
            bool university = false;
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Västerås"))
            {
                city = true;
            }

            Assert.IsTrue(city);

        }

        [TestMethod]
        public void SerchMalardalens()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Malardalens");
            bool city = false;
            bool university = false;

            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Mälardalens högskola"))
            {
                university = true;
            }
            Assert.IsTrue(university);
        }

        [TestMethod]
        public void SerchGotland()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Gotland");
            bool city = false;
            bool university = false;

            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Högskolan på Gotland"))
            {
                university = true;
            }
            Assert.IsTrue(university);
        }

        [TestMethod]
        public void SerchGoteborg()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Göteborg");
            bool city = false;
            bool university = false;
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Göteborg"))
            {
                city = true;
            }

            Assert.IsTrue(city);

        }

        [TestMethod]
        public void SerchWesternAustralia()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("western Australia");
            bool university = false;

            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "The University of Western Australia"))
            {
                university = true;
            }

            Assert.IsTrue(university);

        }

        [TestMethod]
        public void SerchNorthRockhampton()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("NorthRockhampton");
            bool city = false;
            bool university = false;
            foreach (
                SearchResult searchResult in
                    results.Where(searchResult => searchResult.Location.Name == "North Rockhampton"))
            {
                city = true;
            }

            Assert.IsTrue(city);
        }

        [TestMethod]
        public void SerchNotreDameAustralia()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Notre Dame Australia");
            bool university = false;

            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "The University of Notre Dame Australia"))
            {
                university = true;
            }

            Assert.IsTrue(university);

        }

        [TestMethod]
        public void SerchStMatthewsUniversity()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("Matthew's");
            bool university = false;

            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "St. Matthew's University"))
            {
                university = true;
            }

            Assert.IsTrue(university);

        }

        [TestMethod]
        public void SerchKathmandu()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("kathmandu");
            bool city = false;
            bool university = false;
            foreach (
                SearchResult searchResult in
                    results.Where(searchResult => searchResult.Location.Name == "Kathmandu"))
            {
                city = true;
            }

            Assert.IsTrue(city);
        }

        [TestMethod]
        public void SerchTokio()
        {
            List<SearchResult> results = BLLFactory.SearchEngine().SearchLocation("tokio");
            bool city = false;
            bool university = false;

            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "Tokyo"))
            {
                city = true;
            }
            foreach (SearchResult searchResult in results.Where(searchResult => searchResult.Location.Name == "The University of Tokyo"))
            {
                university = true;
            }

            Assert.IsTrue(city);
            Assert.IsTrue(university);

        }
    }
}
 