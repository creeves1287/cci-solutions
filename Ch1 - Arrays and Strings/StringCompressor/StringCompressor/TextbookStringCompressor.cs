using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompressor
{
    public class TextbookStringCompressor : IStringCompressor
    {
        public string CompressString(string input)
        {
            StringBuilder compressed = new StringBuilder();
            int countConsecutive = 0;

            for (int i = 0; i < input.Length; i++)
            {
                countConsecutive++;

                if (i + 1 >= input.Length || input[i] != input[i + 1])
                {
                    compressed.Append(input[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            return (input.Length > compressed.Length) ? compressed.ToString() : input;
        }
    }
}
