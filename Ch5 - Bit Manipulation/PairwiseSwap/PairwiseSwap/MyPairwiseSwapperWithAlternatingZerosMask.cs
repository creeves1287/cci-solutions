using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairwiseSwap
{
    public class MyPairwiseSwapperWithAlternatingZerosMask : IPairwiseSwapper
    {
        public int SwapPairwiseBits(int n)
        {
            int evenMask = GetEvenMask(n);
            int oddMask = GetOddMask(n);
            int result = PairwiseSwap(n, evenMask, oddMask);
            return result;
        }

        private int GetEvenMask(int n)
        {
            uint mask = 0xAAAAAAAA;
            return (int)mask;
        }

        private int GetOddMask(int n)
        {
            uint mask = 0x55555555;
            return (int)mask;
        }

        private int PairwiseSwap(int n, int evenMask, int oddMask)
        {
            int eventResult = (n & evenMask);
            eventResult >>= 1;
            int oddResult = (n & oddMask);
            oddResult <<= 1;
            return (eventResult | oddResult);
        }
    }
}
