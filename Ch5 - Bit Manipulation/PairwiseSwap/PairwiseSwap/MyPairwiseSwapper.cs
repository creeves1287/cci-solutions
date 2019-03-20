using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairwiseSwap
{
    public class MyPairwiseSwapper : IPairwiseSwapper
    {
        public int SwapPairwiseBits(int n)
        {
            if (n < 2) return n;

            int counter = 0;
            int m = n;
            while (m != 0)
            {
                n = PairwiseSwap(n, m, counter);
                counter += 2;
                m >>= 2;
            }

            return n;
        }

        private int PairwiseSwap(int n, int m, int counter)
        {
            int mask = 3 << counter;
            n ^= mask;
            return n;
        }
    }
}
