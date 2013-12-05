using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Core;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DynamicLoading.Factories
{
   public class DataBankClimateFactory
    {
        public Loader<City> Climate()
        {
            return new DataBankClimateLoader(null);
        }
    }
}
