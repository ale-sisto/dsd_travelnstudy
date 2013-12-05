using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Filters
{
    public class ClimateFilter : Filter
    {
        private ClimateCategoryEnum _climateCategory;

        public ClimateFilter(Instance inInstance) : base(inInstance) {}

        protected override void SetFilterParameters(Utils.Instance inCurrentInstance)
        {
            var memory = inCurrentInstance.GetMemory(QuestionIdentifierEnum.ClimateQuestion);
            var climateCategoryName = memory.GetParameterValue(ParametersEnum.Climate);
            ClimateCategoryEnum.TryParse(climateCategoryName, false, out _climateCategory);
        }

        protected override List<DomainModel.Core.University> FilterList(List<DomainModel.Core.University> inList)
        {
            var cities = inList.Select(u => u.City).ToList();
            BusinessLogic.Factories.BLLFactory.Location().City().UpdateManyClimateInfo(cities);
            return inList.Where(u => BLLFactory.Location().City().GetClimateCategory(u.City) == _climateCategory).ToList();
        }
    }
}
