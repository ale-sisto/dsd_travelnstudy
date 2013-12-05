namespace StudyAbroad.DomainModel.Core
{
    public class Region : Location
    {
        //NOT mapped
        public virtual Continent Continent { get { return base.ContainedBy as Continent; } }

        public Region(string inCode, string inName, Continent inContinent) : base(inCode, inName, inContinent)
        {
        }

        public Region()
        {
        }
    }
}
