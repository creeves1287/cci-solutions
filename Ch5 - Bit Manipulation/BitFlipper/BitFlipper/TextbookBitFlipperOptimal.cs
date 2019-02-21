using System;

namespace BitFlipper
{
    public class TextbookBitFlipperOptimal : IBitFlipper
    {
        public int GetMaximumBitSequence(int input)
        {
            if (~input == 0) return 32;
            int currentSequence = 0,
                previousSequence = 0,
                maxSequence = 1; // can always be 1 (counting the flipped bit)

            int a = input;

            while (a != 0)
            {
                if ((a & 1) == 1)
                {
                    currentSequence++;
                }
                else if ((a & 1) == 0)
                {
                    previousSequence = (a & 2) == 0 ? 0 : currentSequence;
                    currentSequence = 0;
                }

                maxSequence = Math.Max(previousSequence + 1 + currentSequence, maxSequence);
                a >>= 1;
            }

            return maxSequence;
        }

        // Time Complexity: O(b) where b = input bits
        // Space Complexity: O(1)
    }
}
