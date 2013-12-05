using System;

namespace StudyAbroad.DataAccess.Exceptions
{
    public class DataAccessInvalidActionException : InvalidOperationException
    {
        public DataAccessInvalidActionException(string inMessage) : base(inMessage)
        {}
    }
}
