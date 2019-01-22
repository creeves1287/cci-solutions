using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class TextbookPalindromeCheckerAlternate : IPalindromeChecker
    {
        public bool IsPermutationOfPalindrome(string phrase)
        {
            int countOdd = 0;
            int[] table = new int['z' - 'a' + 1];

            foreach (char c in phrase)
            {
                int characterNumber = GetCharacterNumber(c);

                if (characterNumber != -1)
                {
                    table[characterNumber]++;

                    if (table[characterNumber] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                    {
                        countOdd--;
                    }
                }
            }

            return (countOdd <= 1);
        }

        private int GetCharacterNumber(char c)
        {
            char lowerC = char.ToLower(c);
            if (lowerC >= 'a' && lowerC <= 'z')
            {
                return lowerC - 'a';
            }
            return -1;
        }
    }
}
