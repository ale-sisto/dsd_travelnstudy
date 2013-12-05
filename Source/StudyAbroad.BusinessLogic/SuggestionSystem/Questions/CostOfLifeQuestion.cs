using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Filters;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Questions
{
    public class CostOfLifeQuestion : Question
    {
        public CostOfLifeQuestion() : base(QuestionIdentifierEnum.CostOfLifeQuestion, ParametersEnum.CostOfLife)
        {}

        protected override string CreateQuestionString(Utils.Instance inCurrentInstance)
        {
            return "What kind of a city would you like to go?";
        }

        protected override List<string> CreateChoicesList(Utils.Instance inCurrentInstance)
        {
            var choices = base.CreateChoicesList(inCurrentInstance);
            choices.Add(EnumHelper.GetStringFromCostCategory(CostCategoriesEnum.VeryCheap));
            choices.Add(EnumHelper.GetStringFromCostCategory(CostCategoriesEnum.Cheap));
            choices.Add(EnumHelper.GetStringFromCostCategory(CostCategoriesEnum.Moderate));
            choices.Add(EnumHelper.GetStringFromCostCategory(CostCategoriesEnum.Expensive));
            choices.Add(EnumHelper.GetStringFromCostCategory(CostCategoriesEnum.VeryExpensive));
            return choices;
        }

        protected override Filter GetFilter(Utils.Instance inCurrentInstance)
        {
            return new CostOfLifeFilter(inCurrentInstance);
        }

        public override Utils.Explanation GetExplanation(DomainModel.Core.University inUniversity, Utils.Instance inCurrentInstance)
        {
            throw new NotImplementedException();
        }
    }
}
