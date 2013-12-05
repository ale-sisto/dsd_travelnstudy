using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.DomainModel.Enums
{
    public class EnumHelper
    {
        public static CourseLevelsEnum GetCourseLevelFromString(string inString)
        {
            switch (inString)
            {
                case "Certificates or Diplomas":
                    return CourseLevelsEnum.CertificatesOrDiplomas;
                case "Associate Degrees":
                    return CourseLevelsEnum.AssociateDegrees;
                case "Bachelor Degrees":
                    return CourseLevelsEnum.BachelorDegrees;
                case "Masters Degrees":
                    return CourseLevelsEnum.MasterDegrees;
                case "Doctorate Degrees":
                    return CourseLevelsEnum.DoctorateDegrees;
                default:
                    throw new Exception("Invalid string, cannot be converted to CourseLevelEnum");
            }
        }

        public static string GetStringFromCourseLevel(CourseLevelsEnum inCourseLevel)
        {
            switch (inCourseLevel)
            {
                case CourseLevelsEnum.AssociateDegrees:
                    return "Associate Degrees";
                case CourseLevelsEnum.BachelorDegrees:
                    return "Bachelor Degrees";
                case CourseLevelsEnum.CertificatesOrDiplomas:
                    return "Certificates or Diplomas";
                case CourseLevelsEnum.MasterDegrees:
                    return "Masters Degrees";
                case CourseLevelsEnum.DoctorateDegrees:
                    return "Doctorate Degrees";
                default:
                    throw new Exception("Course level not reckognized, cannot be converted to string");
            }
        }

        public static StudyAreasEnum GetStudyAreaFromString(string inString)
        {
            switch (inString)
            {
                case "Arts and Humanities":
                    return StudyAreasEnum.ArtsHumanities;
                case "Business and Social Sciences":
                    return StudyAreasEnum.BusinessSocialSciences;
                case "Language and Cultural Studies":
                    return StudyAreasEnum.LanguageCulturalStudies;
                case "Medicine and Health":
                    return StudyAreasEnum.MedicineHealth;
                case "Engineering":
                    return StudyAreasEnum.Engineering;
                case "Science Technology":
                    return StudyAreasEnum.ScienceTechnology;
                default:
                    throw new Exception("Invalid string, cannot be converted to StudyAreasEnum");
            }
        }

        public static string GetStringFromStudyArea(StudyAreasEnum inStudyArea)
        {
            switch (inStudyArea)
            {
                case StudyAreasEnum.ArtsHumanities:
                    return "Arts and Humanities";
                case StudyAreasEnum.BusinessSocialSciences:
                    return "Business and Social Sciences";
                case StudyAreasEnum.Engineering:
                    return "Engineering";
                case StudyAreasEnum.LanguageCulturalStudies:
                    return "Language and Cultural Studies";
                case StudyAreasEnum.MedicineHealth:
                    return "Medicine and Health";
                case StudyAreasEnum.ScienceTechnology:
                    return "Science Technology";
                default:
                    throw new Exception("Study area not reckognized, cannot be converted to string");
            }
        }

        public static string GetStringFromCostCategory(CostCategoriesEnum inCostCategory)
        {
            switch (inCostCategory)
            {
                case CostCategoriesEnum.VeryCheap:
                    return "Very cheap";
                case CostCategoriesEnum.Cheap:
                    return "Cheap";
                case CostCategoriesEnum.Moderate:
                    return "Moderate";
                case CostCategoriesEnum.Expensive:
                    return "Expensive";
                case CostCategoriesEnum.VeryExpensive:
                    return "Very expensive";
                default:
                    throw new Exception("Cost category not reckognized, cannot be converted to string");
            }
        }

        public static CostCategoriesEnum GetCostCategoryFromString(string inCategory)
        {
            switch(inCategory)
            {
                case "Very cheap":
                    return CostCategoriesEnum.VeryCheap;
                case "Cheap":
                    return CostCategoriesEnum.Cheap;
                case "Moderate":
                    return CostCategoriesEnum.Moderate;
                case "Expensive":
                    return CostCategoriesEnum.Expensive;
                case "Very expensive":
                    return CostCategoriesEnum.VeryExpensive;
                default:
                    throw new Exception("Invalid string, cannot be converted to cost category enum");
            }
        }
    }
}
