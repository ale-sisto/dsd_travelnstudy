using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Type;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DomainModel.Mapping.MappingDiscriminator
{
    public class UniversityInfoMap : ClassMap<UniversityInfo>
    {
        public UniversityInfoMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0");
            Map(x => x.AcademicStructure);
            Map(x => x.Address);
            Map(x => x.Departments);
            Map(x => x.Description);
            Map(x => x.EnglishName);
            Map(x => x.FoundationYear);
            Map(x => x.FullDescriptionURL);
            Map(x => x.GlobalRank);
            Map(x => x.ImageURL);
            Map(x => x.InternationalStudentsPostGraduatePrice);
            Map(x => x.InternationalStudentsUnderGraduatePrice);
            Map(x => x.LocalStudentsPostGraduatePrice);
            Map(x => x.LocalStudentsUnderGraduatePrice);
            Map(x => x.Motto);
            Map(x => x.OfficalWebsite);            
            Map(x => x.Phone);
            Map(x => x.TotalEnrollment);


            //OK for 8137 rows

            Map(x => x.AcademicCalendar);
            Map(x => x.AdmissionSelection);
            Component(x => x.AreasOfStudies, c =>
                                                 {
                                                     c.Map(x => x.ArtsHumanities);
                                                     c.Map(x => x.BusinessSocialSciences);
                                                     c.Map(x => x.Engineering);
                                                     c.Map(x => x.LanguageCulturalStudies);
                                                     c.Map(x => x.MedicineHealth);
                                                     c.Map(x => x.ScienceTechnology);
                                                 });
            Map(x => x.AffilationsAndMemberships);
            Map(x => x.CampusType);
            Map(x => x.ControlType);
            
            //OK for 8017 rows

            Map(x => x.CourseLevels);
            Map(x => x.ExchangePrograms);
            
            
            //OK for 6924 rows
            Map(x => x.FacebookUri).Length(1000);
            
            //OK for 8618 rows

            Map(x => x.Gender);
            Map(x => x.Housing);
            Map(x => x.InternationalStudents);



            //OK for 8060 rows

            Map(x => x.Library);
            Map(x => x.LibraryUri);
            Map(x => x.LinkedInUri);
            Map(x => x.OnlineCourses);
            Map(x => x.Scholarships);

            //OK for 8876 rows

            Map(x => x.SelectionPercentage);
            Map(x => x.Sports);
            Map(x => x.TotalStaff);

            //OK for 7909 rows

            Map(x => x.TwitterUri);
            
            //Crash on 4239 row
            Map(x => x.WikipediaUri).Length(1000);
            
            //OK for 7923 rows
            Map(x => x.YouTubeUri);
        }
    }
}
