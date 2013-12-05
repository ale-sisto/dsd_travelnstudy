using System.Web.Security;
using System.Web.Services;
using StudyAbroad.BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.Presentation.Providers;

namespace StudyAbroad.Presentation
{
    public partial class _default : System.Web.UI.Page
    {

        [WebMethod]
        public static List<RecomDTO> GetRecommendedUnis()
        {
            //get user
            var membershipUser = Membership.GetUser() as StudyAbroadMembershipUser;
            if (membershipUser == null)
                throw new Exception("No user is logged in!");

            var user = BLLFactory.User().GetByUsername(membershipUser.UserName);
            //get recommendations
            var recommendations = BusinessLogic.RecommendationSystem.RecommendationSystem.Handler.RecommendUnis(user.Id);


            string tmpCountry;

            List<RecomDTO> rDTO = new List<RecomDTO>();
            foreach (var rec in recommendations)
            {
                
                BLLFactory.University().UpdateShortInfo(rec);
        
                tmpCountry = rec.ContainedBy.ContainedBy.Name;
                if (rec.ContainedBy.ContainedBy.IsState()) tmpCountry += " (United States)";
                rDTO.Add(new RecomDTO()
                {
                    name = rec.Name,
                    link = "university.aspx?name=" + rec.Name,
                    city = rec.City.Name,
                    country = tmpCountry,
                    abstractDescr = rec.Info.Description ?? "No information available...",
                    imageURL = rec.Info.ImageURL
                });
                
            }

            return rDTO;
               
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var euTopUniversities = BLLFactory.University().GetTopByLocationName("Europe", 10);
                var naTopUniversities = BLLFactory.University().GetTopByLocationName("Northern America", 10);
                var worldTopUniversities = BLLFactory.University().GetTopByLocationCode("world", 10);

                //No reason to update if just names are shown, makes the home page load slower
                //BLLFactory.University().UpdateMany(naTopUniversities, false);
                //BLLFactory.University().UpdateMany(euTopUniversities, false);
                //BLLFactory.University().UpdateMany(worldTopUniversities, false);

                // data binding
                BindNAUniversities(naTopUniversities);
                BindEuropeUniversities(euTopUniversities);
                BindWorldUniversities(worldTopUniversities);

                Page.DataBind();
            }
        }

        #region Private Methods

        private void BindWorldUniversities(List<DomainModel.Core.University> universities)
        {
            worldRepeater.DataSource = universities.Select(
                university =>
                    new
                    {
                        Name = university.Name,
                        Link = "university.aspx?name=" + university.Name
                    }).ToList();
        }

        private void BindEuropeUniversities(List<DomainModel.Core.University> universities)
        {
            euRepeater.DataSource = universities.Select(
                university =>
                    new
                    {
                        Name = university.Name,
                        Link = "university.aspx?name=" + university.Name
                    }).ToList();
        }

        private void BindNAUniversities(List<DomainModel.Core.University> universities)
        {
            naRepeater.DataSource = universities.Select(
                university =>
                    new
                    {
                        Name = university.Name,
                        Link = "university.aspx?name=" + university.Name
                    }).ToList();
        } 

        #endregion
    }

    #region DTO

    public class RecomDTO

    {
        //University name
        public string name;
        //Short description (abstract - 200chars, need more?)
        public string abstractDescr;
        //Official website of the university
        public string link;
        //Global rank (world rank)
        public string city;

        public string country;
        public string imageURL;

    }

    #endregion
}