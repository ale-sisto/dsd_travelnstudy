using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SearchEngine
{
    public class SearchResult
    {
            public string ResultString { get; set; }
            public double Score { get; set; }
            public string Link { get; set; }
            public Enums.SearchedBy SearchedBy { get; set; }
            public DomainModel.Core.Location Location { get; set; }

            public SearchResult(string inSearchString, double inScore, Enums.SearchedBy inFind, DomainModel.Core.Location inLocation)
            {
                ResultString = inSearchString;
                Score = inScore;
                SearchedBy = inFind;
                Location = inLocation;
                if (inFind == Enums.SearchedBy.UniversityName)
                {
                    Link = "university.aspx?name=" + ResultString;
                }
                else
                {
                    Link = "city.aspx?name=" + ResultString + "&country=" + inLocation.ContainedBy.Name;
                }
            }
      }

}
