using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class TextbookPalindromeCheckerWithBitVector : IPalindromeChecker
    {
        public bool IsPermutationOfPalindrome(string phrase)
        {
            int bitVector = CreateBitVector(phrase);
            return bitVector == 0 || CheckExactlyOneBitSet(bitVector);
        }

        private int CreateBitVector(string phrase)
        {
            int bitVector = 0;
            foreach (char c in phrase)
            {
                int characterNumber = GetCharacterNumber(c);
                
                bitVector = Toggle(bitVector, characterNumber);
            }
            return bitVector;
        }

        private int Toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;

            int mask = 1 << index;

            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= ~mask;
            }

            return bitVector;
        }

        private bool CheckExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
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
