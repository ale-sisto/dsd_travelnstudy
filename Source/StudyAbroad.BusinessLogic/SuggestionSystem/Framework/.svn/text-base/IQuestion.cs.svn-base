using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Filters;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Framework
{
    public abstract class Question
    {
        //Each question has an Id that identifies it and a question parameter
        public QuestionIdentifierEnum Id { get; set; }
        public ParametersEnum Parameter { get; set; }

        public Question(QuestionIdentifierEnum inQuestionId, ParametersEnum inQuestionParameter)
        {
            Id = inQuestionId;
            Parameter = inQuestionParameter;
        }

        public string GetQuestionString(Instance inCurrentInstance)
        {
            return CreateQuestionString(inCurrentInstance);
        }
        //Formulate the question (questionID, questionText, possibleAnswerChoices)
        //A question choices can be effected by other previous questions 
        //(example, a region selection should offer limited choices if a continent was selected first)
        //These possible dependancies should be taken into account here 
        //(that is why the current instance where all the questions asked is passed)
        public QuestionRequest CreateRequest(Instance inCurrentInstance)
        {
            return new QuestionRequest(Id, CreateQuestionString(inCurrentInstance), CreateChoicesList(inCurrentInstance));
        }

        protected abstract string CreateQuestionString(Instance inCurrentInstance);
        protected virtual List<string> CreateChoicesList(Instance inCurrentInstance)
        {
            return new List<string>() {"Any"};
        }

        //Store the given response into the memory of the current instance of the suggestion system
        //Get the filter and execute it
        public InstanceState ProcessResponse(QuestionResponse inResponse, Instance inCurrentInstance)
        {
            StoreResponse(inResponse, inCurrentInstance);
            var filter = inResponse.Choice == "Any" ? new NoFilter(inCurrentInstance) : GetFilter(inCurrentInstance);
            return filter.Execute(inCurrentInstance);
        }

        //Stores the response into instance memory (memory[questionId] = parametercollection)
        private void StoreResponse(QuestionResponse inResponse, Instance inCurrentInstance)
        {
            inCurrentInstance.GetMemory(Id).AddParameter(Parameter, inResponse.Choice);
        }

        //Gets the filter for the specific question
        protected abstract Filter GetFilter(Instance inCurrentInstance);

        public abstract Explanation GetExplanation(University inUniversity, Instance inCurrentInstance);
    }
}
