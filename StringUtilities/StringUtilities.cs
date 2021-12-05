using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StringUtilities
{
    public static class StringUtilities
    {
        public static bool IsUniqueCharacterSet(this string s)
        {
            // remove all space chars from string
            var cleanString = Regex.Replace(s, @"[\s+]", "").ToLower();

            // make a hash table/set
            HashSet<char> characters = new HashSet<char>();

            foreach (char c in cleanString)
            {
                if (characters.Contains(c))
                {
                    return false;
                }
                else
                {
                    characters.Add(c);
                }
            }

            return true;
        }
    }
}
