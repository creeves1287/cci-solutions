using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalyzer
{
    public class TextbookStringAnalyzer : IStringAnalyzer
    {
        public bool CharactersAreUnique(string phrase)
        {
            // assumes ASCII character limit of 128
            if (phrase.Length > 128)
            {
                return false;
            }

            bool[] charSet = new bool[128];

            for (int i = 0; i < phrase.Length; i++)
            {
                int val = phrase[i];
                if (charSet[val])
                {
                    return false;
                }
                charSet[val] = true;
            }
            return true;
        }
    }
}
