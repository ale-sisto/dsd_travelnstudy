using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Framework;
using StudyAbroad.DynamicLoading.ApiUtilities;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.DynamicLoading.Core
{
    public class FreebaseUniversityLoader : Loader<University>
    {
        private const string NOT_REPORTED = "Not reported";
        private const int NO_VALUE = -1000;

        private ParameterCollection _readParameters;

        public FreebaseUniversityLoader(LoaderConfiguration inConfiguration)
            : base(inConfiguration)
        {
            //When initializing start new query and its read parameters
            FreebaseClient.InitiateMqlObject(Configuration.GetParameter("Mid"), Configuration.GetParameter("Type"));
            _readParameters = new ParameterCollection();
        }

        public override void Load(List<University> items)
        {
            throw new Exception("No loading of universities is implemented from the Freebase data source. Use IcuOrg instead!");
        }

        public override void Update(University obj, ParameterCollection parameters)
        {
            //Go through all the parameters
            if (parameters.HasParameter(UniversityParameters.ShortDescription))
            {
                GetShortDescription(obj);
                _readParameters.AddParameter(UniversityParameters.ShortDescription);
            }

            if (parameters.HasParameter(UniversityParameters.Description) || parameters.HasParameter(UniversityParameters.WikipediaUri))
            {
                //initiate the article object
                dynamic articleObj = new ExpandoObject();
                articleObj.id = null;
                articleObj.source_uri = null;
                articleObj.limit = 1;
                articleObj.optional = true;

                //add the parameter as read
                if (parameters.HasParameter(UniversityParameters.Description))
                    _readParameters.AddParameter(UniversityParameters.Description);
                if (parameters.HasParameter(UniversityParameters.WikipediaUri))
                    _readParameters.AddParameter(UniversityParameters.WikipediaUri);
                //check if query limit reached, if its reached execute the query and continue with next parameter
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/common/topic/article", articleObj));
            }

            if (parameters.HasParameter(UniversityParameters.ImageURL))
            {
                //initiate the image object
                dynamic imageObj = new ExpandoObject();
                imageObj.id = null;
                imageObj.limit = 1;
                imageObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.ImageURL);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/common/topic/image", imageObj));
            }

            if (parameters.HasParameter(UniversityParameters.Departments))
            {
                //initiate the department object
                dynamic departmentObj = new ExpandoObject();
                departmentObj.name = null;
                departmentObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.Departments);
                FreebaseClient.ActiveQuery.departments = new object[] { departmentObj };
                FreebaseClient.QueryPropertiesCount++;
            }

            if (parameters.HasParameter(UniversityParameters.OfficialWebsite) && (obj.Info.OfficalWebsite == NOT_REPORTED || obj.Info.OfficalWebsite == null))
            {
                //initiate objects that returns one string value
                dynamic stringObj = new ExpandoObject();
                stringObj.value = null;
                stringObj.limit = 1;
                stringObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.OfficialWebsite);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/common/topic/official_website", stringObj));
            }

            if (parameters.HasParameter(UniversityParameters.FoundationYear) && (obj.Info.FoundationYear == NOT_REPORTED || obj.Info.FoundationYear == null))
            {
                //initiate objects that returns one string value
                dynamic stringObj = new ExpandoObject();
                stringObj.value = null;
                stringObj.limit = 1;
                stringObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.FoundationYear);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/organization/organization/date_founded", stringObj));
            }

            if (parameters.HasParameter(UniversityParameters.Motto) && (obj.Info.Motto == NOT_REPORTED || obj.Info.Motto == null))
            {
                //initiate objects that returns one string value
                dynamic stringObj = new ExpandoObject();
                stringObj.value = null;
                stringObj.limit = 1;
                stringObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.Motto);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/educational_institution/motto", stringObj));
            }


            if (parameters.HasParameter(UniversityParameters.TotalEnrollment) && (obj.Info.TotalEnrollment == NOT_REPORTED || obj.Info.TotalEnrollment == null))
            {
                //initiate object that returns one numeric value
                dynamic numericObj = new ExpandoObject();
                numericObj.number = null;
                numericObj.limit = 1;
                numericObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.TotalEnrollment);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/educational_institution/total_enrollment", numericObj));
            }


            if (parameters.HasParameter(UniversityParameters.NumberOfUndergraduates))
            {
                //initiate object that returns one numeric value
                dynamic numericObj = new ExpandoObject();
                numericObj.number = null;
                numericObj.limit = 1;
                numericObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.NumberOfUndergraduates);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/university/number_of_undergraduates", numericObj));
            }

            if (parameters.HasParameter(UniversityParameters.NumberOfPostgraduates))
            {
                //initiate object that returns one numeric value
                dynamic numericObj = new ExpandoObject();
                numericObj.number = null;
                numericObj.limit = 1;
                numericObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.NumberOfPostgraduates);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/university/number_of_postgraduates", numericObj));
            }

            if (parameters.HasParameter(UniversityParameters.TotalStaff) && (obj.Info.TotalStaff == NOT_REPORTED || obj.Info.TotalStaff == null))
            {
                //initiate object that returns one numeric value
                dynamic numericObj = new ExpandoObject();
                numericObj.number = null;
                numericObj.limit = 1;
                numericObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.TotalStaff);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/educational_institution/number_of_staff", numericObj));
            }

            if (parameters.HasParameter(UniversityParameters.SelectionPercentage) && (obj.Info.SelectionPercentage == NOT_REPORTED || obj.Info.SelectionPercentage == null))
            {
                //initiate the acceptance rate object
                dynamic acceptanceObj = new ExpandoObject();
                acceptanceObj.rate = null;
                acceptanceObj.limit = 1;
                acceptanceObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.SelectionPercentage);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/university/acceptance_rate", acceptanceObj));
            }

            if (parameters.HasParameter(UniversityParameters.LocalStudentsPrice) && (obj.Info.LocalStudentsUnderGraduatePrice == NOT_REPORTED || obj.Info.LocalStudentsUnderGraduatePrice == null))
            {
                //initiate domestic and international tuition object
                dynamic tuitionObj = new ExpandoObject();
                tuitionObj.amount = null;
                tuitionObj.currency = null;
                //tuitionObj.valid_date = null;
                tuitionObj.limit = 1;
                tuitionObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.LocalStudentsPrice);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/university/domestic_tuition", tuitionObj));
            }

            if (parameters.HasParameter(UniversityParameters.InternationalStudentsPrice) && (obj.Info.InternationalStudentsUnderGraduatePrice == NOT_REPORTED || obj.Info.InternationalStudentsUnderGraduatePrice == null))
            {
                //initiate domestic and international tuition object
                dynamic tuitionObj = new ExpandoObject();
                tuitionObj.amount = null;
                tuitionObj.currency = null;
                tuitionObj.valid_date = null;
                tuitionObj.limit = 1;
                tuitionObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.InternationalStudentsPrice);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/university/international_tuition", tuitionObj));
            }

            if (parameters.HasParameter(UniversityParameters.Phone) && (obj.Info.Phone == NOT_REPORTED || obj.Info.Phone == null))
            {
                //initiate telephone number object
                dynamic telephoneObj = new ExpandoObject();
                telephoneObj.number = null;
                telephoneObj.country_code = null;
                telephoneObj.limit = 1;
                telephoneObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.Phone);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/education/educational_institution/phone_number", telephoneObj));
            }

            if (parameters.HasParameter(UniversityParameters.Address) && (obj.Info.Address == NOT_REPORTED || obj.Info.Address == null))
            {
                //initiate the postal code object (needed in address)
                dynamic postalCodeObj = new ExpandoObject();
                postalCodeObj.postal_code = null;
                postalCodeObj.limit = 1;
                postalCodeObj.optional = true;


                //inititate the address object
                dynamic addressObj = new ExpandoObject();
                addressObj.street_address = null;
                addressObj.citytown = null;
                addressObj.state_province_region = null;
                addressObj.postal_code = postalCodeObj;
                addressObj.limit = 1;
                addressObj.optional = true;

                _readParameters.AddParameter(UniversityParameters.Address);
                ExecuteActiveQuery(obj, FreebaseClient.AddMqlProperty("/organization/organization/headquarters", addressObj));
            }

            //In the end execute any remaining queries
            ExecuteActiveQuery(obj, true);
        }

        private void ParseQueryResult(University obj, dynamic result)
        {
            //For each query execution assign properties which were fetched with the current query
            if (_readParameters.HasParameter(UniversityParameters.Description))
                GetDescription(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.WikipediaUri))
                GetWikipediaUri(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.ImageURL))
                GetImageURL(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.Departments))
                GetDepartments(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.OfficialWebsite))
                GetOfficialWebsite(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.FoundationYear))
                GetFoundationYear(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.TotalEnrollment))
                GetTotalEnrollment(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.LocalStudentsPrice))
                GetDomesticPrice(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.InternationalStudentsPrice))
                GetInternationalPrice(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.Phone))
                GetPhone(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.Address))
                GetAddress(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.SelectionPercentage))
                GetSelectionPercentage(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.Motto))
                GetMotto(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.NumberOfPostgraduates))
                GetNumOfPostgraduates(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.NumberOfUndergraduates))
                GetNumOfUndergraduates(result, obj);

            if (_readParameters.HasParameter(UniversityParameters.TotalStaff))
                GetTotalStaff(result, obj);

            //Reset fetched properties for next query
            _readParameters = new ParameterCollection();
        }

        private void ExecuteActiveQuery(University obj, bool execute)
        {
            //Execute current query
            if (execute)
            {
                //Execute query and parse results
                var response = FreebaseClient.MqlRead();
                ParseQueryResult(obj, response.ObjectResult);
                //Reset and start new query
                FreebaseClient.InitiateMqlObject(Configuration.GetParameter("Mid"), Configuration.GetParameter("Type"));
                _readParameters = new ParameterCollection();
            }
        }


        #region Parse json result
        private void GetShortDescription(University obj)
        {
            try
            {
                var response = FreebaseClient.MqlText(Configuration.GetParameter("Mid"), "plain", 200);
                obj.Info.Description = response.ObjectResult.result;
            }
            catch
            {
                obj.Info.Description = NOT_REPORTED;
            }
        }

        private void GetDescription(dynamic objRes, University obj)
        {
            try
            {
                //get article identifier
                var descriptionLink = (string)objRes.result["/common/topic/article"].id;
                //read article
                var descriptionObj = FreebaseClient.MqlText(descriptionLink, "html").ObjectResult;
                //save article text
                obj.Info.Description = (string)descriptionObj.result;
            }
            catch
            {
                obj.Info.Description = NOT_REPORTED;
            }
        }

        private void GetWikipediaUri(dynamic objRes, University obj)
        {
            try
            {
                //get full article uri
                string sourceUri = objRes.result["/common/topic/article"].source_uri;
                var articleNum = sourceUri.Split('/').LastOrDefault();
                obj.Info.WikipediaUri = Resources.Content.Uris.Wiki + articleNum;
            }
            catch
            {
                if (String.IsNullOrEmpty(obj.Info.WikipediaUri))
                    obj.Info.WikipediaUri = NOT_REPORTED;
            }
        }

        private void GetImageURL(dynamic objRes, University obj)
        {
            try
            {
                var imageLink = (string)objRes.result["/common/topic/image"].id;
                obj.Info.ImageURL = Resources.Content.Uris.FreebaseRawImage + imageLink + "?maxheight=0" + "&maxwidth=0";
            }
            catch
            {
                obj.Info.ImageURL = "No image";
            }
        }

        private void GetDepartments(dynamic objRes, University obj)
        {
            try
            {
                var departments = new List<string>();
                //Parsing result to get article link
                foreach (dynamic d in objRes.result.departments)
                {
                    departments.Add((string)d.name);
                }

                obj.Info.Departments = departments;
            }
            catch
            {
                obj.Info.Departments = new List<string>() { NOT_REPORTED };
            }
        }



        private void GetOfficialWebsite(dynamic objRes, University obj)
        {
            try { obj.Info.OfficalWebsite = objRes.result["/common/topic/official_website"].value; }
            catch { obj.Info.OfficalWebsite = NOT_REPORTED; }
        }

        private void GetFoundationYear(dynamic objRes, University obj)
        {
            try { obj.Info.FoundationYear = objRes.result["/organization/organization/date_founded"].value; }
            catch { obj.Info.FoundationYear = NOT_REPORTED; }
        }

        private void GetTotalEnrollment(dynamic objRes, University obj)
        {
            try { obj.Info.TotalEnrollment = objRes.result["/education/educational_institution/total_enrollment"].number; }
            catch { obj.Info.TotalEnrollment = NOT_REPORTED; }
        }

        private void GetInternationalPrice(dynamic objRes, University obj)
        {
            try
            {
                obj.Info.InternationalStudentsUnderGraduatePrice = objRes.result["/education/university/international_tuition"].amount;
                obj.Info.InternationalStudentsUnderGraduatePrice += " " + objRes.result["/education/university/international_tuition"].currency;
            }
            catch
            {
                obj.Info.InternationalStudentsUnderGraduatePrice = NOT_REPORTED;
            }
        }

        private void GetDomesticPrice(dynamic objRes, University obj)
        {
             try
            {
                obj.Info.LocalStudentsUnderGraduatePrice = objRes.result["/education/university/domestic_tuition"].amount;
                obj.Info.LocalStudentsUnderGraduatePrice += " " + objRes.result["/education/university/domestic_tuition"].currency;
            }
            catch 
            {
                obj.Info.LocalStudentsUnderGraduatePrice = NOT_REPORTED;
            }
        }

        private void GetPhone(dynamic objRes, University obj)
        {
            try
            {
                string number = objRes.result["/education/educational_institution/phone_number"].number;
                string country_code = objRes.result["/education/educational_institution/phone_number"].country_code;

                obj.Info.Phone = "+" + country_code + " " + number;
            }
            catch
            {
                obj.Info.Phone = NOT_REPORTED;
            }
        }

        private void GetAddress(dynamic objRes, University obj)
        {
            string street, town, postalCode, province;
            try { street = objRes.result["/organization/organization/headquarters"].street_address; }
            catch { street = ""; }
            try { town = objRes.result["/organization/organization/headquarters"].citytown; }
            catch { town = ""; }
            try { postalCode = objRes.result["/organization/organization/headquarters"].postal_code.postal_code; }
            catch { postalCode = ""; }
            try { province = objRes.result["/organization/organization/headquarters"].state_province_region; }
            catch { province = ""; }

            string address = street + " " + town + " " + province + " " + postalCode;
            if (string.IsNullOrWhiteSpace(address))
                address = NOT_REPORTED;

            obj.Info.Address = address.TrimStart();
        }

        private void GetMotto(dynamic objRes, University obj)
        {
            try { obj.Info.Motto = objRes.result["/education/educational_institution/motto"].value; }
            catch { obj.Info.Motto = NOT_REPORTED; }
        }

        private void GetNumOfUndergraduates(dynamic objRes, University obj)
        {
            try { obj.Info.NumOfUndergraduates = (int)objRes.result["/education/university/number_of_undergraduates"].number; }
            catch { obj.Info.NumOfUndergraduates = NO_VALUE; }
        }

        private void GetNumOfPostgraduates(dynamic objRes, University obj)
        {
            try { obj.Info.NumOfPostgraduates = objRes.result["/education/university/number_of_postgraduates"].number; }
            catch { obj.Info.NumOfPostgraduates = NO_VALUE; }
        }

        private void GetTotalStaff(dynamic objRes, University obj)
        {
            try { obj.Info.TotalStaff = objRes.result["/education/educational_institution/number_of_staff"].number; }
            catch { obj.Info.TotalStaff = NOT_REPORTED; }
        }

        private void GetSelectionPercentage(dynamic objRes, University obj)
        {
            try
            {
                decimal rate = objRes.result["/education/university/acceptance_rate"].rate;
                obj.Info.SelectionPercentage = rate.ToString() + " %";
            }
            catch
            {
                obj.Info.SelectionPercentage = NOT_REPORTED;
            }
        }
        #endregion
    }

}