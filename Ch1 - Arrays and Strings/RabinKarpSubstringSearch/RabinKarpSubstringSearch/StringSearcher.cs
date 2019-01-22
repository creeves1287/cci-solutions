using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSubstringSearch
{
    public class StringSearcher
    {
        private int _base = 128;

        public int CountSubstringInstances(string subPhrase, string fullPhrase)
        {
            int count = 0;
            int subLength = subPhrase.Length;
            int fullLength = fullPhrase.Length;
            int searchHash = 0;
            int subHash = Hash(subPhrase, 0, subLength);

            for(int i = 0; i <= (fullLength - subLength); i++)
            {
                if (i == 0)
                {
                    searchHash = Hash(fullPhrase, i, subLength);
                }
                else
                {
                    searchHash = UpdateHash(searchHash, fullPhrase[i - 1], fullPhrase[i + subLength - 1], subLength);
                }
                if (searchHash == subHash)
                {
                    if(SubString(fullPhrase, i, subLength) == subPhrase)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int Hash(string phrase, int index, int length)
        {
            int hash = 0;
            for (int i = index; i < (index + length); i++)
            {
                int power = (length - (i - index) - 1);
                hash += phrase[i] * (int)Math.Pow(_base, power);
            }
            return hash;
        }

        private int UpdateHash(int hash, char charToRemove, char charToAdd, int length)
        {
            int newHash = hash - (charToRemove * (int)Math.Pow(_base, length - 1));
            newHash *= _base;
            newHash += charToAdd;
            return newHash;
        }

        private string SubString(string phrase, int index, int length)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = index; i < (length + index); i++)
            {
                builder.Append(phrase[i]);
            }
            return builder.ToString();
        }
    }
}
