using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;
using StudyAbroad.BusinessLogic.SuggestionSystem.Filters;
using StudyAbroad.BusinessLogic.SuggestionSystem.Framework;
using StudyAbroad.BusinessLogic.SuggestionSystem.Utils;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Questions
{
    public class RegionQuestion : Question
    {
        public RegionQuestion() : base (QuestionIdentifierEnum.RegionQuestion, ParametersEnum.RegionName)
        {
        }

        protected override string CreateQuestionString(Instance inCurrentInstance)
        {
            string questionText;
            if (inCurrentInstance.MemoryHasEntry(QuestionIdentifierEnum.ContinentQuestion))
            {
                var continentName = inCurrentInstance.GetMemory(QuestionIdentifierEnum.ContinentQuestion).GetParameterValue(ParametersEnum.ContinentName);
                questionText = "Which region in " + continentName + " would you like to go?";
            }
            else
            {
                questionText = "Which region in the world would you like to go?";
            }
            return questionText;
        }

        protected override List<string> CreateChoicesList(Instance inCurrentInstance)
        {
            var choices = base.CreateChoicesList(inCurrentInstance);
            if (inCurrentInstance.MemoryHasEntry(QuestionIdentifierEnum.ContinentQuestion))
            {
                var continentName = inCurrentInstance.GetMemory(QuestionIdentifierEnum.ContinentQuestion).GetParameterValue(ParametersEnum.ContinentName);
                choices.AddRange(BusinessLogic.Factories.BLLFactory.Location().Region().GetByContinentName(continentName).Select(r => r.Name).ToList());
            }
            else
            {
                choices.AddRange(BusinessLogic.Factories.BLLFactory.Location().Region().GetAll().Select(r => r.Name).ToList());
            }
            return choices;
        }


        protected override Filter GetFilter(Instance inCurrentInstance)
        {
            return new RegionFilter(inCurrentInstance);
        }

        public override Explanation GetExplanation(DomainModel.Core.University inUniversity, Instance inCurrentInstance)
        {
            var response = new List<string>();
            var regionName = inCurrentInstance.GetMemory(Id).GetParameterValue(Parameter);
            response.Add("You have selected the following geographical location: " + regionName);
            response.Add("The university is located in " + inUniversity.City.Name + " which is a city in " + inUniversity.City.Country().Name + ".");
            response.Add(inUniversity.City.Country().Name + " is situated in " + inUniversity.City.Country().ContainedBy.Name + ".");
            return new Explanation(Id, response);
        }

    }
}
