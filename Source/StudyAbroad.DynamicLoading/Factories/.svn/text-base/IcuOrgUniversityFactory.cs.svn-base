using StudyAbroad.DomainModel;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Configurations;
using StudyAbroad.DynamicLoading.Core;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DynamicLoading.Factories
{
    /// <summary>
    /// Factory for creating university loaders
    /// Should create loaders by supplying them with neccesary configurations
    /// </summary>
    public class IcuOrgUniversityLoaderFactory
    {
        public Loader<University> TopLocation(Location inLocation)
        {
            return new IcuOrgUniversityLoader(new IcuOrgLoaderConfiguration(inLocation));
        }

        public Loader<University> TopWorld(Location inWorld)
        {
            return new IcuOrgUniversityLoader(new IcuOrgLoaderConfiguration(inWorld));
        }

        public Loader<University> TopCountry(Country inCountry)
        {
            return new IcuOrgUniversityLoader(new IcuOrgLoaderConfiguration(inCountry));
        }

        public Loader<University> TopContinent(Continent inContinent)
        {
            return new IcuOrgUniversityLoader(new IcuOrgLoaderConfiguration(inContinent));
        }

        public Loader<University> TopState(State inState)
        {
            return new IcuOrgUniversityLoader(new IcuOrgLoaderConfiguration(inState));
        }
    }

    public class IcuOrgUniversityUpdaterFactory
    {
        public Loader<University> Info(University inUniversity)
        {
            return new IcuOrgUniversityLoader(new IcuOrgLoaderConfiguration(inUniversity));
        }
    }
}
