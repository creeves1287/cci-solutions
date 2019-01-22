using RabinKarpSubstringSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRotationChecker
{
    public class TextbookStringRotationChecker : IStringRotationChecker
    {
        public bool IsRotatedString(string s1, string s2)
        {
            int length = s1.Length;

            if (length == s2.Length && length > 0)
            {
                StringSearcher searcher = new StringSearcher();
                string s1s1 = s1 + s1;
                return (searcher.CountSubstringInstances(s2, s1s1) > 0);
            }

            return false;
        }
    }
}
