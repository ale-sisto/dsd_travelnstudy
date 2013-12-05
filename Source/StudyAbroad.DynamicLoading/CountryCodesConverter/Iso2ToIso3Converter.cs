using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DynamicLoading.Resources.Content;

namespace StudyAbroad.DynamicLoading.CountryCodesConverter
{
    class Iso2ToIso3Converter
    {
        public static string Convert(string ISO2Code)
        {
            string codes = CountryCodes.ISOCountryCodes;
            foreach (
                var codeLine in
                    codes
                        .Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (codeLine.Split(' ')[0] == ISO2Code)
                {
                    return codeLine.Split(' ')[1];
                    break;
                }
            }
            return string.Empty;
        }
    }
}
