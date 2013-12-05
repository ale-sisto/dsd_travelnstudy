using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace StudyAbroad.DynamicLoading.ApiUtilities
{
    public class NumbeoClient
    {
        private static ApiRequest GetApiRequest(string inBaseUri)
        {
            ApiRequest mqlRequest = new ApiRequest(inBaseUri);
            mqlRequest.SetParameter("api_key", Resources.Content.Uris.NumbeoApiKey);
            return mqlRequest;
        }

        public static ApiResponse Read(string city, string country)
        {
            var mqlRequest = GetApiRequest(Resources.Content.Uris.NumbeoCityPrices);

            city = StringFixes(city);
            country = StringFixes(country);

            mqlRequest.SetParameter("city", city);
            mqlRequest.SetParameter("country", country);
            mqlRequest.SetParameter("currency", "EUR");
            mqlRequest.SetDataFormat(DataFormat.Json);

            return mqlRequest.Execute();
        }

        public static ApiResponse Read(string query)
        {
            var mqlRequest = GetApiRequest(Resources.Content.Uris.NumbeoCityPrices);

            query = StringFixes(query);

            mqlRequest.SetParameter("query", query);
            mqlRequest.SetParameter("currency", "EUR");
            mqlRequest.SetDataFormat(DataFormat.Json);

            return mqlRequest.Execute();
        }

        public static string StringFixes(string inString)
        {
            inString = inString.Replace('ü', 'u');
            inString = inString.Replace('è', 'e');
            inString = inString.Replace('ö', 'o');
            inString = inString.Replace('é', 'e');
            inString = inString.Replace('ç', 'c');
            inString = inString.Replace('É', 'E');
            return inString;
        }
    }
}
