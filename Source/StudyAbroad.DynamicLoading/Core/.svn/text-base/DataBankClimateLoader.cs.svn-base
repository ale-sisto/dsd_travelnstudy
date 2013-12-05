using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Framework;
using StudyAbroad.DynamicLoading.ApiUtilities;

namespace StudyAbroad.DynamicLoading.Core
{
   public class DataBankClimateLoader : Loader<City>
    {
        public DataBankClimateLoader(LoaderConfiguration inConfiguration)
            : base(inConfiguration){}

        public override void Load(List<City> items)
        {
            throw new Exception("No loading of cities is implemented from the DataBank Climate data source.");
        }

        public override void Update(City city, ParameterCollection parameters)
        {
            ApiResponse temperatureResponse = DataBankClimateClient.ReadTemperature(city);
            ApiResponse precipitationResponse = DataBankClimateClient.ReadPrecipitation(city);
            ParseResult(temperatureResponse.ObjectResult,precipitationResponse.ObjectResult,city);
        }

        private void ParseResult(dynamic temperatureResponse, dynamic precipitationResponse, City city)
        {
            city.Info.Climate=new List<ClimateData>();
            try
            {
                foreach (dynamic temperatureData in temperatureResponse)
                {
                    decimal avgtemperature = temperatureData.data;
                    CultureInfo usEnglish = new CultureInfo("en-US");
                    DateTimeFormatInfo englishInfo = usEnglish.DateTimeFormat;
                    string month = englishInfo.MonthNames[temperatureData.month];
                    decimal avgRainfall=0;
                    foreach (dynamic precipitationData in precipitationResponse)
                    {
                        if (precipitationData.month==temperatureData.month)
                        {
                            avgRainfall = precipitationData.data;
                            break;
                        }
                    }
                    city.Info.Climate.Add(new ClimateData(month,avgtemperature,avgtemperature,avgRainfall));
                }
            }
            catch
            {}
        }

       

    }
}
