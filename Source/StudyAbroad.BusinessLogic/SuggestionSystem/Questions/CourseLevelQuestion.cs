using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Filters;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Questions
{
    public class CourseLevelQuestion : Question
    {
        public CourseLevelQuestion() : base(QuestionIdentifierEnum.CourseLevelQuestion, ParametersEnum.CourseLevel)
        {
        }

        protected override string CreateQuestionString(Instance inCurrentInstance)
        {
            return "Which course level are you pursuing?";
        }

        protected override List<string> CreateChoicesList(Instance inCurrentInstance)
        {
            var choices = base.CreateChoicesList(inCurrentInstance);
            choices.Add(EnumHelper.GetStringFromCourseLevel(CourseLevelsEnum.CertificatesOrDiplomas));
            choices.Add(EnumHelper.GetStringFromCourseLevel(CourseLevelsEnum.AssociateDegrees));
            choices.Add(EnumHelper.GetStringFromCourseLevel(CourseLevelsEnum.BachelorDegrees));
            choices.Add(EnumHelper.GetStringFromCourseLevel(CourseLevelsEnum.MasterDegrees));
            choices.Add(EnumHelper.GetStringFromCourseLevel(CourseLevelsEnum.DoctorateDegrees));
            return choices;
        }


        protected override Filter GetFilter(Instance inCurrentInstance)
        {
            return new CourseLevelFilter(inCurrentInstance);
        }

        public override Explanation GetExplanation(DomainModel.Core.University inUniversity, Instance inCurrentInstance)
        {
            var response = new List<string>();
            var courseLevel = inCurrentInstance.GetMemory(Id).GetParameterValue(Parameter);
            response.Add("You have selected the following course level: " + courseLevel);
            response.Add("The university supports the following education programs: ");
            response.AddRange(inUniversity.Info.CourseLevels.Select(EnumHelper.GetStringFromCourseLevel));
            return new Explanation(Id, response);
        }


    }
}
