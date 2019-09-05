using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithDups
{
    public class PermutationsGenerator : IPermutationsGenerator
    {
        public List<string> GeneratePermutations(string s)
        {
            List<string> result = new List<string>();
            Dictionary<char, int> dict = GenerateFrequenciesTable(s);
            GeneratePermutations(result, dict, "", s.Length);
            return result;
        }

        private Dictionary<char, int> GenerateFrequenciesTable(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            return dict;
        }

        private void GeneratePermutations(List<string> result, Dictionary<char, int> dict, string prefix, int remainder)
        {
            if (remainder == 0)
            {
                result.Add(prefix);
                return;
            }

            List<char> keys = dict.Keys.ToList();
            foreach (char c in keys)
            {
                int count = dict[c];
                if (count > 0)
                {
                    dict[c]--;
                    GeneratePermutations(result, dict, prefix + c, remainder - 1);
                    dict[c]++;
                }
            }
        }
    }
}
