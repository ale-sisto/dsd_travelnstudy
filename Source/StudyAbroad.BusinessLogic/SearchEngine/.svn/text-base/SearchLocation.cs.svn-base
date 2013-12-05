using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SearchEngine.Enums;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.BusinessLogic.SearchEngine.SearchUtilites;

namespace StudyAbroad.BusinessLogic.SearchEngine
{
    class SearchLocation:Framework.SearchEngine<DomainModel.Core.Location>
    {
        public SearchLocation(List<Location> inData) : base(inData)
        {}

        public override List<SearchResult> Search(string inKeyWord, int count)
        {
            List<SearchResult> results = new List<SearchResult>();
            
            foreach (Location location in SearchingData)
            {

                if (location is University)
                {
                    double score = UniversityParseSearch((University)location, inKeyWord);

                    if (score > 0.2)
                    {
                        results.Add(new SearchResult(location.Name, score, SearchedBy.UniversityName, location));
                    }


                }
                else if (location is City)
                {
                    double score = CityParseSearch((City) location, inKeyWord);
                    if (score > 0.75)
                    {
                        results.Add(new SearchResult(location.Name, score,SearchedBy.CityName,location));
                    }
                }
            }
            results = results.OrderByDescending(x => x.Score).ToList().Distinct().ToList();
            if (count>results.Count)
            {
                return results;
            }
            return results.GetRange(0,count);
        }


        public override List<SearchResult> Search(string inKeyWord)
        {
            return Search(inKeyWord, 10);
        }

        private double UniversityParseSearch(University university,string inKeyWord)
        {
            double maxScore = FuzzySearch.CalculateScore(university.Name.ToLower().Trim(), inKeyWord.ToLower().Trim());

            string parsedString = RemoveCommonWords(university.Name);

            List<double> scoreList= new List<double>();
            scoreList.Add(FuzzySearch.CalculateScore(parsedString, inKeyWord.ToLower().Trim()));
            scoreList.Add(FuzzySearch.CalculateScore(RemoveCulturalSpecials(parsedString), inKeyWord.ToLower().Trim()));
            scoreList.Add(FuzzySearch.CalculateScore(RemoveCulturalSpecials(university.Name), inKeyWord.ToLower().Trim()));

            double maxInternal = scoreList.Max();
            if (maxScore < maxInternal && maxInternal>=0.80)
            {
                maxScore = maxInternal;
            }

            return maxScore;
        }

        private double CityParseSearch(City city, string inKeyWord)
        { 
            double score = FuzzySearch.CalculateScore(city.Name, inKeyWord);
            List<double> scoreList = new List<double>();
            scoreList.Add(FuzzySearch.CalculateScore(RemoveCulturalSpecials(city.Name), inKeyWord));
            scoreList.Add(FuzzySearch.CalculateScore(RemoveCulturalSpecials(city.Name), inKeyWord+" City"));
            double internalScore = scoreList.Max();
            return Math.Max(score, internalScore);
        }

        private string RemoveCulturalSpecials(string inString)
        {
            string newString = inString.Replace('Č', 'c').Replace('č','c');
            newString = newString.Replace('Ć', 'C').Replace('ć', 'c');
            newString = newString.Replace('Š', 'S').Replace('š', 's');
            newString = newString.Replace('Ž', 'Z').Replace('ž', 'z');
            newString = newString.Replace('Đ', 'D').Replace('đ', 'd');
            newString = newString.Replace('Ü', 'U').Replace('ü', 'u');
            newString = newString.Replace('Ű', 'U').Replace('ű', 'u');
            newString = newString.Replace('Ú', 'U').Replace('ú', 'u');
            newString = newString.Replace('Ů', 'U').Replace('ů', 'u');
            newString = newString.Replace('ß', 'B');
            newString = newString.Replace('Ö', 'O').Replace('ö', 'o');
            newString = newString.Replace('Ő', 'O').Replace('ő', 'o');
            newString = newString.Replace('Ó', 'O').Replace('ó', 'o');
            newString = newString.Replace('Ä', 'A').Replace('ä', 'a');
            newString = newString.Replace('Å', 'A').Replace('å', 'a');
            newString = newString.Replace('Á', 'A').Replace('á', 'a');
            newString = newString.Replace('Ë', 'E').Replace('ë', 'e');
            newString = newString.Replace('É', 'E').Replace('é', 'e');
            newString = newString.Replace('Ď', 'D').Replace('ď', 'd');
            newString = newString.Replace('Ť', 'T').Replace('ť', 't');
            newString = newString.Replace('Ñ', 'N').Replace('ñ', 'n');
            newString = newString.Replace('Ň', 'N').Replace('ň', 'n');          
            newString = newString.Replace('Ř', 'R').Replace('ř', 'r');
            newString = newString.Replace('ã', 'a').Replace('à', 'a');
            newString = newString.Replace('õ', 'o').Replace('ô', 'o');
            newString = newString.Replace('í', 'i').Replace('ê', 'e');


            return newString;
        }

        private string RemoveCommonWords(string inString)
        {
            string returnString = inString.ToLower().Replace("university", string.Empty);
            returnString = returnString.Replace("of", string.Empty);
            returnString = returnString.Replace("politecnico", string.Empty);
            returnString = returnString.Replace("di", string.Empty);
            returnString = returnString.Replace("the", string.Empty);
            returnString = returnString.Replace("sveuciliste", string.Empty);
            returnString = returnString.Replace("universidad", string.Empty);
            returnString = returnString.Replace("de", string.Empty);
            returnString = returnString.Replace("universität", string.Empty);
            returnString = returnString.Replace("université", string.Empty);
            returnString = returnString.Replace("école", string.Empty);
            return returnString.Trim();
        }
    } 
}
