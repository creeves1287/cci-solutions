using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parens
{
    public class TextbookParensPrinterEfficient : IParensPrinter
    {
        public IEnumerable<string> PrintParens(int n)
        {
            char[] str = new char[n * 2];
            List<string> result = new List<string>();
            AddParens(result, n, n, str, 0);
            return result;
        }

        private void AddParens(List<string> result, int leftRemaining, int rightRemaining, char[] str, int index)
        {
            if (leftRemaining < 0 || rightRemaining < leftRemaining) return;

            if (leftRemaining == 0 && rightRemaining == 0)
            {
                result.Add(new string(str));
            }
            else
            {
                str[index] = '(';
                AddParens(result, leftRemaining - 1, rightRemaining, str, index + 1);
                str[index] = ')';
                AddParens(result, leftRemaining, rightRemaining - 1, str, index + 1);
            }
        }
    }
}
