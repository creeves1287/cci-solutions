using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder
{
    public class StringBuilder
    {
        private List<string> _strings;

        public StringBuilder()
        {
            _strings = new List<string>();
        }

        public void Append(string phrase)
        {
            _strings.Add(phrase);
        }

        public override string ToString()
        {
            string result = null;

            if(_strings.Count == 0)
            {
                throw new ArgumentException("No values to return");
            }

            for(int i = 0; i < _strings.Count; i++)
            {
                if (result == null)
                {
                    result = "";
                }

                string phrase = _strings[i];
                result += phrase;
            }

            return result;
        }
    }
}
