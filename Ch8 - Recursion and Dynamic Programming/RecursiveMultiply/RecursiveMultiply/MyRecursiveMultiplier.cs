using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMultiply
{
    public class MyRecursiveMultiplier : IRecursiveMultiplier
    {
        public long Multiply(int a, int b)
        {
            if (a == 0 || b == 0) return 0;
            if (a == 1) return b;
            if (b == 1) return a;
            int sum = a + a;
            long result = Multiply(sum, b / 2);
            if (b % 2 == 1)
            {
                result += a;
            }
            return result;
        }
    }
}
