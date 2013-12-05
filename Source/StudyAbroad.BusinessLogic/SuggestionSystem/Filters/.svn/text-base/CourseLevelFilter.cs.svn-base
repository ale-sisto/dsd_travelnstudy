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
    public class CourseLevelFilter : Filter
    {
        //parameters
        private CourseLevelsEnum _courseLevel;

        public CourseLevelFilter(Instance inInstance) : base (inInstance)
        {
        }

        protected override void SetFilterParameters(Utils.Instance inCurrentInstance)
        {
            var memory = inCurrentInstance.GetMemory(QuestionIdentifierEnum.CourseLevelQuestion);
            var courseLevelName = memory.GetParameterValue(ParametersEnum.CourseLevel);
            _courseLevel = EnumHelper.GetCourseLevelFromString(courseLevelName);
        }

        protected override List<University> FilterList(List<University> inList)
        {
            return inList.Where(u => u.Info.CourseLevels.Contains(_courseLevel)).ToList();
        }
    }
}
