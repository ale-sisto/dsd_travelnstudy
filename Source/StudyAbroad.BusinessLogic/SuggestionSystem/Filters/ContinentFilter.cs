using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Filters
{
    public class ContinentFilter : Filter
    {
        //parameters
        private Continent _continent;

        //Pass the instance to the interface
        public ContinentFilter(Instance inInstance) : base (inInstance)
        {
        }

        //Set continent filter parameter
        protected override void SetFilterParameters(Instance inCurrentInstance)
        {
            var memory = inCurrentInstance.GetMemory(QuestionIdentifierEnum.ContinentQuestion);
            var continentName = memory.GetParameterValue(ParametersEnum.ContinentName);
            _continent = BusinessLogic.Factories.BLLFactory.Location().GetByName(continentName) as Continent;
        }

        //Filter the list of universities by continent
        protected override List<University> FilterList(List<University> inList)
        {
            if (inList.Count <= 200)
                return inList.Where(u => u.ContainedBy.ContainedBy.ContainedBy.ContainedBy == _continent ||
                                            u.ContainedBy.ContainedBy.ContainedBy.ContainedBy.ContainedBy == _continent)
                    .ToList();
            else
            {
                var unisOnContinent = BusinessLogic.Factories.BLLFactory.University().GetTopByLocation(_continent, 99999);
                return inList.Intersect(unisOnContinent).ToList();
            }
        }
    }
}
