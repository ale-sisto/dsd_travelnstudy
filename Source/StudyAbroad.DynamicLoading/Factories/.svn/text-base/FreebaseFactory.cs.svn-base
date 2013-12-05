using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Configurations;
using StudyAbroad.DynamicLoading.Core;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DynamicLoading.Factories
{
    public class FreebaseUniversityUpdaterFactory
    {
        public Loader<University> Info(University inUniversity)
        {
            return new FreebaseUniversityLoader(new FreebaseLoaderConfiguration(inUniversity));
        }
    }

    public class FreebaseCityUpdaterFactory
    {
        public Loader<City> Info(City inCity)
        {
            return new FreebaseCityLoader(new FreebaseLoaderConfiguration(inCity));
        }
    }
}
