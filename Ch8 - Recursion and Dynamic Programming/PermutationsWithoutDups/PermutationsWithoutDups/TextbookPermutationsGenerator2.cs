using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithoutDups
{
    public class TextbookPermutationsGenerator2 : IPermutationGenerator
    {
        public List<string> GeneratePermutations(string s)
        {
            List<string> result = new List<string>();
            GeneratePermutations("", s, result);
            return result;
        }

        private void GeneratePermutations(string prefix, string remainder, List<string> result)
        {
            if (remainder.Length == 0) result.Add(prefix);

            int len = remainder.Length;
            for (int i = 0; i < len; i++)
            {
                string before = remainder.Substring(0, i);
                string after = remainder.Substring(i + 1, len);
                char c = remainder[i];
                GeneratePermutations(prefix + c, before + after, result);
            }
        }
    }
}
