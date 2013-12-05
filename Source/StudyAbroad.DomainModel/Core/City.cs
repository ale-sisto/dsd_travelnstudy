using System;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.DomainModel.Core
{
    public class City : Location, IReviewable
    {
        public virtual int UniversityCount { get; set; }
        public virtual CityInfo Info { get; set; }

        public City(string inName, Location inContainedBy) : base(inName, inContainedBy)
        {
            Info = new CityInfo();
            //komentar
        }

        public City(string inName, Location inContainedBy, int inUniCount)
            : base(inName, inContainedBy)
        {
            Info = new CityInfo();
            UniversityCount = inUniCount;
        }

        public City()
        {
            Info = new CityInfo();
        }

        public virtual bool IsCityWorld()
        {
            return this is CityWorld;
        }

        public virtual bool IsCityUsa()
        {
            return this is CityUSA;
        }

        public virtual Country Country()
        {
            if (IsCityWorld())
                return ContainedBy.Self as Country;
            if (IsCityUsa())
                return ContainedBy.ContainedBy.Self as Country;
            else
            {
                return null;
            }
            //throw new Exception("This isnt supposed to get called ever but for testing");
            //It is used for Climate
        }

        public virtual string TypeName { get { return "City"; } }

        public virtual Enums.CostCategoriesEnum GetCostCategory()
        {
            return CostCategoriesEnum.Moderate;
        }
    }
}
