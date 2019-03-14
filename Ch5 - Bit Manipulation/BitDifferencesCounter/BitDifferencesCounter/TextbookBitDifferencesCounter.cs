using BitDifferencesCounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitDifferencesCounting
{
    public class TextbookBitDifferencesCounter : IBitDifferencesCounter
    {
        public int CountBitDifferences(int a, int b)
        {
            int counter = 0;

            for (int c = a ^ b; c != 0 ; c >>= 1)
            {
                counter += (c & 1);
            }

            return counter;
        }
    }
}
