using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace StudyAbroad.DynamicLoading.ApiUtilities
{
    public class FreebaseClient
    {
        private const int MAX_PROP_IN_QUERY = 8;

        public static dynamic ActiveQuery { get; set; }
        public static int QueryPropertiesCount { get; set; }

        private static ApiRequest GetApiRequest(string inBaseUri)
        {
            ApiRequest mqlRequest = new ApiRequest(inBaseUri);
            mqlRequest.SetParameter("key", Resources.Content.Uris.FreebaseApiServer);
            return mqlRequest;
        }

        public static ApiResponse MqlImage(string inId)
        {
            ApiRequest mqlRequest = GetApiRequest(Resources.Content.Uris.FreebaseRawImage);
            mqlRequest.SetImageId(inId);

            return mqlRequest.Execute();
        }

        public static ApiResponse MqlText(string inId, string inFormat, int inLength = 0)
        {
            var mqlRequest = GetApiRequest(Resources.Content.Uris.FreebaseRawText);

            mqlRequest.SetTextId(inId);
            mqlRequest.SetParameter("prettyPrint", "true");
            mqlRequest.SetParameter("format", inFormat);
            if (inLength != 0)
                mqlRequest.SetParameter("maxlength", inLength.ToString());

            return mqlRequest.Execute();
        }

        public static ApiResponse Search(string inQueryString, string inType = null, string inMqlOutput = "[{\"mid\" : null}]", int inLimit = 1)
        {
            var mqlRequest = GetApiRequest(Resources.Content.Uris.FreebaseSearch);

            mqlRequest.SetParameter("query", inQueryString);
            mqlRequest.SetParameter("mql_output", inMqlOutput);
            mqlRequest.SetParameter("limit", inLimit.ToString());
            if (inType != null)
                mqlRequest.SetParameter("type", inType);

            return mqlRequest.Execute();
        }

        public static ApiResponse MqlRead(string inMqlQuery)
        {
            var mqlRequest = GetApiRequest(Resources.Content.Uris.FreebaseQuery);

            mqlRequest.SetParameter("query", inMqlQuery);
            mqlRequest.SetDataFormat(DataFormat.Json);

            return mqlRequest.Execute();
        }

        public static ApiResponse MqlRead(dynamic inMqlObject)
        {
            var query = new Google.Apis.Freebase.v1.FreebaseService().SerializeObject(inMqlObject);
            return MqlRead(query);
        }

        public static ApiResponse MqlRead()
        {
            var query = new Google.Apis.Freebase.v1.FreebaseService().SerializeObject(ActiveQuery);
            return MqlRead(query);
        }

        public static void InitiateMqlObject()
        {
            ActiveQuery = new ExpandoObject();
            QueryPropertiesCount = 0;
        }

        public static void InitiateMqlObject(string inMid)
        {
            dynamic obj = new ExpandoObject();
            obj.mid = inMid;
            ActiveQuery = obj;
            QueryPropertiesCount = 0;
        }

        public static void InitiateMqlObject(string inMid, string inType)
        {
            dynamic obj = new ExpandoObject();
            obj.mid = inMid;
            obj.type = inType;
            ActiveQuery = obj;
            QueryPropertiesCount = 0;
        }

        public static string GetMid(string inQuery)
        {
            var response = Search(inQuery);
            return response.ObjectResult.result[0].mid;
        }

        public static string GetMid(string inQuery, string inType)
        {
            try
            {
                var response = Search(inQuery, inType);
                return response.ObjectResult.result[0].mid; 
            }
            catch
            {
                throw new Exception("Search returned with no results!");
            } 
        }

        public static bool AddMqlProperty(string inString, object inObject)
        {
            (ActiveQuery as IDictionary<String, Object>).Add(inString, inObject);
            QueryPropertiesCount++;
            if (QueryPropertiesCount >= MAX_PROP_IN_QUERY)
                return true;
            return false;
        }

    }
}
