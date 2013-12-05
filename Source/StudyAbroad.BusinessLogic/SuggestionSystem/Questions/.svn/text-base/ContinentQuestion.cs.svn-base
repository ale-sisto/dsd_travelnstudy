using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Filters;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Questions
{
    public class ContinentQuestion : Question
    {
        //Pass the question id and the question parameter to the interface
        public ContinentQuestion() : base(QuestionIdentifierEnum.ContinentQuestion, ParametersEnum.ContinentName)
        {
        }

        //Create the question request(question id, question text and choices)
        //Here i check if perhaps the region question already exists, in that case only 
        //the region continent can be shown as a choice
        protected override string CreateQuestionString(Instance inCurrentInstance)
        {
            return "Which continent would you like to go?";
        }

        protected override List<string> CreateChoicesList(Instance inCurrentInstance)
        {
            var choices = base.CreateChoicesList(inCurrentInstance);
            if (inCurrentInstance.MemoryHasEntry(QuestionIdentifierEnum.RegionQuestion))
            {
                var regionName = inCurrentInstance.GetMemory(QuestionIdentifierEnum.RegionQuestion).GetParameterValue(ParametersEnum.RegionName);
                var continentName = BLLFactory.Location().GetByName(regionName).ContainedBy.Name;
                choices.Add(continentName);
            }
            else
            {
                choices.AddRange(BLLFactory.Location().Continent().GetAll().Select(c => c.Name).ToList());
            }
            return choices;
        }

        //Simply return the continent filter
        protected override Filter GetFilter(Instance inCurrentInstance)
        {
            return new ContinentFilter(inCurrentInstance);
        }

        public override Explanation GetExplanation(University inUniversity, Instance inCurrentInstance)
        {
            var response = new List<string>();
            var continentName = inCurrentInstance.GetMemory(Id).GetParameterValue(Parameter);
            response.Add("You have selected the following geographical location: " + continentName);
            response.Add("The university is located in " + inUniversity.City.Name + " which is a city in " + inUniversity.City.Country().Name+".");
            response.Add(inUniversity.City.Country().Name + " is situated in " + inUniversity.City.Country().ContainedBy.Name+".");
            return new Explanation(Id, response);
        }


    }
}
