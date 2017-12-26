using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public static class StringExtension
    {
        public static string GetEclipsis(this string strValue, int intLength)
        {
            if (strValue.Length <= intLength)
            {
                return strValue;
            }

            return strValue.Substring(0, intLength).Trim() + "…"; // "…": ALT + 0133.
        }
    }
}
