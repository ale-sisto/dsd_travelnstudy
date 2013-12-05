using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Utils
{
    public class QuestionResponse
    {
        public QuestionIdentifierEnum QuestionId { get; set; }
        public string Choice { get; set; }

        public QuestionResponse(QuestionIdentifierEnum inQuestionId, string inChoice)
        {
            QuestionId = inQuestionId;
            Choice = inChoice;
        }
    }
}
