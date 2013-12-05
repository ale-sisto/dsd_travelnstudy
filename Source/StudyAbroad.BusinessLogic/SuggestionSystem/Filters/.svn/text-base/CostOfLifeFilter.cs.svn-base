using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Filters
{
    public class CostOfLifeFilter : Filter
    {
        //parameters
        private CostCategoriesEnum _costCategory;

        public CostOfLifeFilter(Instance inInstance) : base(inInstance)
        {}

        protected override void SetFilterParameters(Utils.Instance inCurrentInstance)
        {
            var memory = inCurrentInstance.GetMemory(QuestionIdentifierEnum.CostOfLifeQuestion);
            var costCategoryName = memory.GetParameterValue(ParametersEnum.CostOfLife);
            _costCategory = EnumHelper.GetCostCategoryFromString(costCategoryName);
        }

        protected override List<DomainModel.Core.University> FilterList(List<DomainModel.Core.University> inList)
        {
            var cities = inList.Select(u => u.City).ToList();
            BusinessLogic.Factories.BLLFactory.Location().City().UpdateManyCostOfLife(cities);
            return inList.Where(u => BusinessLogic.CostOfLife.CostOfLife.GetCostIndex(u.City) == _costCategory).ToList();
            return inList.Where(u => u.City.GetCostCategory() == _costCategory).ToList();
        }
    }
}
