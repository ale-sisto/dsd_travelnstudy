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
    public class StudyAreasFilter : Filter
    {
        //parameters
        private StudyAreasEnum _studyArea;
        private CourseLevelsEnum _courseLevel;

        public StudyAreasFilter(Instance inInstance) : base(inInstance)
        {
        }

        protected override void SetFilterParameters(Utils.Instance inCurrentInstance)
        {
            if (inCurrentInstance.MemoryHasEntry(QuestionIdentifierEnum.CourseLevelQuestion))
            {
                var courseLevelName = inCurrentInstance.GetMemory(QuestionIdentifierEnum.CourseLevelQuestion).GetParameterValue(ParametersEnum.CourseLevel);
                _courseLevel = EnumHelper.GetCourseLevelFromString(courseLevelName);
            }
            else
                _courseLevel = CourseLevelsEnum.BachelorDegrees;

            var memory = inCurrentInstance.GetMemory(QuestionIdentifierEnum.StudyAreasQuestion);
            var studyAreaName = memory.GetParameterValue(ParametersEnum.StudyArea);
            _studyArea = EnumHelper.GetStudyAreaFromString(studyAreaName);
        }

        protected override List<University> FilterList(List<University> inList)
        {
            switch (_studyArea)
            {
                case StudyAreasEnum.ArtsHumanities:
                    return inList.Where(u => u.Info.AreasOfStudies.ArtsHumanities.Contains(_courseLevel)).ToList();
                case StudyAreasEnum.BusinessSocialSciences:
                    return inList.Where(u => u.Info.AreasOfStudies.BusinessSocialSciences.Contains(_courseLevel)).ToList();
                case StudyAreasEnum.Engineering:
                    return inList.Where(u => u.Info.AreasOfStudies.Engineering.Contains(_courseLevel)).ToList();
                case StudyAreasEnum.LanguageCulturalStudies:
                    return inList.Where(u => u.Info.AreasOfStudies.LanguageCulturalStudies.Contains(_courseLevel)).ToList();
                case StudyAreasEnum.MedicineHealth:
                    return inList.Where(u => u.Info.AreasOfStudies.MedicineHealth.Contains(_courseLevel)).ToList();
                case StudyAreasEnum.ScienceTechnology:
                    return inList.Where(u => u.Info.AreasOfStudies.ScienceTechnology.Contains(_courseLevel)).ToList();
                default:
                    return inList;
            }
        }
    }
}
