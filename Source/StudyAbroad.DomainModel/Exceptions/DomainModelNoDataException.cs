using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.DomainModel.Exceptions
{
    public class DomainModelNoDataException : NullReferenceException
    {
        public DomainModelNoDataException(string inMessage) : base(inMessage)
        {}
    }
}
