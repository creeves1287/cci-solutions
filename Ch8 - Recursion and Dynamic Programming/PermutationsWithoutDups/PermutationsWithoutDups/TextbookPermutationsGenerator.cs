using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithoutDups
{
    public class TextbookPermutationsGenerator : IPermutationGenerator
    {
        public List<string> GeneratePermutations(string s)
        {
            if (s == null) return null;

            List<string> permutations = new List<string>();

            if (s.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            char first = s[0];
            string remainder = s.Substring(1);

            List<string> words = GeneratePermutations(remainder);

            foreach (string word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    string str = InsertCharAt(word, first, j);
                    permutations.Add(str);
                }
            }

            return permutations;
        }

        private string InsertCharAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end;
        }
    }
}
