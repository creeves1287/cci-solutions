using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutationAnalyzer
{
    public class TextbookPermutationsAnalyzerWithSort : IPermutationsAnalyzer
    {
        public bool ArePermutations(string firstPhrase, string secondPhrase)
        {
            if (firstPhrase.Length != secondPhrase.Length)
            {
                return false;
            }
            string sortedFirstPhrase = Sort(firstPhrase);
            string sortedSecondPhrase = Sort(secondPhrase);
            bool result = sortedFirstPhrase.Equals(sortedSecondPhrase);
            return result;
        }

        public string Sort(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }
    }
}
