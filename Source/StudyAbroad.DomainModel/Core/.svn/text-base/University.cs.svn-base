using System;
using System.Collections.Generic;
using StudyAbroad.DomainModel.Framework;
using System.Linq;

namespace StudyAbroad.DomainModel.Core
{
    public class University : Location, IReviewable
    {
        public virtual UniversityInfo Info { get; set; }
        public virtual City City { get { return base.ContainedBy.Self as City; } set { base.ContainedBy = value; } }

        public University(string inName, string inCountryName)
            : base(inName, null)
        {
            Info = new UniversityInfo();
            Info.CountryName = inCountryName;
        }

        public University(string inName, string inEnglishName, string inCityName, string inCountryName)
            : base(inName, null)
        {
            Info = new UniversityInfo();
            Info.EnglishName = inEnglishName;
            Info.CityName = inCityName;
            Info.CountryName = inCountryName;
        }

        public University()
        {
            Info = new UniversityInfo();
        }

        public virtual string TypeName
        {
            get { return "University"; }
        }
    }
}
