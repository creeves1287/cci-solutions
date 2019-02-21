using System;
using System.Collections.Generic;
using System.Text;

namespace NextNumberFinder
{
    public class TextbookNextNumberFinder : INextNumberFinder
    {
        public NextNumbers GetNextNumbers(int n)
        {
            if (n < 1 || n == int.MaxValue) return null;

            NextNumbers result = new NextNumbers();
            result.Next = GetNextNumber(n);
            result.Previous = GetPreviousNumber(n);
            return result;
        }

        private int GetNextNumber(int n)
        {
            int c = n;
            int c0 = 0;
            int c1 = 0;

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

            if (c0 + c1 == 31 || c0 + c1 == 0)
            {
                return -1;
            }

            int p = c0 + c1;
            n |= 1 << p; // flip the rightmost non-trailing zero
            n &= ~((1 << p) - 1); // clear all bits to the right of p
            n |= (1 << (c1 - 1)) - 1; // insert (c1 -1) ones on the right

            return n;
        }

        private int GetPreviousNumber(int n)
        {
            int c = n;
            int c1 = 0;
            int c0 = 0;

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            if (c == 0) return -1;

            while ((c & 1) == 0 && c != 0)
            {
                c0++;
                c >>= 1;
            }

            int p = c1 + c0; // position of rightmost non-trailing one
            n &= (~(0) << (p + 1)); // clears from bit p onward
            int mask = (1 << (c1 + 1)) - 1; // sequence of (c1 + 1) ones
            n |= mask << (c0 - 1);

            return n;
        }
    }
}
