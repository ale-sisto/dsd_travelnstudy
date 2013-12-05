namespace StudyAbroad.DomainModel.Core
{
    public class State : Location
    {
        //NOT mapped
        public virtual Country Country { get { return base.ContainedBy as Country; } }

        public State(string inCode, string inName, Country inCountry) : base (inCode, inName, inCountry)
        {
        }

        public State()
        {}
    }
}
