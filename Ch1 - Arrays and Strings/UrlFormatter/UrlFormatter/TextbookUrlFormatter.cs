using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlFormatter
{
    public class TextbookUrlFormatter : ISpaceReplacer
    {
        public void ReplaceSpaces(char[] content, int trueLength)
        {
            if (content.Length == trueLength)
            {
                return;
            }

            int spaceCount = 0,
                charIndex;

            for (int i = 0; i < trueLength; i++)
            {
                if (content[i] == ' ')
                {
                    spaceCount++;
                }
            }

            charIndex = trueLength + spaceCount * 2;

            if (charIndex < content.Length)
            {
                content[charIndex + 1] = '\0';
            }

            for (int i = trueLength - 1; i >= 0; i--)
            {
                char c = content[i];

                if (c == ' ')
                {
                    content[--charIndex] = '0';
                    content[--charIndex] = '2';
                    content[--charIndex] = '%';
                }
                else
                {
                    content[--charIndex] = c;
                }
            }
        }
    }
}
