using StudyAbroad.BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyAbroad.Presentation
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["q"] == null && Cache["q"] == null)
            {
                searchResults.Visible = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                if (IsNewSearch(Request.Form["q"]))
                {
                    Cache["q"] = Request.Form["q"];                    
                }                

                gvResults.PageIndex = 0;
                BindSearchResults();
                searchResults.Visible = true;
            }
            else
            {
                if (IsNewSearch(Request.Form["q"]))
                {
                    Cache["q"] = Request.Form["q"];
                    gvResults.PageIndex = 0;
                    BindSearchResults();
                    searchResults.Visible = true;
                }                
            }
        }

        private bool IsNewSearch(string searchTerm)
        {
            if (!String.IsNullOrEmpty(searchTerm))
            {
                if (Cache["q"] == null || Cache["q"].ToString() != searchTerm)
                {
                    return true;
                }                
            }
            return false;
        }

        private void BindSearchResults()
        {
            var results = BLLFactory.SearchEngine().SearchLocation(Cache["q"].ToString(), 15);
            Cache["results"] = (from r in results
                                orderby r.Score descending
                                select new
                                {
                                    Link = r.Link,
                                    ResultString = r.ResultString,
                                    City = r.SearchedBy.ToString() == "CityName" ? r.Location.Name : r.Location.ContainedBy.Name,
                                    Country = r.SearchedBy.ToString() == "CityName" ? r.Location.ContainedBy.Name : r.Location.ContainedBy.ContainedBy.Name,
                                    Region = r.SearchedBy.ToString() == "CityName" ? r.Location.ContainedBy.ContainedBy.Name : r.Location.ContainedBy.ContainedBy.ContainedBy.Name,
                                    Continent = r.SearchedBy.ToString() == "CityName" ? r.Location.ContainedBy.ContainedBy.ContainedBy.Name : r.Location.ContainedBy.ContainedBy.ContainedBy.ContainedBy.Name,
                                    Type = r.SearchedBy.ToString() == "CityName" ? "images/search/location-icon.jpg" : "images/search/university-icon.jpg"
                                }).ToList();

            gvResults.DataSource = Cache["results"];
            gvResults.DataBind();            
         }         

        protected void gvResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResults.PageIndex = e.NewPageIndex;            
            gvResults.DataSource = Cache["results"];
            gvResults.DataBind();
   

            // just after databound we can access the objects in the GridView
            if (gvResults.PageIndex > 0)
            {
                //TODO FIX
            }
            else
            {
                //TODO FIX
            }
            if (gvResults.PageIndex < 1)
            {
                //TODO FIX
            }
            else
            {
                //TODO FIX
            }
        }
    }
}