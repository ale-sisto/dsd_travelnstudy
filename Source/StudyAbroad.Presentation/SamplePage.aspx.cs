using System;
using System.Collections.Generic;
using System.Web.Services;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.BusinessLogic.SuggestionSystem;
using StudyAbroad.DomainModel;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.Presentation
{
    public partial class SamplePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Gets next question (questionText and a list of choices)
        [WebMethod]
        public static QuestionDTO GetNextQuestion()
        {
            var question = SuggestionSystem.Handler.GetNextQuestion();
            return new QuestionDTO() { QuestionText = question.QuestionText, AnswerChoices = question.AnswerChoices };
        }

        /// <summary>
        /// Test to see how easy it is to send data to the client, we can just send objects (no need for JSON at all)
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<University> GetTopUnis(string inCode)
        {
            return BLLFactory.University().GetTopByLocationCode(inCode);
        }

        [WebMethod]
        public static void DataBaseTest(bool reCreate, bool initData)
        {
            BusinessLogic.Framework.DBHandler.InitDatabase(reCreate, initData);
        }
    }
}