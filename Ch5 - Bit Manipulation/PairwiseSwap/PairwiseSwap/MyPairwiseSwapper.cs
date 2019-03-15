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
            if (n == 0) return n;

            int counter = 0;
            int m = n;
            while (m != 0)
            {
                if (((m >> 1) & 1) != (m & 1) )
                {
                    m ^= 1;
                    m ^= 2;
                }

                n = PairwiseSwap(n, m, counter);
                counter += 2;
                m >>= 2;
            }

            return n;
        }

        private int PairwiseSwap(int n, int m, int counter)
        {
            int mask = 0;
            mask |= (1 << counter) + (1 << counter * 2);
            m <<= counter;
            n &= m;
            n |= m;
            m >>= counter;
            return n;
        }
    }
}
