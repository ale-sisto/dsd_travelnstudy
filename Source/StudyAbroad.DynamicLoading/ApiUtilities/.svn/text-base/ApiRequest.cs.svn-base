using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace StudyAbroad.DynamicLoading.ApiUtilities
{
    public class ApiRequest
    {
        private RestClient _restClient;
        private RestRequest _restRequest;

        public ApiRequest(string inBaseUri)
        {
            _restClient = new RestClient(inBaseUri);
            _restRequest = new RestRequest(Method.GET);
        }

        public void SetParameter(string inParamName, string inParamValue)
        {
            _restRequest.AddParameter(inParamName, inParamValue);
        }

        public void SetDataFormat(DataFormat inDataFormat)
        {
            _restRequest.RequestFormat = inDataFormat;
        }

        public void SetTextId(string inId)
        {
            Append(inId);
        }

        public void SetImageId(string inId)
        {
            Append(inId);
        }

        private void Append(string inAppend)
        {
            _restClient.BaseUrl += inAppend;
        }

        public ApiResponse Execute()
        {
            return new ApiResponse(_restClient.Get(_restRequest).Content);
        }
    }
}
