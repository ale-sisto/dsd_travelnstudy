using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DomainModel.Framework;

namespace StudyAbroad.DomainModel.Core
{
    public class UniversityInfo : DomainBase<UniversityInfo>
    {
        #region 4icu.org
        /// <summary>
        /// Short and long (country level / check for null)
        /// It will be "Not Reported" when we recreate database
        /// </summary>
        public virtual string EnglishName { get; set; }
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual string CountryName { get; set; }
        /// <summary>
        /// Short and long (country level)
        /// </summary>
        public virtual string CityName { get; set; }
        /// <summary>
        /// Long only (check for null)
        /// </summary>
        public virtual string FoundationYear { get; set; }
        /// <summary>
        /// Short and long (check for null)
        /// </summary>
        public virtual string Motto { get; set; }
        /// <summary>
        /// Long only (check for null)
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// Long only (check for null)
        /// </summary>
        public virtual string Phone { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string TotalEnrollment { get; set; }
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual string OfficalWebsite { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string LocalStudentsUnderGraduatePrice { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string LocalStudentsPostGraduatePrice { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string InternationalStudentsUnderGraduatePrice { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string InternationalStudentsPostGraduatePrice { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual List<string> AcademicStructure { get; set; }
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual int GlobalRank { get; set; }
        
        #region new data

            //new data
            public virtual List<CourseLevelsEnum> CourseLevels { get; set; }

            public virtual  AreasOfStudies  AreasOfStudies{ get; set; }

            public virtual string Gender { get; set; }

            public virtual string InternationalStudents { get; set; }

            public virtual string AdmissionSelection { get; set; }

            public virtual string SelectionPercentage { get; set; }

            public virtual string TotalStaff { get; set; }

            public virtual string ControlType { get; set; }

            public virtual string EntityType { get; set; }

            public virtual string AcademicCalendar { get; set; }

            public virtual string CampusType { get; set; }

            public virtual List<string> AffilationsAndMemberships { get; set; }

            public virtual string FacebookUri { get; set; }

            public virtual string LinkedInUri { get; set; }

            public virtual string TwitterUri { get; set; }

            public virtual string YouTubeUri { get; set; }

            public virtual string WikipediaUri { get; set; }

            public virtual string Library { get; set; }

            public virtual string LibraryUri { get; set; }

            public virtual string Sports { get; set; }

            public virtual string Scholarships { get; set; }

            public virtual string Housing { get; set; }

            public virtual string ExchangePrograms { get; set; }

            public virtual string OnlineCourses { get; set; }


        #endregion

        #endregion

        #region Freebase
        //From freebase
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string ImageURL { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual List<string> Departments { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual int NumOfUndergraduates { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual int NumOfPostgraduates { get; set; }

        public virtual string FullDescriptionURL { get; set; }          //remove on recreating database

        #endregion
    }

    //public class Tuition
    //{
    //    public int Amount { get; set; }
    //    public string Currency { get; set; }
    //    public string Date { get; set; }

    //    public Tuition(int inAmount, string inCurrency, string inDate)
    //    {
    //        Amount = inAmount;
    //        Currency = inCurrency;
    //        Date = inDate;
    //    }
    //}
}
