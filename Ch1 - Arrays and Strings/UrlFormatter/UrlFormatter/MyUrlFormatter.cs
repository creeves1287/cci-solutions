using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlFormatter
{
    public class MyUrlFormatter : IUrlFormatter
    {
        public string Urlify(string phrase, int length)
        {
            char[] characters = new char[phrase.Length];
            int charIndex = 0;

            for (int i = 0; i < length; i++)
            {
                char c = phrase[i];
                if (c == ' ')
                {
                    characters[charIndex++] = '%';
                    characters[charIndex++] = '2';
                    characters[charIndex++] = '0';
                }
                else
                {
                    characters[charIndex++] = c;
                }
            }

            return new string(characters);
        }
    }
}
