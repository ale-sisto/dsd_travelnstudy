using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.BusinessLogic.SuggestionSystem;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.Presentation.Providers;

namespace StudyAbroad.Presentation
{
    public partial class suggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get user
            var membershipUser = Membership.GetUser() as StudyAbroadMembershipUser;
            User user = null;
            if (membershipUser != null)
                user = BLLFactory.User().GetByUsername(membershipUser.UserName);

            SuggestionSystem.Handler.StartNewInstance(user);
        }


        //Gets next question (questionText and a list of choices)
        [WebMethod]
        public static QuestionDTO GetNextQuestion()
        {
            var question = SuggestionSystem.Handler.GetNextQuestion();
            return new QuestionDTO() {QuestionText = question.QuestionText, AnswerChoices = question.AnswerChoices};
        }




        //If true then everything is ok, you can proceed with next question
        //If false then something happend (either no more questions, or result set empty) 
        //Call GetStatus to find out more if false is returned
        [WebMethod]
        public static bool ProvideAnswer(string answer)
        {
            return SuggestionSystem.Handler.AnswerQuestion(answer);
        }





        //NotInitialized = -1, (start new instance)
        //Ready = 0,  (ready for next question)
        //WaitingForAnswer = 1,  (waiting for answer from the client)
        //ResultSetEmpty = 2, (this will be set if there are no universities returned)
        //ResultSetUnderN = 3, (this will be set if there is less then 10 universities returned)
        //LastQuestion = 4, (this will be set if there are no more questions)
        //Error = 5,   (some other error)
        [WebMethod]
        public static int GetStatus()
        {
            return (int)SuggestionSystem.Handler.GetStatus();
        }


        //Returns top 10 by default, to change add the number in GetInstanceResults(number)
        [WebMethod]
        public static List<UniversitySuggestionDTO> GetResults()
        {


            return SuggestionSystem.Handler.GetInstanceResults().Select(university => new UniversitySuggestionDTO()
                                                                                          {
                                                                                              Name = university.Name, 
                                                                                              Link = "university.aspx?name=" + university.Name,
                                                                                              City = university.ContainedBy.Name,
                                                                                             Country = university.ContainedBy.ContainedBy.Name //university.Info.CountryName
                                                                                          }).ToList();
        }

        [WebMethod]
        public static List<CountryDTO> GetFullCountryList()
        {
             
             Dictionary<string, CountryDTO> fullCountryList = new Dictionary<string, CountryDTO>();
             char[] delimeter = {','}; // used to fix code google problem --> i take only
            // first part of country names

             foreach (University uniObject in SuggestionSystem.Handler.GetInstanceResults(10000))
             {  
                 Location country = uniObject.ContainedBy.ContainedBy;
                 if (country.IsState())
                     country = country.ContainedBy;

                 if (fullCountryList.ContainsKey(country.Code))
                 {
                     fullCountryList[country.Code].UniNumber++;
                     fullCountryList[country.Code].UniNames =
                          fullCountryList[country.Code].UniNames + "\n " + uniObject.Name;
                 }
                 else
                 {
                     fullCountryList.Add(country.Code, new CountryDTO()
                     {
                         Name = country.Name.Split(delimeter)[0],
                         Code = country.Code,
                         UniNumber = 1,
                         UniNames = uniObject.Name
                     });
                 }
                
             }

             return fullCountryList.Values.ToList();
      
        }


        //Undos any changes made by the last question and puts it back in order to go next
        //So for a back button, first call this method then call GetNextQuestion() to get that question again
        [WebMethod]
        public static void UndoLastQuestion()
        {
            SuggestionSystem.Handler.UndoLastQuestion();
        }

        //If for any reason a new instance of the system needs to be started
        [WebMethod]
        public static void StartNewInstance()
        {
            //get user
            var membershipUser = Membership.GetUser() as StudyAbroadMembershipUser;
            User user = null;
            if (membershipUser != null)
                user = BLLFactory.User().GetByUsername(membershipUser.UserName);

            SuggestionSystem.Handler.StartNewInstance(user); 
        }

        //If for any reason the active instance needs to be killed
        [WebMethod]
        public static void KillInstance()
        {
            SuggestionSystem.Handler.Stop();
        }


        //Method used to retrieve the history of questions with user's answer of the actual istance
        //USAGE: if i call it when i'm displaying the first question ==> empty set 
        //USAGE: if i call it while i'm displaying question N ==> it will give me all the N - 1 questions/answers 
        [WebMethod]
        public static List<QuestionDTO> RetrieveHistory()
        {
            //the list of questions and  correlated answers given by the user
            // element 0 will be the first question
            // element 1 the second...so on

            var history = SuggestionSystem.Handler.GetHistory();
            return history.Select(historyItem => new QuestionDTO() {QuestionText = historyItem.QuestionText, UserAnswer = historyItem.Answer}).ToList();
        }
    }
}

public class QuestionDTO
{
    public string QuestionText { get; set; }
    public List<string> AnswerChoices { get; set; }
    public string UserAnswer { get; set; }
}

public class UniversitySuggestionDTO
{
    public string Name { get; set; }
    public string Link { get; set; }
    public string Abstract { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

public class CountryDTO
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int UniNumber { get; set; }
    public string UniNames { get; set; }
}