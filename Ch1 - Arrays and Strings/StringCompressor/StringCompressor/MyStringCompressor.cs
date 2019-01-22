using System.Text;

namespace StringCompressor
{
    public class MyStringCompressor : IStringCompressor
    {
        public string CompressString(string input)
        {
            StringBuilder builder = new StringBuilder();
            int counter = 0;
            char previousCharacter = '\0';

            foreach (char c in input)
            {
                if (counter == 0)
                {
                    builder.Append(c);
                    previousCharacter = c;
                    counter++;
                    continue;
                }

                if (previousCharacter == c)
                {
                    counter++;
                    continue;
                }

                builder.Append(counter);
                builder.Append(c);
                counter = 1;
                previousCharacter = c;
            }

            builder.Append(counter);
            string result = builder.ToString();

            if (result.Length >= input.Length) 
            {
                return input;
            }

            return result;
        }
    }
}
