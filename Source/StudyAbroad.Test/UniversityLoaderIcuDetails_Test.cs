using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.BusinessLogic.Factories;

namespace StudyAbroad.Test
{
    [TestClass]
    public class UniversityLoaderIcuDetails_Test
    {
        //This project is used to test functionality of UniversityLoaderIcuDetails class.
        //That class is not finished so changes in this test class are expected
        [TestMethod]
        public void FoundationYearOxford()
        {
            var oxfordUni =
                BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("1096", oxfordUni.Info.FoundationYear);
        }

        [TestMethod]
        public void FoundationYearZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("1669", zagrebUni.Info.FoundationYear);
        }

        [TestMethod]
        public void FoundationYearPOLIMI()
        {
            var polimiUni =
                BLLFactory.University().GetTopByLocationName("Italy").Find(
                    u => u.Info.EnglishName == "Polytechnic University of Milan");
            BLLFactory.University().UpdateFullInfo(polimiUni);
            Assert.AreEqual("1863", polimiUni.Info.FoundationYear);
        }

        [TestMethod]
        public void FoundationYearWuhanUniversity()
        {
            var wuhanUni =
                BLLFactory.University().GetTopByLocationName("China").Find(u => u.Name == "Wuhan University");
            BLLFactory.University().UpdateFullInfo(wuhanUni);
            Assert.AreEqual("1893", wuhanUni.Info.FoundationYear);
        }

        [TestMethod]
        public void MottoOxford()
        {
            var oxfordUni =
                BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("The Lord is my light", oxfordUni.Info.Motto);
        }

        [TestMethod]
        public void MottoCambridge()
        {
            var cambridgeUni =
                BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Cambridge");
            BLLFactory.University().UpdateFullInfo(cambridgeUni);
            Assert.AreEqual("From here, light and sacred draughts", cambridgeUni.Info.Motto);
        }

        [TestMethod]
        public void MottoZagrebUniNoMotto()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("Not reported", zagrebUni.Info.Motto);
        }

        [TestMethod]
        public void MottoWuhanUniversity()
        {
            var wuhanUni =
                BLLFactory.University().GetTopByLocationName("China").Find(u => u.Name == "Wuhan University");
            BLLFactory.University().UpdateFullInfo(wuhanUni);
            Assert.AreEqual("Get bestirred, Develop perseverance, Aspire after truth and Blaze new trails", wuhanUni.Info.Motto);
        }

        [TestMethod]
        public void AdressOxford()
        {
            var oxfordUni =
                BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("Wellington Square Oxford OX1 2JD South East England", oxfordUni.Info.Address);
        }

        [TestMethod]
        public void AdressZagreb()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("Trg. Maršala Tita 14 Zagreb 10000 Grad Zagreb", zagrebUni.Info.Address);
        }

        [TestMethod]
        public void AdressWuhanUniversity()
        {
            var wuhanUni =
                BLLFactory.University().GetTopByLocationName("China").Find(u => u.Name == "Wuhan University");
            BLLFactory.University().UpdateFullInfo(wuhanUni);
            Assert.AreEqual("Luojia Hill, Wuchan District Wuhan 430072 Hubei Province", wuhanUni.Info.Address);
        }

        [TestMethod]
        public void AdressSaoPauloUni()
        {
            var saopauloUni =
                BLLFactory.University().GetTopByLocationName("Brazil").Find(u => u.Info.EnglishName == "University of Săo Paulo");
            BLLFactory.University().UpdateFullInfo(saopauloUni);
            Assert.AreEqual("Rua da Reitoria 109 - Cidade Universitária São Paulo 05508-900 São Paulo", saopauloUni.Info.Address);
        }

        [TestMethod]
        public void PhoneOxford()
        {
            var oxfordUni =
                BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("+44 (1865) 270 000", oxfordUni.Info.Phone);
        }

        [TestMethod]
        public void PhoneZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("+385 (1) 4564 111", zagrebUni.Info.Phone);
        }

        [TestMethod]
        public void PhoneSaoPauloUni()
        {
            var saopauloUni =
                BLLFactory.University().GetTopByLocationName("Brazil").Find(u => u.Info.EnglishName == "University of Săo Paulo");
            BLLFactory.University().UpdateFullInfo(saopauloUni);
            Assert.AreEqual("+55 (11) 3091 3500", saopauloUni.Info.Phone);
        }

        [TestMethod]
        public void TottalEnrollmentOxford()
        {
            var oxfordUni =
                BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("20,000-24,999", oxfordUni.Info.TotalEnrollment);
        }

        [TestMethod]
        public void TottalEnrollmentZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("over-45,000", zagrebUni.Info.TotalEnrollment);
        }

        [TestMethod]
        public void TottalEnrollmentHawassaUni()
        {
            var hawassaUni =
                BLLFactory.University().GetTopByLocationName("Ethiopia").Find(u => u.Name == "Hawassa University");
            BLLFactory.University().UpdateFullInfo(hawassaUni);
            Assert.AreEqual("20,000-24,999", hawassaUni.Info.TotalEnrollment);
        }

        [TestMethod]
        public void OfficialWebsiteOxford()
        {
            var oxfordUni =
               BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("http://www.ox.ac.uk", oxfordUni.Info.OfficalWebsite);
        }

        [TestMethod]
        public void OfficialZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("http://www.unizg.hr", zagrebUni.Info.OfficalWebsite);
        }

        [TestMethod]
        public void OfficialHawassaUni()
        {
            var hawassaUni =
                BLLFactory.University().GetTopByLocationName("Ethiopia").Find(u => u.Name == "Hawassa University");
            BLLFactory.University().UpdateFullInfo(hawassaUni);
            Assert.AreEqual("http://www.hu.edu.et", hawassaUni.Info.OfficalWebsite);
        }

        [TestMethod]
        public void LocalStudentUnderGraduatedPriceOxford()
        {
            var oxfordUni =
               BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("12,500-15,000 US$ (9,200-11,000 Euro)", oxfordUni.Info.LocalStudentsUnderGraduatePrice);
        }

        [TestMethod]
        public void LocalStudentUnderGraduatedPriceZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("Not reported", zagrebUni.Info.LocalStudentsUnderGraduatePrice);
        }

        [TestMethod]
        public void LocalStudentPostGraduatedPriceOxford()
        {
            var oxfordUni =
               BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("7,500-10,000 US$ (5,500-7,400 Euro)", oxfordUni.Info.LocalStudentsPostGraduatePrice);
        }

        [TestMethod]
        public void LocalStudentPostGraduatedPriceZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("Not reported", zagrebUni.Info.LocalStudentsPostGraduatePrice);
        }

        [TestMethod]
        public void InternationalStudentUnderGraduatedPriceOxford()
        {
            var oxfordUni =
               BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("over 20,000 US$ (14,700 Euro)", oxfordUni.Info.InternationalStudentsUnderGraduatePrice);
        }

        [TestMethod]
        public void InternationalStudentUnderGraduatedPriceZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("Not reported", zagrebUni.Info.InternationalStudentsUnderGraduatePrice);
        }

        [TestMethod]
        public void InternationalStudentPostGraduatedPriceOxford()
        {
            var oxfordUni =
               BLLFactory.University().GetTopByLocationName("United Kingdom").Find(u => u.Name == "University of Oxford");
            BLLFactory.University().UpdateFullInfo(oxfordUni);
            Assert.AreEqual("over 20,000 US$ (14,700 Euro)", oxfordUni.Info.InternationalStudentsPostGraduatePrice);
        }

        [TestMethod]
        public void InternationalStudentPostGraduatedPriceZagrebUni()
        {
            var zagrebUni =
                BLLFactory.University().GetTopByLocationName("Croatia").Find(u => u.Info.EnglishName == "University of Zagreb");
            BLLFactory.University().UpdateFullInfo(zagrebUni);
            Assert.AreEqual("Not reported", zagrebUni.Info.InternationalStudentsPostGraduatePrice);
        }
    }
}
