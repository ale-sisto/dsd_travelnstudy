using System.Collections.Generic;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Framework
{
    public abstract class Filter
    {
        //When a filter is instantiated, some filter parameters should be set, such as what is filtered against
        //(example. for continents a continent name is needed)
        protected Filter(Instance inCurrentInstance)
        {
            SetFilterParameters(inCurrentInstance);
        }

        //External method that executes a filter then returns new instance state
        public InstanceState Execute(Instance inCurrentInstance)
        {
            return new InstanceState(inCurrentInstance.CurrentState, inCurrentInstance.CurrentQuestion, FilterList(inCurrentInstance.CurrentState.ResultSet));
        }

        //Set filter parameters
        protected abstract void SetFilterParameters(Instance inCurrentInstance);
        //Implement filter
        protected abstract List<University> FilterList(List<University> inList);
    }
}
