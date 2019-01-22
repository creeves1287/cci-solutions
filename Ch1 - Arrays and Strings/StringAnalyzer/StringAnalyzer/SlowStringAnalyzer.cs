using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalyzer
{
    public class SlowStringAnalyzer : IStringAnalyzer
    {
        public bool CharactersAreUnique(string phrase)
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                for (int j = i + 1; j < phrase.Length; j++)
                {
                    if (phrase[i] == phrase[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
