using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SearchEngine.Framework;

namespace StudyAbroad.BusinessLogic.SearchEngine.Factories
{
    static  class  SearchEngineFactory
    {
        public static SearchEngine<DomainModel.Core.Location> SearchLocationByKeyWordEngine()
        {
           List<DomainModel.Core.Location> inLocation= BusinessLogic.Factories.BLLFactory.Location().GetAll();
            return new SearchLocation(inLocation);
        }
    }
}
