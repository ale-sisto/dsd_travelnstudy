using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Filters
{
    public class RegionFilter : Filter
    {
        //parameters
        private Region _region;

        public RegionFilter(Instance inInstance) : base(inInstance)
        {}

        protected override void SetFilterParameters(Utils.Instance inCurrentInstance)
        {
            var memory = inCurrentInstance.GetMemory(QuestionIdentifierEnum.RegionQuestion);
            var regionName = memory.GetParameterValue(ParametersEnum.RegionName);
            _region = BusinessLogic.Factories.BLLFactory.Location().GetByName(regionName) as Region;
        }

        protected override List<University> FilterList(List<University> inList)
        {
            if (inList.Count <= 200)
                return inList.Where(u => u.ContainedBy.ContainedBy.ContainedBy == _region ||
                                            u.ContainedBy.ContainedBy.ContainedBy.ContainedBy == _region)
                    .ToList();
            else
            {
                var unisOnRegion = BusinessLogic.Factories.BLLFactory.University().GetTopByLocation(_region, 99999);
                return inList.Intersect(unisOnRegion).ToList();
            }
        }
    }
}
