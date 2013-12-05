using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.CountryCodesConverter;

namespace StudyAbroad.DynamicLoading.ApiUtilities
{
   public static class DataBankClimateClient
    {
       private static ApiRequest GetApiRequest(string inBaseUri)
       {
           ApiRequest request = new ApiRequest(inBaseUri);
           return request;
       }

       public static ApiResponse ReadTemperature(City city)
       {
           string ISO3Code;
           try
           {
               ISO3Code = CountryCodesConverter.Iso2ToIso3Converter.Convert(city.Country().Code.ToUpper().Trim());
           }
           catch
           {
               ISO3Code = CountryCodesConverter.Iso2ToIso3Converter.Convert(city.ContainedBy.Code.ToUpper().Trim());
           }
           
           if (ISO3Code==string.Empty)    
               return new ApiResponse(string.Empty);

           ApiRequest request = GetApiRequest(Resources.Content.Uris.DataBankClimateTemperature+ISO3Code);
           return request.Execute();
       }

       public static ApiResponse ReadPrecipitation(City city)
       {
           string ISO3Code;
           try
           {
               ISO3Code = CountryCodesConverter.Iso2ToIso3Converter.Convert(city.Country().Code.ToUpper().Trim());
           }
           catch
           {
               ISO3Code = CountryCodesConverter.Iso2ToIso3Converter.Convert(city.ContainedBy.Code.ToUpper().Trim());
           }
           if (ISO3Code == string.Empty)
               return new ApiResponse(string.Empty);

           ApiRequest request = GetApiRequest(Resources.Content.Uris.DataBankClimatePrecipititaion + ISO3Code);
           return request.Execute();
       }
    }
}
