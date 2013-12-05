using System;
using System.Collections.Generic;
using System.Linq;


namespace StudyAbroad.DynamicLoading.Framework
{
    public class ParameterCollection
    {
        private List<Parameters> _parameters;

        public ParameterCollection()
        {
            _parameters = new List<Parameters>();
        }

        public bool HasParameter(Parameters inParam)
        {
            return _parameters.Contains(inParam);
        }

        public void AddParameter(Parameters inParam)
        {
         if(!HasParameter(inParam))
                _parameters.Add(inParam);
        }
    }
}
