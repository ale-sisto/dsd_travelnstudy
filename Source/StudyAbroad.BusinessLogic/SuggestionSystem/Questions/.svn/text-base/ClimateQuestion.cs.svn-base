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
    public class ClimateQuestion : Question
    {
        public ClimateQuestion() : base(QuestionIdentifierEnum.ClimateQuestion, ParametersEnum.Climate)
        {}

        protected override string CreateQuestionString(Utils.Instance inCurrentInstance)
        {
            return "What kind of climate do you prefer?";
        }

        protected override List<string> CreateChoicesList(Utils.Instance inCurrentInstance)
        {
            var choices = base.CreateChoicesList(inCurrentInstance);
            choices.Add(ClimateCategoryEnum.Continental.ToString());
            choices.Add(ClimateCategoryEnum.Dry.ToString());
            choices.Add(ClimateCategoryEnum.Polar.ToString());
            choices.Add(ClimateCategoryEnum.Temperate.ToString());
            choices.Add(ClimateCategoryEnum.Tropical.ToString());
            return choices;
        }

        protected override Filter GetFilter(Utils.Instance inCurrentInstance)
        {
            return new ClimateFilter(inCurrentInstance);
        }

        public override Utils.Explanation GetExplanation(DomainModel.Core.University inUniversity, Utils.Instance inCurrentInstance)
        {
            throw new NotImplementedException();
        }
    }
}
