using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Utils
{
    public class HistoryItem
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }

        public HistoryItem(string inQuestionText, string inAnswer)
        {
            QuestionText = inQuestionText;
            Answer = inAnswer;
        }
    }
}
