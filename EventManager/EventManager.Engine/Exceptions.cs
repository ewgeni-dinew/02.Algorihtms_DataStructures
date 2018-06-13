using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Engine
{
    static class Exceptions
    {
        internal const string nonExistingEventMsg = "Event with given Name, does not exist!";
        internal const string alreadyExistingEventMsg = "Event with given Name already exists in the database!";
        internal const string invalidStartDate = "Invalid Event Start Date format!";
        internal const string invalidEndDate = "Invalid Event End Date format!";
    }
}
