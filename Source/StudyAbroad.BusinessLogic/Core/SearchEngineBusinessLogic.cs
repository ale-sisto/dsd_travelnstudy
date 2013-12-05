using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.BusinessLogic.Core
{
   public class SearchEngineBusinessLogic
    {
       public List<SearchEngine.SearchResult> SearchLocation(string inKeyWord)
       {
           return SearchEngine.Factories.SearchEngineFactory.SearchLocationByKeyWordEngine().Search(inKeyWord);
       }

       public List<SearchEngine.SearchResult> SearchLocation(string inKeyWord,int count)
       {
           return SearchEngine.Factories.SearchEngineFactory.SearchLocationByKeyWordEngine().Search(inKeyWord,count);
       }
    }
}
