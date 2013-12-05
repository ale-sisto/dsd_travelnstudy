using System.Collections.Generic;

namespace StudyAbroad.DynamicLoading.Framework
{
    public abstract class Parameters
    {
        public abstract ParameterCollection GetAllProperties();
        public abstract ParameterCollection GetShortProperties();
    }

    public class UniversityParameters: Parameters
    {
        UniversityParameters(string display) { this.display = display; }
        public UniversityParameters(){}

        string display;

        public override string ToString() { return display; }

        public static readonly UniversityParameters SelectionPercentage = new UniversityParameters("Selection Percentage");
        public static readonly UniversityParameters Address = new UniversityParameters("Address");
        public static readonly UniversityParameters Departments = new UniversityParameters("Departments");
        public static readonly UniversityParameters Description = new UniversityParameters("Description");
        public static readonly UniversityParameters WikipediaUri = new UniversityParameters("Wikipedia Uri");
        public static readonly UniversityParameters ShortDescription = new UniversityParameters("Short Description");
        public static readonly UniversityParameters LocalStudentsPrice = new UniversityParameters("Local Students Price");
        public static readonly UniversityParameters FoundationYear = new UniversityParameters("Foundation Year");
        public static readonly UniversityParameters ImageURL = new UniversityParameters("Image URL");
        public static readonly UniversityParameters InternationalStudentsPrice = new UniversityParameters("International Students Price");
        public static readonly UniversityParameters Motto = new UniversityParameters("Motto");
        public static readonly UniversityParameters NumberOfPostgraduates = new UniversityParameters("Number Of Postgraduates");
        public static readonly UniversityParameters TotalStaff = new UniversityParameters("Total Staff");
        public static readonly UniversityParameters NumberOfUndergraduates = new UniversityParameters("Number Of Undergraduates");
        public static readonly UniversityParameters OfficialWebsite = new UniversityParameters("Official Website");
        public static readonly UniversityParameters Phone = new UniversityParameters("Phone Number");
        public static readonly UniversityParameters TotalEnrollment = new UniversityParameters("Total Enrollment");


        public override ParameterCollection GetAllProperties()
        {
            var par = new ParameterCollection();
            par.AddParameter(WikipediaUri);
            par.AddParameter(SelectionPercentage);
            par.AddParameter(Address);
            par.AddParameter(Departments);
            par.AddParameter(Description);
            par.AddParameter(LocalStudentsPrice);
            par.AddParameter(FoundationYear);
            par.AddParameter(ImageURL);
            par.AddParameter(InternationalStudentsPrice);
            par.AddParameter(Motto);
            par.AddParameter(NumberOfPostgraduates);
            par.AddParameter(TotalStaff);
            par.AddParameter(NumberOfUndergraduates);
            par.AddParameter(OfficialWebsite);
            par.AddParameter(Phone);
            par.AddParameter(TotalEnrollment);

            return par;
        }

        public override ParameterCollection GetShortProperties()
        {
            var par = new ParameterCollection();
            par.AddParameter(ShortDescription);
            par.AddParameter(ImageURL);

            return par;
        }

    }

    public class CityParameters : Parameters
    {
        CityParameters(string display) { this.display = display; }
        public CityParameters() {}

        string display;
        public override string ToString() { return display; }
        
        public static readonly CityParameters Description = new CityParameters("Description");
        public static readonly CityParameters WikipediaUri = new CityParameters("Wikipedia Uri");
        public static readonly CityParameters ShortDescription = new CityParameters("ShortDescription");
        public static readonly CityParameters ImageURL = new CityParameters("Image Url");
        public static readonly CityParameters Area = new CityParameters("Area");
        public static readonly CityParameters Population = new CityParameters("Population");
        public static readonly CityParameters Geolocation = new CityParameters("Geolocation");
        public static readonly CityParameters Climate = new CityParameters("Climate");
        public static readonly CityParameters TouristAttractions = new CityParameters("Tourist Attractions");

        public override ParameterCollection GetAllProperties()
        {
            var par = new ParameterCollection();
            par.AddParameter(Description);
            par.AddParameter(WikipediaUri);
            par.AddParameter(ImageURL);
            par.AddParameter(Area);
            par.AddParameter(Population);
            par.AddParameter(Geolocation);
            par.AddParameter(Climate);
            par.AddParameter(TouristAttractions);
            return par;
        }

        public override ParameterCollection GetShortProperties()
        {
            var par = new ParameterCollection();
            par.AddParameter(ShortDescription);
            par.AddParameter(Geolocation);

            return par;
        }
    }
}

