using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyAbroad.Presentation.Helpers
{
    public static class FormatHelper
    {
        public static string FormatImageURL(string url)
        {
            if (url==null || !url.StartsWith("http"))
            {
                return "images/no_image.png";
            }
            else
            {
                return url;
            }
        }

        public static string FormatSiteURL(string url)
        {
            if (!url.StartsWith("http"))
            {
                return "#";
            }
            else
            {
                return url;
            }

        }
    }
}