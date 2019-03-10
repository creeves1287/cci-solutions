using System;
using System.Collections.Generic;
using System.Text;

namespace NextNumberFinder
{
    public class TextbookNextNumberFinderWithArithmetic : INextNumberFinder
    {
        public NextNumbers GetNextNumbers(int n)
        {
            if (n < 1 || n == int.MaxValue) return null;

            NextNumbers result = new NextNumbers();
            result.Next = GetNextNumber(n);
            result.Previous = GetPreviousNumber(n);
            return result;
        }

        //1000111000 => 1001000000 => 1001000100 => 1001000011
        //11011101111 => 11011110000 => 11011110111
        private int GetNextNumber(int n)
        {
            int c0 = 0,
                c1 = 0;

            int c = n;

            while ((c & 1) == 0 && c != 0)
            {
                c0++;
                c >>= 1;
            }

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            int p = c0 + c1;
            int result = n + (1 << c0) + (1 << (c1 - 1)) - 1;
            //Simplified: int result = n + (1 << (p - 1));
            return result;
        }

        //1000111000 => 1000110100
        //1011001111 => 1010110111 => 1010111000 =>  1010111100
        //11011101111 => 110111011111 => 11011110111

        private int GetPreviousNumber(int n)
        {
            int c0 = 0,
                c1 = 0;

            int c = n;

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            while ((c & 1) == 0 && c != 0)
            {
                c0++;
                c >>= 1;
            }

            int p = c0 + c1;
            int result = n - (1 << c1) - (1 << (c0 - 1)) + 1;
            //Simplified: int result = n - (1 << (p - 1));
            return result;
        }
    }
}
