using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.DynamicLoading.ApiUtilities
{
    public class ApiResponse
    {
        public string JsonResult { get; set; }
        public dynamic ObjectResult { get; set; }

        public ApiResponse(string inJsonResult)
        {
            JsonResult = inJsonResult;
            ObjectResult = GetDynamic(inJsonResult);
        }

        private static dynamic GetDynamic(string inJson)
        {
            return System.Web.Helpers.Json.Decode(inJson);
        }
    }
}
