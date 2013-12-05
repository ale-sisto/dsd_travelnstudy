using System;
using System.Web;
using System.Web.Services;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.Presentation
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Request.Url.AbsolutePath);
            if (Request.Url.AbsolutePath == "/")
                Response.Redirect("/default.aspx",true);
           
        }


        [WebMethod]
        public static bool CheckUsername(string username)
        {
            return BusinessLogic.Factories.BLLFactory.User().CheckUsernameAvailability(username);
        }

        [WebMethod]
        public static bool AddUser(string username, string password, string firstname, string lastname, string countryname)
        {
            try
            {
                BusinessLogic.Factories.BLLFactory.User().AddUser(username, password, firstname, lastname, countryname);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public static bool LogIn(string username, string password)
        {
            var user = BusinessLogic.Factories.BLLFactory.User().GetUserCredentials(username, password);
            if (user == null)
            {
                HttpContext.Current.Session["LoggedIn"] = false;
                HttpContext.Current.Session["User"] = null;
                return false;
            }
            else
            {
                HttpContext.Current.Session["LoggedIn"] = true;
                HttpContext.Current.Session["User"] = user;
                return true;
            }
        }

        [WebMethod]
        public static void LogOut()
        {
            HttpContext.Current.Session["LoggedIn"] = false;
            HttpContext.Current.Session["User"] = null;
        }

        [WebMethod]
        public static bool IsLoggedIn()
        {
            return (bool)HttpContext.Current.Session["LoggedIn"];
        }

        [WebMethod]
        public static string GetLoggedInUser()
        {
            if (IsLoggedIn())
                return (HttpContext.Current.Session["User"] as User).Name;
            else
                throw new Exception("Not logged in!");
        }

    }

}