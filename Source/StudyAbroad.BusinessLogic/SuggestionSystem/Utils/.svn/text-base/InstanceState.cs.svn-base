using System.Collections.Generic;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Utils
{
    public class InstanceState
    {
        public QuestionIdentifierEnum Question { get; private set; }
        public InstanceState PreviousState { get; private set; }
        public List<University> ResultSet { get; private set; }
 
        public InstanceState (InstanceState inPreviousState, QuestionIdentifierEnum inQuestionId, List<University> inUniversityList)
        {
            PreviousState = inPreviousState;
            Question = inQuestionId;
            ResultSet = inUniversityList;
        }

        public void ApplyRecommendation(int userId)
        {
            if (ResultSet.Count == 0)
                ResultSet = RecommendationSystem.RecommendationSystem.Handler.RecommendUnis(userId);
            else
                ResultSet = RecommendationSystem.RecommendationSystem.Handler.RecommendUnis(userId, ResultSet);
        }
    }
}
