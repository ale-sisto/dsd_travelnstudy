using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.Presentation
{
    public partial class explore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Server side response

        /* res will be
         * 
         * [isoCode, cont1, cont2, ...]
         *    0        1       1
         *    
         * if us_state -> length = 7
         * country -> 5
         * subcontinent -> 3
         * continent -> 1
         * */
        [WebMethod]
        public static List<string> RestoreSession(string isoRegionCode)
        {
            var location = BLLFactory.Location().GetByCode(isoRegionCode);
            List<string> res = new List<string>();
            res.Add(location.Code);
            
            while (location.ContainedBy.Code != "world")
            {
                res.Add(location.ContainedBy.Name);
                res.Add(location.ContainedBy.Code);
                location = location.ContainedBy;
            }

            return res;
        }

        [WebMethod]
        public static Dictionary<string, int> GetUniCount(string isoRegionCode)
        {
            var location = BLLFactory.Location().GetByCode(isoRegionCode);
            var containedbyLocation = BLLFactory.Location().GetByContainedBy(location);
            var dictcodecount = new Dictionary<string, int>();
            foreach (var subLocation in containedbyLocation)
            {
                var unis = BLLFactory.University().GetTopByLocation(subLocation, 99999);
                dictcodecount.Add(subLocation.Code + ',' + subLocation.Name, unis.Count);
            }
            return dictcodecount;
        }

        [WebMethod]
        public static List<CityDTO> GetCitiesByCountry(string isoCountryID, int limit = 10)
        {             
            var unis = BLLFactory.University().GetTopByLocationCode(isoCountryID, 99999);
            var citiesUnis = unis.GroupBy(x => x.ContainedBy).ToDictionary(g => g.Key, g => g.Count());
            citiesUnis = citiesUnis.OrderByDescending(x => x.Value).Take(limit).ToDictionary(x => x.Key, x => x.Value);
            var citiesDTO = new List<CityDTO>();
            foreach (var citiesUni in citiesUnis)
            {
                var city = citiesUni.Key.Self as City;
                city.UniversityCount = citiesUni.Value;
                BLLFactory.Location().City().UpdateShortInfo(city);
                citiesDTO.Add(new CityDTO()
                                  {
                                      name = city.Name,
                                      abstractDescr = city.Info.Description ?? "No information available...",
                                      numberOfUniversities = city.UniversityCount,
                                      latitude = city.Info.Latitude,
                                      longitude = city.Info.Longitude,
                                      link = "city.aspx?name="+city.Name+"&country="+city.ContainedBy.Name,
                                  });
            }
            return citiesDTO;
        }

        [WebMethod]
        public static List<UniversityDTO> GetUniversitiesByCity(string cityName, int limit = 5)
        {
            var city = BLLFactory.Location().GetByName(cityName) as City;
            var unis = BLLFactory.University().GetTopByLocation(city, limit);
            BLLFactory.University().UpdateMany(unis, false);
            var unisDTO = new List<UniversityDTO>();
            foreach (var uni in unis)
            {
                unisDTO.Add(new UniversityDTO()
                                {
                                    abstractDescr = uni.Info.Description ?? "No information available...",
                                    name = uni.Name,
                                    rankingPosition = uni.Info.GlobalRank,
                                    link = "university.aspx?name=" + uni.Name
                                });
            }
            return unisDTO;
        }

        [WebMethod]
        public static List<UniversityDTO> GetTopUniversitiesByRegion(string isoRegionID, int limit = 5)
        {
            var unis = BLLFactory.University().GetTopByLocationCode(isoRegionID, limit);
            BLLFactory.University().UpdateMany(unis, false);
            var unisDTO = new List<UniversityDTO>();
            foreach (var uni in unis)
            {
                unisDTO.Add(new UniversityDTO()
                                {
                                    abstractDescr = uni.Info.Description ?? "No information available...",
                                    link = "university.aspx?name=" + uni.Name,
                                    name = uni.Name,
                                    rankingPosition = uni.Info.GlobalRank
                                });
                
            }
            return unisDTO;
        }

        [WebMethod]
        public static string GetLocationNameByIsoCode(string isoLocationID)
        {
            return BLLFactory.Location().GetByCode(isoLocationID).Name;
        }

        #endregion

        #region Client side requests, use dummy data so we append _Dummy to the method name

        [WebMethod]
        public static List<CityDTO> GetCitiesByCountry_Dummy(string isoCountryID)
        {
            return new List<CityDTO>
                       {
                           new CityDTO
                               {
                                   name = "Milano",
                                   abstractDescr = "Abstract for City 1 milano",
                                   numberOfUniversities = 3,
                                   latitude = "nan",
                                   longitude = "nan",
                               },
                           new CityDTO
                               {
                                   name = "Roma",
                                   abstractDescr = "Abstract for City 2 roma",
                                   numberOfUniversities = 6,
                                   latitude = "nan",
                                   longitude = "nan",
                               },
                           new CityDTO
                               {
                                   name = "Torino",
                                   abstractDescr = "Abstract for City 3 tornio",
                                   numberOfUniversities = 9,
                                   latitude = "nan",
                                   longitude = "nan",
                               }
                       };
        }

        [WebMethod]
        public static List<UniversityDTO> GetUniversitiesByCity_Dummy(string cityName, string isoCountryID)
        {
            return new List<UniversityDTO>
                       {
                           new UniversityDTO
                               {
                                   name = "University 1",
                                   abstractDescr = "Abstract for University 1",
                                   link = "http://university1",
                                   rankingPosition = 2
                               },
                           new UniversityDTO
                               {
                                   name = "University 2",
                                   abstractDescr = "Abstract for University 2",
                                   link = "http://university2",
                                   rankingPosition = 4
                               },
                           new UniversityDTO
                               {
                                   name = "University 3",
                                   abstractDescr = "Abstract for University 3",
                                   link = "http://university3",
                                   rankingPosition = 6
                               }
                       };
        }

        [WebMethod]
        public static List<UniversityDTO> GetTopUniversitiesByRegion_Dummy(string isoRegionID)
        {
            return new List<UniversityDTO>
                       {
                           new UniversityDTO
                               {
                                   name = "University 1",
                                   abstractDescr = "Abstract for University 1",
                                   link = "http://university1",
                                   rankingPosition = 2
                               },
                           new UniversityDTO
                               {
                                   name = "University 2",
                                   abstractDescr = "Abstract for University 2",
                                   link = "http://university2",
                                   rankingPosition = 4
                               },
                           new UniversityDTO
                               {
                                   name = "University 3",
                                   abstractDescr = "Abstract for University 3",
                                   link = "http://university3",
                                   rankingPosition = 6
                               }
                       };
        }
    }

    #endregion

    #region DTOs

    public class CityDTO
    {
        //City name
        public string name;
        //Short description (abstract - 200chars, need more?)
        public string abstractDescr;
        //Number of universities in the city
        public int numberOfUniversities;
        public string latitude;
        public string longitude;
        public string link;
    }

    public class UniversityDTO
    {
        //University name
        public string name;
        //Short description (abstract - 200chars, need more?)
        public string abstractDescr;
        //Official website of the university
        public string link;
        //Global rank (world rank)
        public int globalRank;
        //Location rank (currenty selected location rank)
        public int rankingPosition;
    }

    #endregion

}