using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.SuggestionSystem.Enums;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Framework
{
    public class ParameterCollection
    {
        private List<Parameter> _parameters;

        public ParameterCollection()
        {
            _parameters = new List<Parameter>();
        }

        public int Count()
        {
            return _parameters.Count;
        }

        public bool HasParameter(ParametersEnum inParameter)
        {
            var param = _parameters.FirstOrDefault(p => p.Name == inParameter);
            return param != null;
        }

        public bool HasAny()
        {
            return _parameters.Count(p => p.Value == "Any") != 0;
        }

        public void AddParameter(ParametersEnum inParameter, string inValue)
        {
            if(HasParameter(inParameter))
                throw new Exception("There already exists a parameter with this name: " + inParameter);
            _parameters.Add(new Parameter(inParameter, inValue));
        }

        public void AddParameter(Parameter parameter)
        {
            if (HasParameter(parameter.Name))
                throw new Exception("There already exists a parameter with this name: " + parameter.Name);
            _parameters.Add(parameter);
        }

        public string GetParameterValue(ParametersEnum inParameter)
        {
            if (!HasParameter(inParameter))
                throw new Exception("No parameter was found with the name: " + inParameter);
            return _parameters.First(p => p.Name == inParameter).Value;
        }
    }
}
