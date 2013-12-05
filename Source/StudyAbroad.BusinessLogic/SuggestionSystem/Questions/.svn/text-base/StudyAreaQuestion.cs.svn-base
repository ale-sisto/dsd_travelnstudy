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
    public class StudyAreaQuestion : Question
    {
        public StudyAreaQuestion() : base(QuestionIdentifierEnum.StudyAreasQuestion, ParametersEnum.StudyArea)
        {
        }

        protected override string CreateQuestionString(Instance inCurrentInstance)
        {
            return "Which study area are you interested in?";
        }

        protected override List<string> CreateChoicesList(Instance inCurrentInstance)
        {
            var choices = base.CreateChoicesList(inCurrentInstance);
            choices.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.ArtsHumanities));
            choices.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.BusinessSocialSciences));
            choices.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.LanguageCulturalStudies));
            choices.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.MedicineHealth));
            choices.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.Engineering));
            choices.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.ScienceTechnology));
            return choices;
        }

        protected override Filter GetFilter(Instance inCurrentInstance)
        {
            return new StudyAreasFilter(inCurrentInstance);
        }

        public override Explanation GetExplanation(DomainModel.Core.University inUniversity, Instance inCurrentInstance)
        {
            var response = new List<string>();
            var studyArea = inCurrentInstance.GetMemory(Id).GetParameterValue(Parameter);
            response.Add("You have selected the following academic field: " + studyArea);
            response.Add("The university has courses that cover the following academic fields: ");
            if (inUniversity.Info.AreasOfStudies.ArtsHumanities.Count > 0)
                response.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.ArtsHumanities));
            if (inUniversity.Info.AreasOfStudies.BusinessSocialSciences.Count > 0)
                response.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.BusinessSocialSciences));
            if (inUniversity.Info.AreasOfStudies.Engineering.Count > 0)
                response.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.Engineering));
            if (inUniversity.Info.AreasOfStudies.LanguageCulturalStudies.Count > 0)
                response.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.LanguageCulturalStudies));
            if (inUniversity.Info.AreasOfStudies.MedicineHealth.Count > 0)
                response.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.MedicineHealth));
            if (inUniversity.Info.AreasOfStudies.ScienceTechnology.Count > 0)
                response.Add(EnumHelper.GetStringFromStudyArea(StudyAreasEnum.ScienceTechnology));

            response.Add("For " +studyArea+ ", the university has courses in the following programs: ");
            var studyAreaEnum = EnumHelper.GetStudyAreaFromString(studyArea);
            switch (studyAreaEnum)
            {
                case StudyAreasEnum.ScienceTechnology:
                    inUniversity.Info.AreasOfStudies.ScienceTechnology.ForEach(i => response.Add(EnumHelper.GetStringFromCourseLevel(i)));
                    break;
                case StudyAreasEnum.MedicineHealth:
                    inUniversity.Info.AreasOfStudies.MedicineHealth.ForEach(i => response.Add(EnumHelper.GetStringFromCourseLevel(i)));
                    break;
                case StudyAreasEnum.LanguageCulturalStudies:
                    inUniversity.Info.AreasOfStudies.LanguageCulturalStudies.ForEach(i => response.Add(EnumHelper.GetStringFromCourseLevel(i)));
                    break;
                case StudyAreasEnum.Engineering:
                    inUniversity.Info.AreasOfStudies.Engineering.ForEach(i => response.Add(EnumHelper.GetStringFromCourseLevel(i)));
                    break;
                case StudyAreasEnum.BusinessSocialSciences:
                    inUniversity.Info.AreasOfStudies.BusinessSocialSciences.ForEach(i => response.Add(EnumHelper.GetStringFromCourseLevel(i)));
                    break;
                case StudyAreasEnum.ArtsHumanities:
                    inUniversity.Info.AreasOfStudies.ArtsHumanities.ForEach(i => response.Add(EnumHelper.GetStringFromCourseLevel(i)));
                    break;
            }
            return new Explanation(Id, response);
        }


    }
}
