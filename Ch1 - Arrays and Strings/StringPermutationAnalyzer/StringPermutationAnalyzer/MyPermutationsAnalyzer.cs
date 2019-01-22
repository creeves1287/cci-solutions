using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutationAnalyzer
{
    public class MyPermutationsAnalyzer : IPermutationsAnalyzer
    {
        public bool ArePermutations(string firstPhrase, string secondPhrase)
        {
            if (firstPhrase.Length != secondPhrase.Length)
            {
                return false;
            }
            int hash = 0;
            for (int i = 0; i < firstPhrase.Length; i++)
            {
                hash += firstPhrase[i];
            }
            for (int i = 0; i < secondPhrase.Length; i++)
            {
                hash -= secondPhrase[i];
            }
            return (hash == 0);
        }
    }
}
