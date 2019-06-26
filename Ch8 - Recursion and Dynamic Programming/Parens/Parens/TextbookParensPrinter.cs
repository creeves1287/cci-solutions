using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parens
{
    public class TextbookParensPrinter : IParensPrinter
    {
        public IEnumerable<string> PrintParens(int n)
        {
            return PrintParensHelper(n);
        }

        private ISet<string> PrintParensHelper(int n)
        {
            ISet<string> set = new HashSet<string>();
            if (n == 0)
            {
                set.Add("");
            }
            else
            {
                ISet<string> prev = PrintParensHelper(n - 1);
                foreach(string s in prev)
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == '(')
                        {
                            string str = InsertInside(s, i);
                            /*Add str to set if it's not already in there.  Note:
                             * HashSet automatically checks for duplicates before
                             * adding, so an explicit check is unnecessary.*/
                            set.Add(str);
                        }
                    }
                    set.Add("()" + s);
                }
            }
            return set;
        }

        private string InsertInside(string s, int leftIndex)
        {
            string left = s.Substring(0, leftIndex + 1);
            string right = s.Substring(leftIndex + 1, (s.Length - leftIndex - 1));
            return left + "()" + right;
        }
    }
}
