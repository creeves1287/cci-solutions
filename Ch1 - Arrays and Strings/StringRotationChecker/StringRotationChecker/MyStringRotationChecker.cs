using RabinKarpSubstringSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRotationChecker
{
    public class MyStringRotationChecker : IStringRotationChecker
    {
        public bool IsRotatedString(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            int index = 0;

            for (int i = 0; i < s2.Length; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < s1.Length; j++)
                    {
                        if (s1[j] == s2[i])
                        {
                            index = j;
                            break;
                        }
                    }
                    return false;
                }

                if (s1[index] != s2[i])
                {
                    if (s1[0] == s2[i])
                    {
                        StringSearcher searcher = new StringSearcher(); 
                        string sub = BuildTailingSubstring(s2, i);
                        return searcher.CountSubstringInstances(s2, sub) > 0;
                    }
                    return false;
                }

                index++;

                if (index > s1.Length)
                {
                    return false;
                }
            }

            return false;
        }

        private string BuildTailingSubstring(string s, int index)
        {
            StringBuilder subString = new StringBuilder();
            for (int i = index; i < s.Length; i++)
            {
                subString.Append(s[i]);
            }
            return subString.ToString();
        }
    }
}
