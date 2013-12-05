using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.DomainModel.Exceptions
{
    public class DomainModelValidationException : ArgumentException
    {
        public DomainModelValidationException(string inMessage, string inParamName) : base(inMessage, inParamName)
        {}
    }
}
