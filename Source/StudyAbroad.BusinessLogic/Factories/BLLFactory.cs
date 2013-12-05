using StudyAbroad.BusinessLogic.Core;
using StudyAbroad.DomainModel;
using StudyAbroad.BusinessLogic.Framework;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.Factories
{
    public static class BLLFactory
    {
        public static UniversityBusinessLogic University()
        {
            return new UniversityBusinessLogic();
        }

        public static LocationBusinessLogic Location()
        {
            return new LocationBusinessLogic();
        }

        public static UserBusinessLogic User()
        {
            return new UserBusinessLogic();
        }

        public static SearchEngineBusinessLogic SearchEngine()
        {
            return new SearchEngineBusinessLogic();
        }

        public static ReviewBusinessLogic Reviews()
        {
            return new ReviewBusinessLogic();
        }
    }
}
