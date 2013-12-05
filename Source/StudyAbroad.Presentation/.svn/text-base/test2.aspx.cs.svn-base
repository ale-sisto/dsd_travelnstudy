using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudyAbroad.Presentation
{
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.HasCommented = false;
            //AddReview("jhualpa", "Politecnico di Milano", "Review 1", 1);
            //AddReview("rootu", "Politecnico di Milano", "Review 2", 2);
            //AddReview("testu", "Politecnico di Milano", "Review 3", 3);      
            if (!Page.IsPostBack)
            {
                BindUniversityReviews();
            }
        }

        private void BindUniversityReviews()
        {
            gvUniReview.DataSource = GetUniversityReviews("Politecnico di Milano");
            gvUniReview.DataBind();
        }

        [WebMethod]
        public static List<ReviewDTO> GetUniversityReviews(string universityName)
        {
            var reviews = BLLFactory.Reviews().GetAllBySubject(universityName);
            return reviews.Select(review => new ReviewDTO() { comment = review.Comment, date = review.DateTime.Date.ToShortDateString(), rating = review.Rating, username = review.Author.Username }).OrderBy( x => x.date).ToList();
        }

        //[WebMethod]
        //public static UserDataDTO GetUserData()
        //{
        //    UserDataDTO userData = new UserDataDTO();
        //    try
        //    {
        //        userData.hasAdminRole = Roles.IsUserInRole("Admin");
        //        userData.userName = Membership.GetUser().UserName; 
        //    }
        //    catch (Exception)
        //    {
        //        userData.userName = String.Empty;
        //        userData.hasAdminRole = false;
        //    }

        //    return userData; 
        //}        

        [WebMethod]
        public static void AddReview(string username, string universityName, string comment, int rating)
        {
            BLLFactory.Reviews().Add(username, comment, rating, universityName);
        }

        [WebMethod]
        public static void ModifyReview(string username, string universityName, string comment, int rating)
        {
            BLLFactory.Reviews().Modify(username, universityName, comment, rating);
        }

        [WebMethod]
        public static void DeleteReview(string username, string universityName)
        {
            BLLFactory.Reviews().Delete(username, universityName);
        }

        protected void gvUniReview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
            {
                string boundUser = (e.Row.DataItem as ReviewDTO).username;
                if (User.Identity.Name == boundUser || Roles.IsUserInRole("Admin"))
                {
                    var btnEdit = e.Row.FindControl("btnEdit") as Button;
                    var btnDelete = e.Row.FindControl("btnDelete") as Button;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                }
                if (User.Identity.Name == boundUser)
                {
                    this.HasCommented = true;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (!HasCommented && User.Identity.IsAuthenticated)
                {
                    var hldAddReview = e.Row.FindControl("hldAddReview") as PlaceHolder;
                    hldAddReview.Visible = true;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && gvUniReview.EditIndex == e.Row.RowIndex)
            {
                this.HasCommented = true;
                //Binding countries when editing               
                //var countries = BLLFactory.Location().Country().GetAll();
                //var user = Membership.GetUser() as StudyAbroadMembershipUser;
                //var ddlCountry = e.Row.FindControl("Country") as DropDownList;
                //if (ddlCountry != null)
                //{
                //    ddlCountry.DataSource = countries;
                //    ddlCountry.DataBind();
                //    ddlCountry.SelectedValue = user.CountryName;
                //}
            }

        }

        protected bool HasCommented
        {
            get;
            private set;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //var istar = Page.FindControl("istar") as HtmlGenericControl;
            //string fer =istar.Attributes["data-rating"].ToString();
           
        }

        protected void gvUniReview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string universityName = Request.QueryString["name"];
            if (String.IsNullOrEmpty(universityName))
            {
                e.Cancel = true; 
            }
            else
            {
                DeleteReview(User.Identity.Name, universityName);
                BindUniversityReviews();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string universityName = Request.QueryString["name"];
            if (String.IsNullOrEmpty(universityName))
            {
                return;
            }
            else
            {
                var txtComment = gvUniReview.FooterRow.FindControl("txtComment") as TextBox;
                var inputRating = gvUniReview.FooterRow.FindControl("inputrating") as HiddenField;
                AddReview(User.Identity.Name, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                BindUniversityReviews();
            }
        }

        protected void RatingCheck(object source, ServerValidateEventArgs args)
        {
            var inputRating = gvUniReview.FooterRow.FindControl("inputrating") as HiddenField;
            if (!String.IsNullOrEmpty(inputRating.Value))
            {
                args.IsValid = true;
                return;
            }
            args.IsValid = false;
        }

        protected void gvUniReview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            gvUniReview.EditIndex = e.NewEditIndex;
            //Bind data
            BindUniversityReviews();
        }

        protected void gvUniReview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUniReview.EditIndex = -1;
            BindUniversityReviews();
        }
    }
}