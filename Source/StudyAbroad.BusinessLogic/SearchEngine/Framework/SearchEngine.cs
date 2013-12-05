using System.Collections.Generic;

namespace StudyAbroad.BusinessLogic.SearchEngine.Framework
{
   public abstract class SearchEngine<T> :Framework.ISearch
    {
       protected List<T>  SearchingData;

       protected SearchEngine(List<T> inData)
        {
            SearchingData = inData;
        }

       public abstract List<SearchResult> Search(string inKeyWord, int count);


       public abstract List<SearchResult> Search(string inKeyWord);

    }
}
