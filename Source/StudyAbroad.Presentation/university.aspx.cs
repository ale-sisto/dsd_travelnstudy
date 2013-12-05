using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyAbroad.BusinessLogic.Factories;
using System.Collections.Specialized;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.Presentation.Helpers;
using System.Web.Security;

namespace StudyAbroad.Presentation
{
    public partial class university : System.Web.UI.Page
    {
        protected bool HasCommented
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.HasCommented = false;
            if (!Page.IsPostBack)
            {
                BindUniversityReviews();               
            }
        }


        #region Server side response

        [WebMethod]
        public static List<RegionRankDTO> GetRegionRanks(string uniName)
        {
            var uni = BLLFactory.University().GetByName(uniName);
            var regionRanks = BLLFactory.University().GetAllLocationsRank(uni);
            return regionRanks.Select(keyValuePair => new RegionRankDTO() {regionName = keyValuePair.Key, rank = keyValuePair.Value}).ToList();
        }


        [WebMethod]
        public static List<String> GetAVGCosts(string uniName)
        {
            //TODO: use dictionary instead of a list of strings
            /* The result is a list of 5 elements: region_name, under/region, post/region, country_name, under/country, post/country*/
            var uni = BLLFactory.University().GetByName(uniName);
            List<String> res = new List<String>();
            res.AddRange(BLLFactory.University().getAVGCosts(uni));
            return res;
        }

        [WebMethod]
        public static List<String> GetAVGRanks(string uniName)
        {
            /* The result is a list of 4 strings: region_name, region, country_name, country*/
            var uni = BLLFactory.University().GetByName(uniName);
            List<String> res = new List<String>();
            res.AddRange(BLLFactory.University().getAVGRank(uni));
            return res;
        }

        [WebMethod]
        public static List<ReviewDTO> GetUniversityReviews(string universityName)
        {
            var reviews = BLLFactory.Reviews().GetAllBySubject(universityName);
            return reviews.Select(review => new ReviewDTO() { comment = review.Comment, date = review.DateTime.Date.ToShortDateString(), rating = review.Rating, username = review.Author.Username }).OrderByDescending(x => x.date).ToList();
        }

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

        [WebMethod]
        public static UniversityDataDTO GetUniversityData(string universityName)
        {
            var uni = BLLFactory.University().GetByName(universityName);
            BLLFactory.University().UpdateFullInfo(uni);

            //get right country name for USA universities
            var locationObject = uni.ContainedBy.ContainedBy; // get State or Country
            var linkcountry = locationObject.Name;
            if (locationObject.IsState()) 
                // if there is a state level go one level above
                locationObject = locationObject.ContainedBy;

            return new UniversityDataDTO()
                       {
                           abstractDescr = uni.Info.Description,
                           academicStructure = uni.Info.AcademicStructure,
                           address = uni.Info.Address,
                           cityName = uni.ContainedBy.Name,
                           countryName = locationObject.Name,
                           departments = uni.Info.Departments,
                           englishName = uni.Info.EnglishName,
                           foundationYear = uni.Info.FoundationYear,
                           globalRank = uni.Info.GlobalRank,
                           imageUrl = FormatHelper.FormatImageURL(uni.Info.ImageURL),
                           intStudentsPostGradPrice = uni.Info.InternationalStudentsPostGraduatePrice,
                           intStudentsGradPrice = uni.Info.InternationalStudentsUnderGraduatePrice,
                           localStudentsGradPrice = uni.Info.LocalStudentsUnderGraduatePrice,
                           localStudentsPostGradPrice = uni.Info.LocalStudentsPostGraduatePrice,
                           motto = uni.Info.Motto,
                           name = uni.Name,
                           officialWebUrl = uni.Info.OfficalWebsite,
                           phone = uni.Info.Phone,
                           totalEnrollment = uni.Info.TotalEnrollment,
                           wikiUrl = uni.Info.WikipediaUri,
                           gender = uni.Info.Gender,
                           admittedPercentage = uni.Info.SelectionPercentage,
                           numOfUndergraduate = uni.Info.NumOfUndergraduates,
                           numOfPostgraduate = uni.Info.NumOfPostgraduates,
                           facebookUrl = uni.Info.FacebookUri,
                           linkedinUrl= uni.Info.LinkedInUri,
                           twitterUrl = uni.Info.TwitterUri,
                           youtubeUrl = uni.Info.YouTubeUri,
                           rankingPosition = uni.Info.GlobalRank,
                           admissionSelection = uni.Info.AdmissionSelection,
                           admissionInternational = uni.Info.InternationalStudents,
                           controlType = uni.Info.ControlType,
                           countryLink = linkcountry,
                           areasOfStudies = uni.Info.AreasOfStudies,
                       };
        }     

        #endregion

        private void BindUniversityReviews()
        {
            string universityName = Request.QueryString["name"];
            if (!String.IsNullOrEmpty(universityName))
            {
                gvUniReview.DataSource = GetUniversityReviews(universityName);                
                gvUniReview.DataBind();
            }
        }

        protected void gvUniReview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            BindUniversityReviews();            
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

        protected void gvUniReview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string universityName = Request.QueryString["name"];

            if (e.CommandName == "EmptyAdd")
            {
                GridViewRow emptyRow = gvUniReview.Controls[0].Controls[0] as GridViewRow;
                if (!String.IsNullOrEmpty(universityName))
                {
                    var txtComment = emptyRow.FindControl("txtComment") as TextBox;
                    var inputRating = emptyRow.FindControl("inputrating") as HiddenField;
                    AddReview(User.Identity.Name, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                    BindUniversityReviews();
                    return;
                }
            }

            if (e.CommandName == "Add")
            {                
                if (!String.IsNullOrEmpty(universityName))
                {
                    var txtComment = gvUniReview.FooterRow.FindControl("txtComment") as TextBox;
                    var inputRating = gvUniReview.FooterRow.FindControl("inputrating") as HiddenField;
                    AddReview(User.Identity.Name, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                    BindUniversityReviews();
                    return;
                }
            }

            if (e.CommandName == "Delete")
            {
                if (!String.IsNullOrEmpty(universityName))
                {
                    string userName = e.CommandArgument.ToString();
                    // Delete the record 
                    DeleteReview(userName, universityName);
                    return;
                }
            }

            if (e.CommandName == "Update")
            {
                if (!String.IsNullOrEmpty(universityName))
                {
                    string userName = e.CommandArgument.ToString();
                    var txtComment = gvUniReview.Rows[gvUniReview.EditIndex].FindControl("txtComment") as TextBox;
                    var inputRating = gvUniReview.Rows[gvUniReview.EditIndex].FindControl("inputrating") as HiddenField;

                    // Update the record 
                    ModifyReview(userName, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                }
            }
        }

        protected void gvUniReview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gvUniReview.EditIndex = -1;
            BindUniversityReviews();
        }

        protected void gvUniReview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                string boundUser = (e.Row.DataItem as ReviewDTO).username;
                if (User.Identity.Name == boundUser || Roles.IsUserInRole("Admin"))
                {
                    var btnEdit = e.Row.FindControl("btnEdit") as Button;
                    var btnDelete = e.Row.FindControl("btnDelete") as Button;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnEdit.Attributes.Add("onclick", "$(this).closest('.controls').hide()");
                    btnDelete.Attributes.Add("onclick", "return ConfirmReviewDeletion(this);");
                }
                if (User.Identity.Name == boundUser)
                {
                    this.HasCommented = true;
                }
            }

            if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) ||
                (e.Row.RowState == DataControlRowState.Edit))
            {
                var btnSave = e.Row.FindControl("btnSave") as Button;
                btnSave.Attributes.Add("onclick", "return ValidateReview(this);");
                string boundUser = (e.Row.DataItem as ReviewDTO).username;
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
                    var btnAdd = e.Row.FindControl("btnAdd") as Button;
                    btnAdd.Attributes.Add("onclick", "return ValidateReview(this);");
                }
            }

            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var hldAddReview = e.Row.FindControl("hldAddReview") as PlaceHolder;
                    hldAddReview.Visible = true;
                    var btnAdd = e.Row.FindControl("btnAdd") as Button;
                    btnAdd.Attributes.Add("onclick", "return ValidateReview(this);");
                }
                else
                {
                    var hldNoReview = e.Row.FindControl("hldNoReview") as PlaceHolder;
                    hldNoReview.Visible = true;
                }
            }
        }
    }

    #region DTOs
    public class RegionRankDTO
    {
        public string regionName;
        public int rank;
    }


    public class UniversityDataDTO
    {
        public string name;
        public string abstractDescr;
        public string cityLink;
        public int rankingPosition;
        public List<string> academicStructure;
        public string address;
        public string cityName;
        public string countryName;
        public List<string> departments;
        public string englishName;
        public string foundationYear;
        public string wikiUrl;
        public int globalRank;
        public string imageUrl;
        public string intStudentsPostGradPrice;
        public string intStudentsGradPrice;
        public string localStudentsPostGradPrice;
        public string localStudentsGradPrice;
        public string motto;
        public string phone;
        public string officialWebUrl;
        public string totalEnrollment;
        public string gender;
        public string admittedPercentage;
        public int numOfUndergraduate;
        public int numOfPostgraduate;
        public string facebookUrl;
        public string linkedinUrl;
        public string twitterUrl;
        public string youtubeUrl;
        public string admissionSelection;
        public string admissionInternational;
        public string controlType;
        public string countryLink;
        public AreasOfStudies areasOfStudies;
    }

    #endregion

     

  
}