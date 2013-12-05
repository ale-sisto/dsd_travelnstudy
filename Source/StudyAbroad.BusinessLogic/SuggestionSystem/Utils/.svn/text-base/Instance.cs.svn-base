using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Factories;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Utils
{
    public class Instance
    {     
        public Instance(List<QuestionIdentifierEnum> inInstanceQuestions)
        {
            InitializeQuestions(inInstanceQuestions);
            InitializeState();
            InitializeMemory();
            SetStatus(InstanceStatusEnum.Ready);
        }

        public QuestionRequest NextQuestion()
        {
            if (Status != InstanceStatusEnum.Ready)
                throw new Exception("Suggestion system found in incorrect state, aborting...");
            _currentQuestionIndex++;
            var question = QuestionFactory.Create(CurrentQuestion);
            SetStatus(InstanceStatusEnum.WaitingForAnswer);
            return question.CreateRequest(this);
        }

        public bool ProcessResponse(QuestionResponse response)
        {
            if (Status != InstanceStatusEnum.WaitingForAnswer)
                throw new Exception("Suggestion system found in incorrect state, aborting...");
            Memory.Add(CurrentQuestion, new ParameterCollection());
            var question = QuestionFactory.Create(CurrentQuestion);
            CurrentState = question.ProcessResponse(response, this);
            return EvaluateState();
        }

        public void ApplyRecommendations(int userId)
        {
            
        }

        public List<HistoryItem> GetHistory()
        {
            return (from entry in Memory let question = QuestionFactory.Create(entry.Key) select new HistoryItem(question.GetQuestionString(this), entry.Value.GetParameterValue(question.Parameter))).ToList();
        }

        private bool EvaluateState()
        {
            SetStatus(InstanceStatusEnum.Ready);
            if(CurrentQuestion == Questions.Last())
                SetStatus(InstanceStatusEnum.LastQuestion);
            if (CurrentState.ResultSet.Count <= NCOUNT)
                SetStatus(InstanceStatusEnum.ResultSetUnderN);
            if (CurrentState.ResultSet.Count == 0)
                SetStatus(InstanceStatusEnum.ResultSetEmpty);

            if (Status == InstanceStatusEnum.ResultSetEmpty || Status == InstanceStatusEnum.ResultSetUnderN || Status == InstanceStatusEnum.LastQuestion)
                if (SuggestionSystem.Handler.LoggedInUser != null)
                    CurrentState.ApplyRecommendation(SuggestionSystem.Handler.LoggedInUser.Id);

            return Status == InstanceStatusEnum.Ready;
        }

        public ExplanationCollection ExplainItem(List<QuestionIdentifierEnum> questions, University item)
        {
            var explanations = questions.Select(question => QuestionFactory.Create(question).GetExplanation(item, this)).ToList();
            return new ExplanationCollection(item, explanations);
        }

        #region InstanceState
        public InstanceState CurrentState { get; private set; }
        private void InitializeState()
        {
            CurrentState = new InstanceState(null, CurrentQuestion, BusinessLogic.Factories.BLLFactory.University().GetTopAll());        
        }
        #endregion

        #region InstanceQuestions
        private List<QuestionIdentifierEnum> Questions { get; set; }
        private int _currentQuestionIndex;

        public QuestionIdentifierEnum CurrentQuestion
        {
            get { return Questions[_currentQuestionIndex]; }
        }

        private void InitializeQuestions(List<QuestionIdentifierEnum> inQuestions)
        {
            Questions = new List<QuestionIdentifierEnum>() { QuestionIdentifierEnum.None };
            Questions.AddRange(inQuestions);
            _currentQuestionIndex = 0;
        }
        #endregion

        #region InstanceStatus
        public InstanceStatusEnum Status { get; private set; }

        private void SetStatus(InstanceStatusEnum inStatus)
        {
            Status = inStatus;
        } 
        #endregion

        #region InstanceMemory
        public Dictionary<QuestionIdentifierEnum, ParameterCollection> Memory { get; private set; }

        private void InitializeMemory()
        {
            Memory = new Dictionary<QuestionIdentifierEnum, ParameterCollection>();
        }

        public bool MemoryHasEntry(QuestionIdentifierEnum inQuestionId)
        {
            return Memory.ContainsKey(inQuestionId) && !Memory[inQuestionId].HasAny();
        }

        public ParameterCollection GetMemory(QuestionIdentifierEnum inQuestionId)
        {
            return Memory[inQuestionId];
        }

        #endregion

        #region InstanceResults
        public List<University> GetResults()
        {
            return CurrentState.ResultSet;
        }

        public List<University> GetResults(int inCount)
        {
            return CurrentState.ResultSet.Take(inCount).ToList();
        } 
        #endregion

        private const int NCOUNT = 10;

        internal void UndoLast()
        {
            if(Status != InstanceStatusEnum.WaitingForAnswer)
                throw new Exception("Suggestion system found in incorrect state, aborting...");
            Memory.Remove(CurrentState.Question);
            CurrentState = CurrentState.PreviousState;           
            _currentQuestionIndex-=2;
            SetStatus(InstanceStatusEnum.Ready);
        }
    }
}
