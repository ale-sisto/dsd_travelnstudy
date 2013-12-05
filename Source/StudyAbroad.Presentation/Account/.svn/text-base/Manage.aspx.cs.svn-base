using StudyAbroad.BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyAbroad.Presentation.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(this.lnkMasterDelete);
  
            if (!Page.IsPostBack)
            {
                BindUsers();
            }
        }      

        private void BindUsers()
        {
            var users = BLLFactory.User().GetByRole(DomainModel.Enums.UserRoleEnum.User);
            gvUsers.DataSource = users;
            gvUsers.DataBind();
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton link = e.Row.FindControl("lnkDelete") as LinkButton;
                link.Attributes.Add("onclick", "javascript:username='" +
                DataBinder.Eval(e.Row.DataItem, "Username") + "';$('#cdialog').modal('show');return false");
            }
        }

        protected void lnkMasterDelete_Click(object sender, EventArgs e)
        {
            var userName = Request["__EVENTARGUMENT"]; 
            if (String.IsNullOrEmpty(userName))
            {
                return;
            }
            else
            {
                Membership.DeleteUser(userName);
                BindUsers();
            }
        }
        
    }
}