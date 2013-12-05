namespace StudyAbroad.DomainModel.Core
{
    public class Country : Location
    {
        //NOT mapped
        public virtual Region Region { get { return base.ContainedBy as Region; } }

        public Country(string inCode, string inName, Region inRegion) : base (inCode, inName, inRegion)
        {
        }

        public Country() { }
    }
}
