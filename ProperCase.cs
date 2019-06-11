using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Isas
{
    public static class ProperCase
    {
        // Capitalise the first character and capitalise each letter
        // after the space.
        public static string ToProperCase(string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null) return theString;
            if (theString.Length < 2) return theString.ToUpper();

            theString = theString.ToLower();

            // Start with the first character.
            string result = theString.Substring(0, 1).ToUpper();
            int capNext = 0;

            // Add the remaining characters.
            for (int i = 1; i < theString.Length; i++)
            {
                var s = theString[i].ToString();

                s = (capNext == 1) ? s.ToUpper() : s;
                capNext = 0;

                if (char.IsWhiteSpace(theString[i]))
                    capNext = 1;

                result += s;
            }

            return result;
        }
    }
}
