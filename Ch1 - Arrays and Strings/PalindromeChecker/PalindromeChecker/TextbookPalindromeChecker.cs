using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class TextbookPalindromeChecker : IPalindromeChecker
    {
        public bool IsPermutationOfPalindrome(string phrase)
        {
            int[] table = BuildCharacterFrequencyTable(phrase);
            return CheckMaxOneOdd(table);
        }

        private int[] BuildCharacterFrequencyTable(string phrase)
        {
            int[] table = new int['z' - 'a' + 1];
            for (int i = 0; i < phrase.Length; i++)
            {
                char c = phrase[i];
                int characterNumber = GetCharacterNumber(c);

                if (characterNumber != -1)
                {
                    table[characterNumber]++;
                }
            }
            return table;
        }

        private bool CheckMaxOneOdd(int [] table)
        {
            bool foundOdd = false;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }

                    foundOdd = true;
                }
            }

            return true;
        }

        private int GetCharacterNumber(char c)
        {
            int a = 'a';
            int z = 'z';
            int lowerC = char.ToLower(c);

            if (lowerC >= a && lowerC <= z)
            {
                return lowerC - a;
            }

            return -1;
        }
    }
}
