using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAwayAnalyzer
{
    public class OneAwayAnalyzer : IOneAwayAnalyzer
    {
        public bool OneEditAway(string s, string t)
        {
            if (s.Length - t.Length == 1)
            {
                return OneInsertAway(t, s);
            }

            if (t.Length - s.Length == 1)
            {
                return OneInsertAway(s, t);
            }

            if (s.Length == t.Length)
            {
                return OneReplaceAway(s, t);
            }

            return false;
        }

        private bool OneInsertAway(string phrase, string phraseWithInsert)
        {
            int phraseIndex = 0;
            int insertPhraseIndex = 0;
            bool oneFound = false;

            while (phraseIndex < phrase.Length && insertPhraseIndex < phraseWithInsert.Length)
            {
                char phraseCharacter = phrase[phraseIndex];
                char insertPhraseCharacter = phraseWithInsert[insertPhraseIndex];

                if (phraseCharacter != insertPhraseCharacter)
                {
                    if (oneFound)
                    {
                        return false;
                    }
                    oneFound = true;
                    insertPhraseIndex++;
                }
                else
                {
                    phraseIndex++;
                    insertPhraseIndex++;
                }
            }

            return true;
        }

        private bool OneReplaceAway(string phrase, string phraseWithReplace)
        {
            bool oneFound = false;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] != phraseWithReplace[i])
                {
                    if (oneFound)
                    {
                        return false;
                    }
                    oneFound = true;
                }
            }
            return true;
        }
    }
}
