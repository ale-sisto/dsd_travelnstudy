using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DynamicLoading.Core
{
    /// <summary>
    /// Universities loader/parser
    /// </summary>
    public class IcuOrgUniversityLoader : Loader<University>
    {
        public IcuOrgUniversityLoader(LoaderConfiguration inConfiguration)
            : base(inConfiguration)
        {
        }

        //Load top #count universities in the world
        public override void Load(List<University> items)
        {
            //Fetch top count
            var webGet = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.Default
            };

            HtmlDocument document;
            try
            {
                document = webGet.Load(Configuration.GetParameter("Uri"));
            }
            catch
            {
                try
                {
                    document = webGet.Load(Configuration.GetParameter("Uri"));
                }
                catch (WebException ex)
                {
                    throw new Exception("Cannot load webpage");
                }
            }
            

            //Parse
            var table = document.DocumentNode.SelectSingleNode("/html/body/table[5]/tr/td/table");
            HtmlNodeCollection trs;
            try
            {
                trs = table.SelectNodes("tr");
            }
            catch (Exception e)
            {
                if (e.Message == "Object reference not set to an instance of an object.")
                    throw new Exception("Uri does not lead to university list! Check URI");
                throw;
            }      
            if (trs.Count >= 50)
            {
                foreach (var tr in trs)
                {
                    var link = tr.SelectSingleNode("td/a").Attributes["href"].Value;
                    var name = HtmlEntity.DeEntitize(tr.SelectSingleNode("td/a").InnerHtml);

                    var countryName = HtmlEntity.DeEntitize(tr.SelectSingleNode("td[2]/h5").InnerHtml);
                    var university = new University(name, countryName);
                    university.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.UniversityInfo, link);
                    items.Add(university);
                }
            }
            else
            {
                table = document.DocumentNode.SelectSingleNode("/html/body/table[6]");
                trs = table.SelectNodes("tr");
                trs.Remove(0);
                trs.Remove(trs.Count-1);
                trs.Remove(trs.Count-1);
                foreach (var tr in trs)
                {
                    var englishName = tr.SelectSingleNode("td/a").Attributes["title"].Value;
                    var link = tr.SelectSingleNode("td/a").Attributes["href"].Value;
                    var name = HtmlEntity.DeEntitize(tr.SelectSingleNode("td/a").InnerHtml.Replace("&#154;", "š"));

                    var cityNameText = HtmlEntity.DeEntitize(tr.SelectSingleNode("td[2]/h6").InnerHtml.Replace("&#154;", "š").Replace("&#158;", "ž"));
                    var cityName = cityNameText.Trim(new[] {'.', ' '});

                    var countryName = Configuration.GetParameter("CountryName");

                    var university = new University(name, englishName, cityName, countryName);
                    university.RegisterDataSource(InfoDomainEnum.IcuOrg, InfoCategoryEnum.UniversityInfo, link);
                    items.Add(university);
                }
            }
        }

        public void UpdateFull(University inUniversity)
        {
            //Fetch details
            var webGet = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.Default
            };

            HtmlDocument document;
            try
            {
                document = webGet.Load(Configuration.GetParameter("Uri"));
            }
            catch
            {
                try
                {
                    document = webGet.Load(Configuration.GetParameter("Uri"));
                }
                catch (WebException ex)
                {
                    throw new Exception("Cannot load webpage");
                }
            }

            //Parsing
            //4Icu WebPage  returnes "Not reported" string when they not have particular data. 
            //I also use it situation when usually design is changed or when Xpath not exists! It can bi changed during review of this class.

            try //Foundation Year
            {
                var foundationYearNodes = document.DocumentNode.SelectNodes("//html/body/table[5]/tr/td");
                // This part can (maybe) be written using LINQ but I have some problems with that. For now... it is foreach because it works well
                foreach (var node in foundationYearNodes)
                {
                    var yearString = node.InnerText;
                    yearString = yearString.ToLower().Replace(" ", ""); yearString = yearString.Trim();
                    if (yearString != "yearofestablishment" && yearString != "foundedin" &&
                        yearString != "yearoffoundation" && yearString != "establishedin") continue;
                    var yearNode = node.NextSibling;
                    RemoveComments(yearNode);
                    inUniversity.Info.FoundationYear = yearNode.InnerText.Trim();
                    break;
                }
            }
            catch
            { inUniversity.Info.FoundationYear = "Not reported"; }

            try //Motto - there are unis without motto
            {
                var node = document.DocumentNode.SelectNodes("/html/body/table[5]/tr/td");
                var motto = node.Single(d => d.InnerText.ToLower().Trim() == "motto").NextSibling; //Here LINQ works well
                var latinMotto = motto.SelectSingleNode("//cite");
                var englishMotto = motto.SelectSingleNode("//em");
                if (string.IsNullOrEmpty(englishMotto.InnerText))
                    englishMotto = latinMotto; // If there is no latin motto, english motto is in //cite part
                RemoveComments(englishMotto);
                inUniversity.Info.Motto = WebUtility.HtmlDecode(englishMotto.InnerText);
            }
            catch
            { inUniversity.Info.Motto = "Not reported"; }

            try //Adress: Street + City + Privince
            {
                var street = document.DocumentNode.SelectSingleNode("/html/body/table[6]/tr[2]/td[2]/h5");
                var city = document.DocumentNode.SelectSingleNode("/html/body/table[6]/tr[2]/td[2]/h5[2]");
                var province = document.DocumentNode.SelectSingleNode("/html/body/table[6]/tr[2]/td[2]/h5[3]");
                RemoveComments(street); RemoveComments(city); RemoveComments(province);
                // There are some problems with special chars... ã now works well but there are still problems with š
                inUniversity.Info.Address = HtmlEntity.DeEntitize(street.InnerHtml.Replace("&#154;", "š") + " "
                                    + city.InnerHtml + " "
                                    + province.InnerHtml);
            }
            catch
            { inUniversity.Info.Address = "Not reported"; }

            try // Phone
            {
                var phone = document.DocumentNode.SelectSingleNode("/html/body/table[6]/tr[4]/td[2]/h5");
                RemoveComments(phone);
                inUniversity.Info.Phone = phone.InnerText.Trim(); // Only phone, fax is not included
            }
            catch
            { inUniversity.Info.Phone = "Not reported"; }

            try // TotalEnrollment
            {
                var totalEnrollment = document.DocumentNode.SelectSingleNode("/html/body/table[11]/tr[2]/td/h5");
                RemoveComments(totalEnrollment);
                inUniversity.Info.TotalEnrollment = totalEnrollment.InnerText.Trim();
            }
            catch
            { inUniversity.Info.TotalEnrollment = "Not reported"; }

            try //Link to official website
            {
                var officalWebsite = document.DocumentNode.SelectNodes("/html/body/table[5]/tr/td/a");
                foreach (HtmlNode htmlNode in officalWebsite.Where(htmlNode => htmlNode.InnerText == string.Empty && htmlNode.Attributes["rel"].Value == "nofollow" && htmlNode.Attributes["target"].Value == "_blank"))
                {
                    RemoveComments(htmlNode);
                    inUniversity.Info.OfficalWebsite= htmlNode.Attributes["href"].Value;
                    break;
                }
                inUniversity.RegisterDataSource(InfoDomainEnum.Home, InfoCategoryEnum.UniversityHomePage, inUniversity.Info.OfficalWebsite);
            }
            catch
            { inUniversity.Info.OfficalWebsite = "Not reported"; }

            try // Local Students UnderGraduate Price
            {
                var localUnderGraduate = document.DocumentNode.SelectSingleNode("/html/body/table[8]/tr[4]/td[2]/h5");
                RemoveComments(localUnderGraduate);
                inUniversity.Info.LocalStudentsUnderGraduatePrice = localUnderGraduate.InnerText.Trim();
            }
            catch
            { inUniversity.Info.LocalStudentsUnderGraduatePrice = "Not reported"; }

            try // Local Students PostGraduate Price
            {
                var localPostGraduate = document.DocumentNode.SelectSingleNode("/html/body/table[8]/tr[4]/td[3]/h5");
                RemoveComments(localPostGraduate);
                inUniversity.Info.LocalStudentsPostGraduatePrice = localPostGraduate.InnerText.Trim();
            }
            catch
            { inUniversity.Info.LocalStudentsPostGraduatePrice = "Not reported"; }

            try // International Students UnderGraduate Price
            {
                var internatinalUnderGraduate = document.DocumentNode.SelectSingleNode("/html/body/table[8]/tr[5]/td[2]/h5");
                RemoveComments(internatinalUnderGraduate);
                inUniversity.Info.InternationalStudentsUnderGraduatePrice = internatinalUnderGraduate.InnerText.Trim();
            }
            catch
            { inUniversity.Info.InternationalStudentsUnderGraduatePrice = "Not reported"; }

            try // International Students PostGraduate Price
            {
                var internationalPostGraduate = document.DocumentNode.SelectSingleNode("/html/body/table[8]/tr[5]/td[3]/h5");
                RemoveComments(internationalPostGraduate);
                inUniversity.Info.InternationalStudentsPostGraduatePrice = internationalPostGraduate.InnerText.Trim();
            }
            catch
            { inUniversity.Info.InternationalStudentsPostGraduatePrice = "Not reported"; }

            try // Academic Structure - some Unis don't have it !
            {
                HtmlNode header = document.DocumentNode.SelectSingleNode("/html/body/table[15]/tr[2]/td/h4");
                HtmlNode academicStructure = null;
                List<string> academicStructureList = new List<string>();
                string headerText = (header.InnerText.ToLower().Trim().Replace(" ", ""));
                if (headerText == "academicstructure" || headerText == "mainacademicdivisions")
                {
                    academicStructure = document.DocumentNode.SelectSingleNode("/html/body/table[15]/tr[2]/td/h5");
                    RemoveComments(academicStructure);
                    string academicStructureString = WebUtility.HtmlDecode(academicStructure.InnerText);
                    string[] parse = academicStructureString.Split(';');
                    academicStructureList.AddRange(parse.Select(t => t.Trim()));
                    inUniversity.Info.AcademicStructure = academicStructureList;
                }
                else
                { inUniversity.Info.AcademicStructure = new List<string> { "Not reported" };}
            }
            catch
            {inUniversity.Info.AcademicStructure = new List<string> { "Not reported" };}

            try //Global rank
            {
                HtmlNode ranking = document.DocumentNode.SelectSingleNode("//html/body/table[5]/tr/td[2]/table/tr/td/iframe");
                string link = ranking.Attributes["src"].Value;
                HtmlWeb web = new HtmlWeb();
                HtmlDocument rankingPage = web.Load(link);
                HtmlNode rankingNumber = rankingPage.DocumentNode.SelectSingleNode("/body/table/tr/td[2]");
                RemoveComments(rankingNumber);
                inUniversity.Info.GlobalRank = Convert.ToInt32(rankingNumber.InnerText.Trim());
            }
            catch
            {inUniversity.Info.GlobalRank = 0;}

            try// Course levels in List<enum>, if error return empty list
            {
                HtmlNodeCollection courseLevelsData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[6]/td/img");
                List<DomainModel.Enums.CourseLevelsEnum> courseLevelsList = new List<CourseLevelsEnum>();
                for (int i = 0; i < 5; i++)
                {
                    if (courseLevelsData[i].Attributes["src"].Value == "/i/1.gif")
                    {
                        courseLevelsList.Add((CourseLevelsEnum)Enum.ToObject(typeof(CourseLevelsEnum), (int)i));
                    }

                }
                inUniversity.Info.CourseLevels = courseLevelsList;
            }
            catch
            {inUniversity.Info.CourseLevels = new List<CourseLevelsEnum>();}

            //AREAS OF STUDIES & COURSE LEVELS
            try // Areas Of Studies in Dictionary<enum,bool[5]>
            {
                HtmlNodeCollection artsHumanitiesData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[8]/td/img");
                HtmlNodeCollection businessSocialSciencesData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[9]/td/img");
                HtmlNodeCollection languageCulturalStudiesData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[10]/td/img");
                HtmlNodeCollection medicineHealthData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[11]/td/img");
                HtmlNodeCollection engineeringData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[12]/td/img");
                HtmlNodeCollection scienceTechnologyData = document.DocumentNode.SelectNodes("/html/body/table[7]/tr[13]/td/img");

                DomainModel.Core.AreasOfStudies areasOfStudies= new AreasOfStudies
                    {
                        ArtsHumanities = FindCourseLevels(artsHumanitiesData),
                        BusinessSocialSciences=FindCourseLevels(businessSocialSciencesData),
                        LanguageCulturalStudies=FindCourseLevels(languageCulturalStudiesData),
                        MedicineHealth= FindCourseLevels(medicineHealthData),
                        Engineering=FindCourseLevels(engineeringData),
                        ScienceTechnology=FindCourseLevels(scienceTechnologyData)
                    };             

                inUniversity.Info.AreasOfStudies = areasOfStudies;
            }
            catch //If there is any error return dictionary with all false values
            {
                DomainModel.Core.AreasOfStudies areasOfStudies = new AreasOfStudies
                    {
                        ArtsHumanities = new List<CourseLevelsEnum>(),
                        BusinessSocialSciences = new List<CourseLevelsEnum>(),
                        LanguageCulturalStudies = new List<CourseLevelsEnum>(),
                        MedicineHealth = new List<CourseLevelsEnum>(),
                        Engineering = new List<CourseLevelsEnum>(),
                        ScienceTechnology = new List<CourseLevelsEnum>()
                    };
                 inUniversity.Info.AreasOfStudies = areasOfStudies; 
            }

            //UNIVERSITY ADMISSIONS 
            try//Gender
            {
                HtmlNode genderAdmission = document.DocumentNode.SelectSingleNode("/html/body/table[10]/tr[2]/td/h5");
                RemoveComments(genderAdmission);
                inUniversity.Info.Gender = genderAdmission.InnerText.Trim();
            }
            catch
            {inUniversity.Info.Gender="Not reported";}

            try//INTERNATIONAL STUDENTS
            {
                HtmlNode internationalStudents = document.DocumentNode.SelectSingleNode("/html/body/table[10]/tr[2]/td[2]/a/img");
                var image = internationalStudents.Attributes["src"].Value;
                inUniversity.Info.InternationalStudents = image == "/i/international-students1.gif" ? "Yes" : "Not reported";
            }
            catch
            {inUniversity.Info.InternationalStudents ="Not reported";}

            try//Admission Selection
            {
                HtmlNode admissionSelection = document.DocumentNode.SelectSingleNode("/html/body/table[10]/tr[3]/td/h5");        
                RemoveComments(admissionSelection);
                inUniversity.Info.AdmissionSelection = admissionSelection.InnerText.Trim();

            }
            catch
            { inUniversity.Info.AdmissionSelection = "Not reported";}

            try//Selection Percentage
            {               
                HtmlNode selectionPercentage = document.DocumentNode.SelectSingleNode("/html/body/table[10]/tr[3]/td[2]/h5");
                RemoveComments(selectionPercentage);
                inUniversity.Info.SelectionPercentage = selectionPercentage.InnerText.Trim();

            }
            catch
            {
                inUniversity.Info.SelectionPercentage = "Not reported";
            }

            try//Totall stuff
            {
                HtmlNode totalStuff = document.DocumentNode.SelectSingleNode("/html/body/table[11]/tr[2]/td[2]/h5");
                RemoveComments(totalStuff);
                inUniversity.Info.TotalStaff = totalStuff.InnerText.Trim();
            }
            catch
            {inUniversity.Info.TotalStaff = "Not reported";}

            try//Control type
            {
                HtmlNode control = document.DocumentNode.SelectSingleNode("/html/body/table[11]/tr[3]/td/h5");
                RemoveComments(control);
                inUniversity.Info.ControlType = control.InnerText.Trim();
            }
            catch
            {inUniversity.Info.ControlType = "Not reported";}

            try//Entity type
            {
                HtmlNode entityType = document.DocumentNode.SelectSingleNode("/html/body/table[11]/tr[3]/td[2]/h5");
                RemoveComments(entityType);
                inUniversity.Info.EntityType = entityType.InnerText.Trim();
            }
            catch
            {
                inUniversity.Info.EntityType = "Not reported";
            }

            try//Academic calendar
            {
                HtmlNode academicCalendar = document.DocumentNode.SelectSingleNode("/html/body/table[11]/tr[4]/td/h5");
                RemoveComments(academicCalendar);
                inUniversity.Info.AcademicCalendar = academicCalendar.InnerText.Trim();
            }
            catch
            {
                inUniversity.Info.AcademicCalendar = "Not reported";
            }

            try//Campus type
            {
                HtmlNode campusType = document.DocumentNode.SelectSingleNode("/html/body/table[11]/tr[4]/td[2]/h5");
                RemoveComments(campusType);
                inUniversity.Info.CampusType = campusType.InnerText.Trim();
            }
            catch
            {
                inUniversity.Info.CampusType = "Not reported";
            }

            try // AFFILIATIONS AND MEMBERSHIPS  
            {
                HtmlNode header = document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[2]/td/h4");
                string headerText = (header.InnerText.ToLower().Trim().Replace(" ", ""));
                List<string> affilationsAndMembershipsList = new List<string>();
                if (headerText == "mainmembershipsandaffiliations")
                {
                    HtmlNode affilationsAndMemberships = document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[2]/td/h5");
                    RemoveComments(affilationsAndMemberships);
                    string affilationsAndMembershipsString = WebUtility.HtmlDecode(affilationsAndMemberships.InnerText);
                    string[] parse = affilationsAndMembershipsString.Split(';');
                    affilationsAndMembershipsList.AddRange(parse.Select(t => t.Trim()));
                    inUniversity.Info.AffilationsAndMemberships = affilationsAndMembershipsList;
                }
                else
                { inUniversity.Info.AffilationsAndMemberships = new List<string> { "Not reported" }; }
            }
            catch
            { inUniversity.Info.AffilationsAndMemberships = new List<string> { "Not reported" }; }

            try // facebook 
            {
                HtmlNode facebookUri = document.DocumentNode.SelectSingleNode("/html/body/table[18]/tr[2]/td/h5/a") ??
                                       document.DocumentNode.SelectSingleNode("/html/body/table[17]/tr[2]/td/h5/a") ??
                                       document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[2]/td/h5/a");
                RemoveComments(facebookUri);
                inUniversity.Info.FacebookUri = facebookUri.Attributes["href"].Value;
            }
            catch
            { inUniversity.Info.FacebookUri ="Not reported"; }


            try // LinkedIn 
            {
                HtmlNode linkedInUri = document.DocumentNode.SelectSingleNode("/html/body/table[18]/tr[3]/td/h5/a") ??
                                       document.DocumentNode.SelectSingleNode("/html/body/table[17]/tr[3]/td/h5/a") ??
                                       document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[3]/td/h5/a");
                RemoveComments(linkedInUri);
                inUniversity.Info.LinkedInUri= linkedInUri.Attributes["href"].Value;
            }
            catch
            {  inUniversity.Info.LinkedInUri="Not reported"; }

            try // Twitter 
            {
                HtmlNode twitterUri = document.DocumentNode.SelectSingleNode("/html/body/table[18]/tr[4]/td/h5/a") ??
                                      document.DocumentNode.SelectSingleNode("/html/body/table[17]/tr[4]/td/h5/a") ??
                                      document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[4]/td/h5/a");
                RemoveComments(twitterUri);
                inUniversity.Info.TwitterUri= twitterUri.Attributes["href"].Value;
            }
            catch
            { inUniversity.Info.TwitterUri="Not reported"; }

            try // Wikipedia 
            {
                HtmlNode wikipediaUri = document.DocumentNode.SelectSingleNode("/html/body/table[18]/tr[8]/td/h5/a") ??
                                        document.DocumentNode.SelectSingleNode("/html/body/table[18]/tr[7]/td/h5/a") ??
                                        document.DocumentNode.SelectSingleNode("/html/body/table[17]/tr[7]/td/h5/a") ??
                                        document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[7]/td/h5/a");
                RemoveComments(wikipediaUri);
                inUniversity.Info.WikipediaUri= wikipediaUri.Attributes["href"].Value;
            }
            catch
            { inUniversity.Info.WikipediaUri="Not reported"; }

            try // YouTube 
            {
                HtmlNode youtubeUri = document.DocumentNode.SelectSingleNode("/html/body/table[18]/tr[5]/td/h5/a") ??
                                      document.DocumentNode.SelectSingleNode("/html/body/table[17]/tr[5]/td/h5/a") ??
                                      document.DocumentNode.SelectSingleNode("/html/body/table[16]/tr[5]/td/h5/a");
                RemoveComments(youtubeUri);
                inUniversity.Info.YouTubeUri= youtubeUri.Attributes["href"].Value;
            }
            catch
            {  inUniversity.Info.YouTubeUri="Not reported"; }

            //FACILITIES AND SERVICES
            try //Library
            {
                HtmlNode library = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[2]/td/h5/a/img");
                RemoveComments(library);
                if (library.Attributes["src"].Value == "/i/library1.gif")
                {
                    HtmlNode link = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[2]/td/h5/a[2]");
                    if (link != null)
                    {
                        RemoveComments(link);
                        inUniversity.Info.Library = link.InnerText.Trim();
                        inUniversity.Info.LibraryUri = link.Attributes["href"].Value;
                    }
                    else
                    {
                        inUniversity.Info.Library = "Yes";
                        inUniversity.Info.LibraryUri = string.Empty;
                    }
                }
                else
                {
                    inUniversity.Info.Library = "Not reported";
                    inUniversity.Info.LibraryUri = string.Empty;
                }
            }
            catch
            {
                inUniversity.Info.Library ="Not reported";
                inUniversity.Info.LibraryUri = string.Empty;
            }

            try // Sports Activities
            {
                HtmlNode sports = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[2]/td[2]/a/img");
                RemoveComments(sports);
                inUniversity.Info.Sports = sports.Attributes["src"].Value == "/i/sport1.gif" ? "Yes" : "Not reported";
            }
            catch
            {inUniversity.Info.Sports = "Not reported";}

            try //Scholarships / Financial Aids 
            {
                HtmlNode scholarships = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[3]/td/a/img");
                RemoveComments(scholarships);
                inUniversity.Info.Scholarships = scholarships.Attributes["src"].Value == "/i/financialaids1.gif" ? "Yes" : "Not reported";

            }
            catch
            {inUniversity.Info.Scholarships = "Not reported";}

            try //Housing
            {
                HtmlNode housing = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[3]/td[2]/a/img");
                RemoveComments(housing);
                inUniversity.Info.Housing = housing.Attributes["src"].Value == "/i/housing1.gif" ? "Yes" : "Not reported";
            }
            catch
            {inUniversity.Info.Housing = "Not reported";}

            try // Exchange programs 
            {
                HtmlNode exchangePrograms = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[4]/td/a/img");
                RemoveComments(exchangePrograms);
                inUniversity.Info.ExchangePrograms = exchangePrograms.Attributes["src"].Value == "/i/study-abroad1.gif" ? "Yes" : "Not reported";
            }
            catch (Exception)
            {inUniversity.Info.ExchangePrograms = "Not reported";}

            try // Online courses
            {
                HtmlNode onlineCourses = document.DocumentNode.SelectSingleNode("/html/body/table[13]/tr[4]/td[2]/a/img");
                RemoveComments(onlineCourses);
                inUniversity.Info.OnlineCourses = onlineCourses.Attributes["src"].Value == "/i/distance-learning1.gif" ? "Yes" : "Not reported";

            }
            catch
            { inUniversity.Info.OnlineCourses = "Not reported"; }


        }

        private static void RemoveComments(HtmlNode node) // To remove <!--Something--> from .InnerText
        {
            foreach (var n in node.ChildNodes.ToArray())
                RemoveComments(n);
            if (node.NodeType == HtmlNodeType.Comment)
                node.Remove();
        }

        public void UpdateShort(University inUniversity)
        {
            //Implement : just fetch world ranking, motto and link to official website
            //Fetch details
            var webGet = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.Default
            };

            HtmlDocument document;
            try
            {
                document = webGet.Load(Configuration.GetParameter("Uri"));
            }
            catch
            {
                try
                {
                    document = webGet.Load(Configuration.GetParameter("Uri"));
                }
                catch (WebException ex)
                {
                    throw new Exception("Cannot load webpage");
                }
            }

            //Parsing
            //4Icu WebPage  returnes "Not reported" string when they not have particular data. 
            //I also use it situation when usually design is changed or when Xpath not exists! It can bi changed during review of this class.

            try //Motto - there are unis without motto
            {
                var node = document.DocumentNode.SelectNodes("/html/body/table[5]/tr/td");
                var motto = node.Single(d => d.InnerText.ToLower().Trim() == "motto").NextSibling; //Here LINQ works well
                var latinMotto = motto.SelectSingleNode("//cite");
                var englishMotto = motto.SelectSingleNode("//em");
                if (string.IsNullOrEmpty(englishMotto.InnerText))
                    englishMotto = latinMotto; // If there is no latin motto, english motto is in //cite part
                RemoveComments(englishMotto);
                inUniversity.Info.Motto = WebUtility.HtmlDecode(englishMotto.InnerText);
            }
            catch
            { inUniversity.Info.Motto = "Not reported"; }

            try //Link to official website
            {
                var officalWebsite = document.DocumentNode.SelectSingleNode("/html/body/table[5]/tr[6]/td[2]/a");
                RemoveComments(officalWebsite);
                inUniversity.Info.OfficalWebsite = officalWebsite.Attributes["href"].Value;
                inUniversity.RegisterDataSource(InfoDomainEnum.Home, InfoCategoryEnum.UniversityHomePage, inUniversity.Info.OfficalWebsite);
            }
            catch
            { inUniversity.Info.OfficalWebsite = "Not reported"; }

            try //Global rank
            {
                HtmlNode ranking = document.DocumentNode.SelectSingleNode("//html/body/table[5]/tr/td[2]/table/tr/td/iframe");
                string link = ranking.Attributes["src"].Value;
                HtmlWeb web = new HtmlWeb();
                HtmlDocument rankingPage = web.Load(link);
                HtmlNode rankingNumber = rankingPage.DocumentNode.SelectSingleNode("/body/table/tr/td[2]");
                RemoveComments(rankingNumber);
                inUniversity.Info.GlobalRank = Convert.ToInt32(rankingNumber.InnerText.Trim());
            }
            catch
            {
                inUniversity.Info.GlobalRank = 0;
            }
        }

        
        private static List<CourseLevelsEnum> FindCourseLevels(HtmlNodeCollection areaData)
        {
            List<CourseLevelsEnum> courseLevelsList = new List<CourseLevelsEnum>();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if (areaData[i].Attributes["src"].Value == "/i/1b.gif" ||
                        areaData[i].Attributes["src"].Value == "http://www.4icu.org/i/1b.gif")
                    {
                        courseLevelsList.Add((CourseLevelsEnum)Enum.ToObject(typeof(CourseLevelsEnum), (int)i));
                    }
                }
                return courseLevelsList;
            }
            catch
            { return courseLevelsList; }
        }

        public override void Update(University obj, ParameterCollection parameters)
        {
           UpdateFull(obj);
        }
    }
}
