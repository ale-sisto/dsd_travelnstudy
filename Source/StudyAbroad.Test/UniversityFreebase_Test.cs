using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.BusinessLogic.Core;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.Test
{
    [TestClass]
    public class UniversityFreebase_Test
    {
        [TestMethod]
        public void UniversityShortInfo()
        {
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            University uni = bll.GetByName("University of South Asia");
            bll.UpdateFullInfo(uni);
            Assert.IsTrue(uni.Info.Description.Contains("University of South Asia (Bengali: সাউথ এশিয়া বিশ্ববিদ্যালয়) or UNiSA is a private university in the Banani Residential Area of Dhaka, Bangladesh. The university was established by the Private University Act of 1992. Its curriculum has been approved by the University Grant Commission of the Government of the People’s Republic of Bangladesh"));
        }

        [TestMethod]
        public void ZagrebUniversityDescription()
        {
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            University uni = bll.GetByName("Sveucilište u Zagrebu");
            bll.UpdateFullInfo(uni);
            Assert.IsTrue(uni.Info.Description.Contains("The University of Zagreb (Croatian: Sveučilište u Zagrebu, Latin: Universitas Studiorum Zagrabiensis) is the biggest Croatian university and the oldest continuously operating university in the area covering Central Europe south of Vienna and all of Southeastern Europe."));
        }

        [TestMethod]
        public void UniversityImageURL()
        {
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            University uni = bll.GetByName("University of Seychelles");
            bll.UpdateFullInfo(uni);
            Assert.AreEqual(@"https://www.googleapis.com/freebase/v1/image/wikipedia/images/commons_id/9716916?maxheight=0&maxwidth=0", uni.Info.ImageURL);
        }

        [TestMethod]
        public void University()
        {
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            University uni = bll.GetByName("University of Delhi");
            bll.UpdateFullInfo(uni);
            Assert.IsTrue(uni.Info.Departments.Contains("Dept Of East Asian Studies, Delhi University."));
        }

        [TestMethod]
        public void UniversityFoundationYear()
        {
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            University uni = bll.GetByName("University of Tehran");
            bll.UpdateFullInfo(uni);
            Assert.AreEqual("1934", uni.Info.FoundationYear);
        }

        [TestMethod]
        public void UniversityPhone()
        {
            University uni = new University("University of Guadalajara", "Mexico");
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            bll.UpdateFullInfo(uni);
            Assert.AreEqual("+52 (33) 3134-2222", uni.Info.Phone);
        }

        [TestMethod]
        public void UniversityAddress()
        {
            University uni = new University("University of Alaska Southeast", "United States of America");
            UniversityBusinessLogic bll = new UniversityBusinessLogic();
            bll.UpdateFullInfo(uni);
            Assert.AreEqual("11120 Glacier Highway Juneau Alaska 99801", uni.Info.Address);
        }
    }

}
