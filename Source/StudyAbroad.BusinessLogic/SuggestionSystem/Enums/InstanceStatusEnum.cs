using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.BusinessLogic.SuggestionSystem.Enums
{
    public enum InstanceStatusEnum
    {
        NotInitialized = -1,
        Ready = 0,
        WaitingForAnswer = 1,
        ResultSetEmpty = 2,
        ResultSetUnderN = 3,
        LastQuestion = 4,
        Error = 5,
    }
}
