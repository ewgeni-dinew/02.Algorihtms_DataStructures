using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Models
{
    static class Exceptions
    {
        internal const string invalidNameString = "Event Name cannot be null or empty.";
        internal const string invalidNameLength = "Event Name length cannot be less than 3 symbols.";
        internal const string invalidNameSymbols = "Event Name must contain at least 3 letters.";
                 
        internal const string invalidLocationString = "Event Location cannot be null or empty.";
        internal const string invalidLocationLength = "Event Location length cannot be less than 3 symbols.";
                 
        internal const string invalidEndDate = "Invalid End Date. Cannot be before Start Date!";
    }
}
