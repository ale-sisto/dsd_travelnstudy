using System.Collections.Generic;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.DynamicLoading.Framework
{
    /// <summary>
    /// Interface for loader configurations
    /// </summary>
    public abstract class LoaderConfiguration
    {
        public Dictionary<string, string> Parameters { get; set; } 

        public LoaderConfiguration()
        {
            Parameters = new Dictionary<string, string>();
        }

        public abstract void Setup(DataEntity inEntity, InfoDomainEnum inDomain, InfoCategoryEnum inCategory);

        protected void SetUriParameter(string inUri)
        {
            SetParameter("Uri", inUri);
        }

        protected void SetSearchParameters(string inQueryText, string inType)
        {
            SetParameter("QueryText", inQueryText);
            SetParameter("Type", inType);
        }

        protected void SetMid(string inMid)
        {
            SetParameter("Mid", inMid);
        }

        private bool HasParameter(string inParameterName)
        {
            return Parameters.ContainsKey(inParameterName);
        }

        public string GetParameter(string inParameterName)
        {
            return HasParameter(inParameterName) ? Parameters[inParameterName] : null;
        }

        public void SetParameter(string inParameterName, string inParameterValue)
        {
            if (HasParameter(inParameterName))
                Parameters[inParameterName] = inParameterValue;
            else
                Parameters.Add(inParameterName, inParameterValue);
        }
    }
}
