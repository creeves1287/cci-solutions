using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitDifferencesCounting
{
    public class MyBitDifferencesCounter : IBitDiffernecesCounter
    {
        public int CountBitDifferences(int n, int m)
        {
            if (n == m) return 0;

            int counter = 0;
            while (m != 0 || n != 0)
            {
                if ((n & 1) != (m & 1))
                    counter++;

                n >>= 1;
                m >>= 1;
            }

            return counter;
        }
    }
}
