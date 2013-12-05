using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace StudyAbroad.DynamicLoading.FreebaseUtilities
{
    public class MqlRequest
    {
        private RestClient _restClient;
        private RestRequest _restRequest;

        public MqlRequest(string inBaseUri)
        {
            _restClient = new RestClient(inBaseUri);
            _restRequest = new RestRequest(Method.GET);
            SetParameter("key", Resources.Content.Uris.FreebaseApiServer);
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

        public MqlResponse Execute()
        {
            return new MqlResponse(_restClient.Get(_restRequest).Content);
        }
    }
}
