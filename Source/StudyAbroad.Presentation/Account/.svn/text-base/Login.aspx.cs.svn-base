using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyAbroad.Presentation.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {                
                RegisterHyperLink.NavigateUrl = "Register.aspx";
                if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath.StartsWith("/Account"))
                {
                    Session["previous"] = "/default.aspx";
                }
                else
                {
                    Session["previous"] = Request.UrlReferrer.ToString();                  
                }
            }
        }

        protected void LoginUSer_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect(Session["previous"].ToString());
        }       
    }
}