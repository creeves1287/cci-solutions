using System.Collections.Generic;

namespace Parens
{
    public interface IParensPrinter
    {
        IEnumerable<string> PrintParens(int n);
    }
}