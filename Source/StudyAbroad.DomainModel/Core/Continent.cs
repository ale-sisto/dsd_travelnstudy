namespace StudyAbroad.DomainModel.Core
{
    public class Continent : Location
    {
        //NOT mapped
        public virtual Location World { get { return ContainedBy; } }

        public Continent(string inCode, string inName, Location inContainedBy) : base(inCode, inName, inContainedBy)
        {
        }

        public Continent()
        {
        }
    }
}
