using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.ClimateClassification
{
   public static class ClimateUtilities
    {
       public static double AvgTemp(List<ClimateData> climate)
       {
          double sum = climate.Sum(climateData => Convert.ToDouble(climateData.AvgMaxTemp + climateData.AvgMinTemp)/2.0);
           return sum/climate.Count;
       }

       public static double AvgPrecip(List<ClimateData> climate)
       {
           double sum= climate.Sum(climateData => Convert.ToDouble(climateData.AvgRainfall));
           return sum/climate.Count;
       }

       public static double AvgWarmMonths(List<ClimateData> climate, HemisphereEnum hemisphere)
       {
           if (hemisphere == HemisphereEnum.Northern)
           {
               List<ClimateData> warmMoths= climate.Where(climateData => climateData.Month == "April" || climateData.Month == "May" || climateData.Month == "June" || climateData.Month == "July" || climateData.Month == "August" || climateData.Month == "September").ToList();
               return AvgTemp(warmMoths);
           }
           else
           {
               List<ClimateData> warmMoths = climate.Where(climateData => climateData.Month == "January" || climateData.Month == "February" || climateData.Month == "March" || climateData.Month == "October" || climateData.Month == "November" || climateData.Month == "December").ToList();
               return AvgTemp(warmMoths);
           }
       }

       public static double AvgColdMonths(List<ClimateData> climate, HemisphereEnum hemisphere)
       {
           if (hemisphere == HemisphereEnum.Northern)
           {
               List<ClimateData> coldMoths = climate.Where(climateData => climateData.Month == "January" || climateData.Month == "February" || climateData.Month == "March" || climateData.Month == "October" || climateData.Month == "November" || climateData.Month == "December").ToList();
               return AvgTemp(coldMoths);
           }
           else
           {
               List<ClimateData> coldMoths = climate.Where(climateData => climateData.Month == "April" || climateData.Month == "May" || climateData.Month == "June" || climateData.Month == "July" || climateData.Month == "August" || climateData.Month == "September").ToList();
               return AvgTemp(coldMoths);
           }
       }

       public static HemisphereEnum GetHemisphere(City inCity)
       {
           try
           {
               if (Convert.ToInt32(inCity.Info.Latitude) < 0.0)
                   return HemisphereEnum.Southern;
               else
                   return HemisphereEnum.Northern;
           }
           catch
           { return HemisphereEnum.Northern;}//If there is no data... return Nothern       
       }
    }
}
