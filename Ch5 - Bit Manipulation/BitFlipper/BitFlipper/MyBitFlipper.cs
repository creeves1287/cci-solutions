using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFlipper
{
    public class MyBitFlipper : IBitFlipper
    {
        public int GetMaximumBitSequence(int input)
        {
            int significantBitIndex = (int)Math.Log(input, 2);
            int maxSequence = 0,
                currentSequence = 0,
                previousSequence = 0;
            int remainder = input;

            for (int i = significantBitIndex; i >= 0; i--)
            {
                int digitValue = (int)Math.Pow(2, i);
                bool bitValueIsOne = (remainder - digitValue >= 0);
                if (bitValueIsOne)
                {
                    currentSequence++;
                    remainder -= digitValue;

                    if (remainder == 0)
                    {
                        int flippedBit = (previousSequence > 0) ? 1 : 0;
                        int completeSequence = previousSequence + flippedBit + currentSequence;
                        if (completeSequence > maxSequence)
                        {
                            maxSequence = completeSequence;
                        }
                    }
                }
                else
                {
                    int flippedBit = 1;
                    int completeSequence = previousSequence + flippedBit + currentSequence;
                    if (completeSequence > maxSequence)
                    {
                        maxSequence = completeSequence;
                    }
                    previousSequence = currentSequence;
                    currentSequence = 0;
                }
            }

            return maxSequence;
        }
    }
}
