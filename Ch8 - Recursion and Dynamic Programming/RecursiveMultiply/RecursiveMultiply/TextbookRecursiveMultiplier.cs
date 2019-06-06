using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMultiply
{
    public class TextbookRecursiveMultiplier : IRecursiveMultiplier
    {
        public long Multiply(int a, int b)
        {
            int bigger = a < b ? b : a;
            int smaller = a < b ? a : b;
            return MultiplyHelper(bigger, smaller);
        }

        private long MultiplyHelper(int bigger, int smaller)
        {
            if (smaller == 0) return 0;
            if (smaller == 1) return bigger;

            int s = smaller >> 1;
            long halfProd = MultiplyHelper(bigger, s);

            if (smaller % 2 == 0)
                return halfProd + halfProd;

            return halfProd + halfProd + bigger;
        }
    }
}
