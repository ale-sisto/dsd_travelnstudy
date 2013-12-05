using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.Presentation.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyAbroad.Presentation.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            
            if (!Page.IsPostBack)
            {
                BindCountries();
                Page.DataBind();
            }
            
        }

        private void BindCountries()
        {
            var countries = BLLFactory.Location().Country().GetAll();            
            var ddlCountry = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Country") as DropDownList;
            if (ddlCountry != null)
            {
                ddlCountry.DataSource = countries;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var txtUserName = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName") as TextBox;
            var txtFirstName = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FirstName") as TextBox;
            var txtLastName = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("LastName") as TextBox;
            var txtPassword = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Password") as TextBox;
            var ddlCountry = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Country") as DropDownList;

            MembershipCreateStatus status;
            StudyAbroadMembershipProvider provider = new StudyAbroadMembershipProvider();


            var membershipUser = provider.CreateUser(txtUserName.Text, txtPassword.Text,
                                                                         txtFirstName.Text, txtLastName.Text,
                                                                         ddlCountry.SelectedItem.Text, out status);

            if (status != MembershipCreateStatus.Success)
            {
                CreateUserErrorEventArgs args = new CreateUserErrorEventArgs(status);
                RegisterUser_CreateUserError(this, args);
                return;
            }
            
            // Let's move to the complete step if the user has been successfully created
            if (membershipUser != null)
            {
                RegisterUser.MoveTo(this.RegisterUserWizardComplete);
            }                
        }

        protected void RegisterUser_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {
            ErrorMessage.Visible = true;
            switch (e.CreateUserError)
            {
                case MembershipCreateStatus.InvalidPassword:
                    var provider = new StudyAbroadMembershipProvider();
                    ErrorMessage.Text = String.Format(RegisterUser.InvalidPasswordErrorMessage, provider.MinRequiredPasswordLength);
                    break;

                case MembershipCreateStatus.DuplicateUserName:
                      ErrorMessage.Text = RegisterUser.DuplicateUserNameErrorMessage;
                    break;

                default:
                      ErrorMessage.Text = RegisterUser.UnknownErrorMessage;
                    break;
            }            
        }

        protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}