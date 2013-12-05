namespace StudyAbroad.DomainModel.Core
{
    public class CityWorld : City
    {

        public CityWorld(string inName, Country inCountry) : base (inName, inCountry)
        {
        }

        public CityWorld(string inName, Country inCountry, int inUniCount)
            : base(inName, inCountry, inUniCount)
        {
        }


        public CityWorld()
        {}
    }
}
