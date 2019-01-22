using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAwayAnalyzer
{
    public class OneAwayAnalyzerCompact : IOneAwayAnalyzer
    {
        public bool OneEditAway(string s, string t)
        {
            if (Math.Abs(s.Length - t.Length) > 1)
            {
                return false;
            }

            string s1 = (s.Length > t.Length) ? s : t;
            string s2 = (s.Length > t.Length) ? t : s;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;

            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (foundDifference)
                    {
                        return false;
                    }
                    foundDifference = true;

                    if (s1.Length == s2.Length)
                    {
                        index2++; // on replace, move shorter pointer
                    }
                }
                else
                {
                    index2++; // if matching, move shorter pointer
                }
                index1++; // always move longer pointer
            }

            return true;
        }
    }
}
