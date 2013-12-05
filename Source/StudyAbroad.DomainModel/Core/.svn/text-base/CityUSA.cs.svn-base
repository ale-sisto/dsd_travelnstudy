namespace StudyAbroad.DomainModel.Core
{
    public class CityUSA : City
    {
        //This is NOT mapped
        public virtual State State { get { return base.ContainedBy as State; } }
        
        public CityUSA(string inName, State inState) : base (inName, inState)
        {
        }

        public CityUSA(string inName, State inState, int inUniCount)
            : base(inName, inState, inUniCount)
        {
        }

        public CityUSA()
        {}
    }
}
