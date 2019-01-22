using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutationAnalyzer
{
    public class TextbookPermutationsAnalyzerCountingCharacters : IPermutationsAnalyzer
    {
        public bool ArePermutations(string firstPhrase, string secondPhrase)
        {
            if (firstPhrase.Length != secondPhrase.Length)
            {
                return false;
            }
            int[] characters = new int[128]; // assumes ASCII character set

            for (int i = 0; i < firstPhrase.Length; i++)
            {
                char c = firstPhrase[i];
                characters[c]++;
            }

            for (int i = 0; i < secondPhrase.Length; i++)
            {
                char c = secondPhrase[i];
                characters[c]--;
                if (characters[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
