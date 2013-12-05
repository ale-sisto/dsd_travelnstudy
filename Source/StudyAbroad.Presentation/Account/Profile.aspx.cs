using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Enums;
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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                IdentifyProfile();                
                BindProfileData();                
            }
            
        }

        private void IdentifyProfile()
        {
            if (User.IsInRole("ADMIN"))
            {
                var profileUsername = Request.QueryString["u"];
                if (!String.IsNullOrEmpty(profileUsername))
                {
                    if (Membership.GetUser(profileUsername) != null)
                    {
                        Session["profileUsername"] = profileUsername;
                        btnBack.Visible = true;
                        ChangePassword.Visible = false;
                        DeleteUser.Visible = false;
                        return;
                    }
                }
            }
            Session["profileUsername"] = User.Identity.Name;
        }

        private void BindProfileData()
        {
            var user = Membership.GetUser(Session["profileUsername"] as string) as StudyAbroadMembershipUser;
            gvPreferences.DataSource = new Object[] {
                                                        new
                                                        {
                                                            FirstName = user.FirstName,
                                                            LastName = user.LastName,
                                                            CountryName = user.CountryName
                                                        }                
                                                    };
            gvPreferences.DataBind();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Membership.DeleteUser(User.Identity.Name);
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Abandon();
            
            // Invalidate the Cache on the Client Side
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            // Invalidate the Cache on the Server Side
            Response.Clear();
            Response.Redirect("~/");
        }

        protected void gvPreferences_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            gvPreferences.EditIndex = e.NewEditIndex;        
            //Bind data
            BindProfileData();
        }

        private void BindCountries()
        {
            var user = Membership.GetUser(Session["profileUsername"] as string) as StudyAbroadMembershipUser;
            var countries = BLLFactory.Location().Country().GetAll();
            var txtFirstName = this.gvPreferences.Rows[this.gvPreferences.EditIndex].FindControl("FirstName") as TextBox;
            var txtLastName = this.gvPreferences.Rows[this.gvPreferences.EditIndex].FindControl("LastName") as TextBox;
            var ddlCountry = this.gvPreferences.Rows[this.gvPreferences.EditIndex].FindControl("Country") as DropDownList;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            if (ddlCountry != null)
            {
                ddlCountry.DataSource = countries;                
                ddlCountry.DataBind();
                ddlCountry.SelectedValue = user.CountryName;
            }
        }

        protected void gvPreferences_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvPreferences.EditIndex == e.Row.RowIndex)
            {
                //Binding countries when editing               
                var countries = BLLFactory.Location().Country().GetAll();
                var user = Membership.GetUser(Session["profileUsername"] as string) as StudyAbroadMembershipUser;
                var ddlCountry = e.Row.FindControl("Country") as DropDownList;
                if (ddlCountry != null)
                {
                    ddlCountry.DataSource = countries;
                    ddlCountry.DataBind();
                    ddlCountry.SelectedValue = user.CountryName;
                }
            }
        }

        protected void gvPreferences_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPreferences.EditIndex = -1;
            BindProfileData();
        }

        protected void gvPreferences_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string firstName = (gvPreferences.Rows[e.RowIndex].FindControl("FirstName") as TextBox).Text;
                string lastName = (gvPreferences.Rows[e.RowIndex].FindControl("LastName") as TextBox).Text;
                string countryName = (gvPreferences.Rows[e.RowIndex].FindControl("Country") as DropDownList).SelectedItem.Value;

                var user = Membership.GetUser(Session["profileUsername"] as string) as StudyAbroadMembershipUser;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.CountryName = countryName;
                Membership.UpdateUser(user);

                gvPreferences.EditIndex = -1;
                BindProfileData();
                profSuccess.Visible = true;
            }
            catch (Exception err)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(err);
                profError.Text = err.Message;
                passError.Visible = true;                
            }  
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                Membership.GetUser(Session["profileUsername"] as string).ChangePassword(this.CurrentPassword.Text, this.NewPassword.Text);
                passSuccess.Visible = true;
            }
            catch (Exception err)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(err);
                passError.Text = err.Message;
                passError.Visible = true;                
            }            
        }             
    }
}