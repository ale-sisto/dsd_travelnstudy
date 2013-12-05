using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Factories;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem
{
    public sealed class SuggestionSystem
    {
        public User LoggedInUser;

        #region ControlCenter
        public static SuggestionSystem Handler
        {
            get
            {
                return Nested.SuggSystemHandler;
            }
        }

        private Instance ContextInstance
        {
            get
            {
                if (IsInWebContext())
                {
                    return (Instance)HttpContext.Current.Session["SuggSystemInstance"];
                }
                else
                {
                    return (Instance)CallContext.GetData("SuggSystemInstance");
                }
            }
            set
            {
                if (IsInWebContext())
                {
                    HttpContext.Current.Session["SuggSystemInstance"] = value;
                }
                else
                {
                    CallContext.SetData("SuggSystemInstance", value);
                }
            }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly SuggestionSystem SuggSystemHandler =
                new SuggestionSystem();
        }

        private bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }
        #endregion

        #region Initialization
        public void StartNewInstance(User user)
        {
            ContextInstance = InitializeDefaultInstance();
            if (user != null)
                LoggedInUser = user;
            //if (IsInWebContext())
            //{
            //    HttpContext.Current.Items["SuggSystemInstance"] = ContextInstance;
            //}
            //else
            //{
            //    CallContext.SetData("SuggSystemInstance", ContextInstance);
            //}
        }

        public void StartNewInstance(List<QuestionIdentifierEnum> inQuestions)
        {
            ContextInstance = InitializeCustomInstance(inQuestions);
        }

        private static Instance InitializeDefaultInstance()
        {
            var hardcodedQuestionsList = new List<QuestionIdentifierEnum>();
            hardcodedQuestionsList.Add(QuestionIdentifierEnum.ContinentQuestion);
            hardcodedQuestionsList.Add(QuestionIdentifierEnum.RegionQuestion);
            hardcodedQuestionsList.Add(QuestionIdentifierEnum.CourseLevelQuestion);
            hardcodedQuestionsList.Add(QuestionIdentifierEnum.StudyAreasQuestion);
            hardcodedQuestionsList.Add(QuestionIdentifierEnum.CostOfLifeQuestion);
            hardcodedQuestionsList.Add(QuestionIdentifierEnum.ClimateQuestion);

            return new Instance(hardcodedQuestionsList);
        }

        private static Instance InitializeCustomInstance(List<QuestionIdentifierEnum> inQuestions)
        {
            return new Instance(inQuestions);
        }
        #endregion

        public List<University> GetInstanceResults(int inLimit = 10)
        {
            return ContextInstance.GetResults(inLimit);
        }

        public List<HistoryItem> GetHistory()
        {
            return ContextInstance.GetHistory();
        }

        public QuestionRequest GetNextQuestion()
        {
            return ContextInstance.NextQuestion();
        }

        public void UndoLastQuestion()
        {
            ContextInstance.UndoLast();
        }

        public InstanceStatusEnum GetStatus()
        {
            return ContextInstance == null ? InstanceStatusEnum.NotInitialized : ContextInstance.Status;
        }

        public bool AnswerQuestion(string inAnswer)
        {
            var response = new QuestionResponse(ContextInstance.CurrentQuestion, inAnswer);
            return ContextInstance.ProcessResponse(response);
        }

        public void Stop()
        {
            ContextInstance = null;
        }

        public ExplanationCollection Explain(University item)
        {
            var questions = new List<QuestionIdentifierEnum>() { QuestionIdentifierEnum.ContinentQuestion, QuestionIdentifierEnum.StudyAreasQuestion };
            return ContextInstance.ExplainItem(questions, item);
        }

        public string GetStatusText()
        {
            if (ContextInstance == null)
                return "There is no active instance of the suggestion system. Start a new instance!";
            switch (ContextInstance.Status)
            {
                case InstanceStatusEnum.NotInitialized:
                    return "Suggestion system has not been initialized yet.";
                case InstanceStatusEnum.Ready:
                    return "Suggestion system reports ready for next question.";
                case InstanceStatusEnum.WaitingForAnswer:
                    return "Suggestion system reports waiting for answer to last question.";
                case InstanceStatusEnum.Error:
                    return "Suggestion system has encountered an error and terminated.";
                case InstanceStatusEnum.ResultSetUnderN:
                    return "Suggestion system result set is under specified value.";
                case InstanceStatusEnum.ResultSetEmpty:
                    return "Suggestion system result set is empty.";
                case InstanceStatusEnum.LastQuestion:
                    return "Suggestion system reports no more questions.";
                default:
                    return "Suggestion system not available.";
            }
        }



    }
}
