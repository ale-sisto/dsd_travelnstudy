using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.BusinessLogic.SearchEngine.SearchUtilites
{
   public  static class FuzzySearch
    {
       public static double CalculateScore(string inFirstString, string inSecondString)
       {
           // Calculate the Levenshtein-distance:
           int levenshteinDistance = LevenshteinDistance.Compute(inFirstString.ToLower(), inSecondString.ToLower());

           // Length of the longer string:
           int length = Math.Max(inFirstString.Length, inSecondString.Length);

           // Calculate the score:
           return (1.0 - (double)levenshteinDistance / length);
          
       }
    }
}
