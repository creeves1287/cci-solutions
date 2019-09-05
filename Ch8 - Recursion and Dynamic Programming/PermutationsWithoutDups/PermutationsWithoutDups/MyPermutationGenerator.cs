using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithoutDups
{
    public class MyPermutationGenerator : IPermutationGenerator
    {
        public List<string> GeneratePermutations(string s)
        {
            if (s == null) return null;
            List<string> permutations = GeneratePermutations(s, 0);
            return permutations;
        }

        private List<string> GeneratePermutations(string s, int k)
        {
            List<string> permutations = null;
            if (k >= s.Length - 1)
            {
                permutations = new List<string>();
                permutations.Add(s[s.Length - 1].ToString());
                return permutations;
            }
            List<string> prepermutations = GeneratePermutations(s, k + 1);
            permutations = WeavePermutations(prepermutations, s[k]);
            return permutations;
        }

        private List<string> WeavePermutations(List<string> prepermutations, char c)
        {
            List<string> permutations = new List<string>();
            for (int i = 0; i < prepermutations.Count; i++)
            {
                string prepermutation = prepermutations[i];
                WeavePermutations(permutations, prepermutation, c);
            }
            return permutations;
        }

        private void WeavePermutations(List<string> permutations, string prepermutation, char c)
        {
            StringBuilder permutation = new StringBuilder(prepermutation);
            for (int i = 0; i < prepermutation.Length; i++)
            {
                permutation.Insert(i, c);
                permutations.Add(permutation.ToString());
                permutation.Remove(i, 1);
            }
            permutation.Append(c);
            permutations.Add(permutation.ToString());
        }
    }
}
