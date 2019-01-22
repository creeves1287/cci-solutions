using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalyzer
{
    public class MyStringAnalyzer : IStringAnalyzer
    {
        public bool CharactersAreUnique(string phrase)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < phrase.Length; i++)
            {
                char phraseCharacter = phrase[i];
                if (dict.ContainsKey(phraseCharacter))
                {
                    return false;
                }
                dict.Add(phraseCharacter, i);
            }
            return true;
        }
    }
}
