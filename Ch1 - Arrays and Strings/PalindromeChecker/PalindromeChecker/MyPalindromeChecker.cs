using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class MyPalindromeChecker : IPalindromeChecker
    {
        public bool IsPermutationOfPalindrome(string phrase)
        {
            int[] characterCounts = new int[128]; //assumes ASCII characters

            if(phrase == null)
            {
                throw new ArgumentNullException("phrase");
            }

            if(phrase.Length == 0)
            {
                throw new ArgumentException("phrase has no characters");
            }

            phrase = phrase.ToLower();
            int spaces = 0;

            for (int i = 0; i < phrase.Length; i++)
            {
                char c = phrase[i];
                if (c == ' ')   
                {
                    spaces++;
                    continue;
                }
                characterCounts[c]++;
            }

            int oddCharactersCount = 0;

            for (int i = 0; i < characterCounts.Length; i++)
            {
                oddCharactersCount += (characterCounts[i] % 2);
            }

            if ((phrase.Length - spaces) % 2 == 0)
            {
                return (oddCharactersCount == 0);
            }

            return (oddCharactersCount == 1);
        }
    }
}
