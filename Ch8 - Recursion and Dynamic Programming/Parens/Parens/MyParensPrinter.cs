using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parens
{
    public class MyParensPrinter : IParensPrinter
    {
        public IEnumerable<string> PrintParens(int n)
        {
            if (n < 1) return null;
            ParensCounter counter = new ParensCounter(n);
            string prefix = "";
            List<string> result = new List<string>();
            PrintParens(counter, result, prefix);
            return result;
        }

        private void PrintParens(ParensCounter counter, List<string> result, string prefix)
        {
            if (counter.Open == 0 && counter.Closed == 0)
            {
                result.Add(prefix);
                return;
            }

            if (counter.Open > 0)
            {
                counter.Open--;
                counter.Closed++;
                PrintParens(counter, result, prefix + '(');
                counter.Open++;
                counter.Closed--;
            }

            if (counter.Closed > 0)
            {
                counter.Closed--;
                PrintParens(counter, result, prefix + ')');
                counter.Closed++;
            }
        }
    }
}
