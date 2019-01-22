using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompressor
{
    public class TextbookStringCompressorWithLengthCheck : IStringCompressor
    {
        public string CompressString(string input)
        {
            int finalLength = CountCompression(input);

            if (finalLength >= input.Length) return input;

            StringBuilder compressed = new StringBuilder(finalLength);
            int countConsecutive = 0;

            for (int i = 0; i < input.Length; i++)
            {
                countConsecutive++;

                if (NextCharacterNotTheSame(input, i))
                {
                    compressed.Append(input[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            return compressed.ToString();
        }

        private int CountCompression(string input)
        {
            int countConsecutive = 0;
            int compressedLength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                countConsecutive++;

                if (NextCharacterNotTheSame(input, i))
                {
                    compressedLength += 1 + countConsecutive.ToString().Length;
                    countConsecutive = 0;
                }
            }

            return compressedLength;
        }

        private bool NextCharacterNotTheSame(string input, int index)
        {
            return (index + 1 >= input.Length || input[index] != input[index + 1]);
        }
    }
}
