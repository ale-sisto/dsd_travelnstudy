using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Filters;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Questions;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Factories
{
    public class QuestionFactory
    {
        public static Question Create(QuestionIdentifierEnum inQuestionId)
        {
            switch (inQuestionId)
            {
                case QuestionIdentifierEnum.ContinentQuestion:
                    return new ContinentQuestion();
                case QuestionIdentifierEnum.RegionQuestion:
                    return new RegionQuestion();
                case QuestionIdentifierEnum.CourseLevelQuestion:
                    return new CourseLevelQuestion();
                case QuestionIdentifierEnum.StudyAreasQuestion:
                    return new StudyAreaQuestion();
                case QuestionIdentifierEnum.CostOfLifeQuestion:
                    return new CostOfLifeQuestion();
                case QuestionIdentifierEnum.ClimateQuestion:
                    return new ClimateQuestion();
                default:
                    throw new Exception("Question identifier not reckognized, could not create question!");
            }
        }
    }
}
