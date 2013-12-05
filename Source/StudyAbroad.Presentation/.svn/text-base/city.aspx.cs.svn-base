using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Core;
using System.Web.Security;

namespace StudyAbroad.Presentation
{
    public partial class city : System.Web.UI.Page
    {
        protected bool HasCommented
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cityName = Request.QueryString["name"];
            string countryName = Request.QueryString["country"];
            var citydto = GetCityDataStatic(cityName, countryName);
            Session["citydto"] = citydto;
            
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.HasCommented = false;
            if (!Page.IsPostBack)
            {
                BindCityReviews();
            }
        }

        # region Private Methods

        
  
        #endregion

        #region Server side response

        
        [WebMethod]
        public static ClimateDTO GetClimate(string cityName, string countryName)
        {
            var country = BLLFactory.Location().GetByName(countryName);
            var city = new City(cityName, country);
            BLLFactory.Location().City().UpdateClimateInfo(city);
            var cat = BLLFactory.Location().City().GetClimateCategory(city);
            return new ClimateDTO()
            {
                climate = city.Info.Climate,
                classification = cat.ToString(),
            };
        }

        [WebMethod]
        public static List<ItemPrice> GetCostOfLife(string cityName, string countryName)
        {
            var country = BLLFactory.Location().GetByName(countryName);
            var city = new City(cityName, country);
            BLLFactory.Location().City().GetCostOfLife(city);
            return city.Info.CostOfLife;
        }

        [WebMethod]
        public static List<ReviewDTO> GetCityReviews(string cityName)
        {
            var reviews = BLLFactory.Reviews().GetAllBySubject(cityName);
            return reviews.Select(review => new ReviewDTO() {comment = review.Comment, date = review.DateTime.Date.ToShortDateString(), rating = review.Rating, username = review.Author.Username}).OrderByDescending(x => x.date).ToList();
        }

        [WebMethod]
        public static void AddReview(string username, string cityName, string comment, int rating)
        {
            BLLFactory.Reviews().Add(username, comment, rating, cityName);
        }

        [WebMethod]
        public static void ModifyReview(string username, string cityName, string comment, int rating)
        {
            BLLFactory.Reviews().Modify(username, cityName, comment, rating);
        }

        [WebMethod]
        public static void DeleteReview(string username, string cityName)
        {
            BLLFactory.Reviews().Delete(username, cityName);
        }

        [WebMethod]
        public static List<UniversityListDTO> GetUniversities(string cityName, string countryName)
        {
            var city = BLLFactory.Location().City().GetByCountry(cityName, countryName);
            var uni = BLLFactory.University().GetTopByLocation(city);
            List<UniversityListDTO> udto = new List<UniversityListDTO>();
            
            foreach (var u in uni)
            {
                udto.Add(new UniversityListDTO()
                {
                    name = u.Name,
                    link = "university.aspx?name=" + u.Name
                }
                    );
            }
            return udto;         
        }

        [WebMethod]
        public static CityDataDTO GetCityData(string cityName, string countryName)
        {
            var citydto = (CityDataDTO) HttpContext.Current.Session["citydto"];
            if (citydto.name != cityName)
                citydto = GetCityDataStatic(cityName, countryName);
                
            return citydto;
        }


        #endregion
        public static CityDataDTO GetCityDataStatic(string cityName, string countryName)
        {
            var country = BLLFactory.Location().GetByName(countryName);
            var city = new City(cityName, country);
            BLLFactory.Location().City().UpdateFullInfo(city);
            string population = "Not Reported";
            Location c = city.ContainedBy;
            if (city.IsCityUsa())
                c = c.ContainedBy;
            if (city.Info.Population.Count > 0)
            {
                population = city.Info.Population.Last().Value.ToString();
            }
            return new CityDataDTO()
            {
                abstractDescr = city.Info.Description,
                imageUrl = city.Info.ImageURL,
                latitude = city.Info.Latitude,
                longitude = city.Info.Longitude,
                name = city.Name,
                country = c.Name,
                region = c.ContainedBy.Name,
                continent = c.ContainedBy.ContainedBy.Name,
                populationCount = population,
                surfaceArea = city.Info.Area,
                wikiUrl = city.Info.FullDescriptionURL,
                countryISOCode = c.Code.ToLower(),
                regionISOCode = c.ContainedBy.Code.ToLower(),
                continentISOCode = c.ContainedBy.ContainedBy.Code.ToLower()
                
            };
        }

        private void BindCityReviews()
        {
            string cityName = Request.QueryString["name"];
            if (!String.IsNullOrEmpty(cityName))
            {
                gvCityReview.DataSource = GetCityReviews(cityName);
                gvCityReview.DataBind();
            }
        }

        protected void gvCityReview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindCityReviews();
        }

        protected void gvCityReview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            gvCityReview.EditIndex = e.NewEditIndex;
            //Bind data
            BindCityReviews();
        }

        protected void gvCityReview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCityReview.EditIndex = -1;
            BindCityReviews();
        }

        protected void gvCityReview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string universityName = Request.QueryString["name"];

            if (e.CommandName == "EmptyAdd")
            {
                GridViewRow emptyRow = gvCityReview.Controls[0].Controls[0] as GridViewRow;
                if (!String.IsNullOrEmpty(universityName))
                {
                    var txtComment = emptyRow.FindControl("txtComment") as TextBox;
                    var inputRating = emptyRow.FindControl("inputrating") as HiddenField;
                    AddReview(User.Identity.Name, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                    BindCityReviews();
                    return;
                }
            }

            if (e.CommandName == "Add")
            {
                if (!String.IsNullOrEmpty(universityName))
                {
                    var txtComment = gvCityReview.FooterRow.FindControl("txtComment") as TextBox;
                    var inputRating = gvCityReview.FooterRow.FindControl("inputrating") as HiddenField;
                    AddReview(User.Identity.Name, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                    BindCityReviews();
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
                    var txtComment = gvCityReview.Rows[gvCityReview.EditIndex].FindControl("txtComment") as TextBox;
                    var inputRating = gvCityReview.Rows[gvCityReview.EditIndex].FindControl("inputrating") as HiddenField;

                    // Update the record 
                    ModifyReview(userName, universityName, txtComment.Text, Convert.ToInt32(inputRating.Value));
                }
            }
        }

        protected void gvCityReview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gvCityReview.EditIndex = -1;
            BindCityReviews();
        }

        protected void gvCityReview_RowDataBound(object sender, GridViewRowEventArgs e)
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

    public class UniversityListDTO
    {
        //University name
        public string name;
        public string link;
    }

    public class ReviewDTO
    {
        public string username;
        public string comment;
        public int rating;
        public string date;
    }

    public class ClimateDTO
    {
        public List<ClimateData> climate;
        public string classification;
    }

    public class CityDataDTO
    {
        public string name;
        public string continent;
        public string region;
        public string country;
        public string abstractDescr;
        public string wikiUrl;
        public string imageUrl;
        public string surfaceArea;
        public string latitude;
        public string longitude;
        public string populationCount;
        public string countryISOCode;
        public string regionISOCode;
        public string continentISOCode;
    }
   
    #endregion
}