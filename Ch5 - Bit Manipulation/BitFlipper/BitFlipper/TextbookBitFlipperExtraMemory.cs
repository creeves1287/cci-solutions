using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFlipper
{
    public class TextbookBitFlipperExtraMemory : IBitFlipper
    {
        private const int MAX_BITS = 32;
        public int GetMaximumBitSequence(int input)
        {
            if (input == -1) return MAX_BITS;
            List<int> sequences = GetAlternatingSequences(input);
            return FindLongestSequence(sequences);
        }

        /* Return a list of the sizes of the sequences.  The sequence starts off with the number of 0s (which might be zero)
         * and then alternates with the counts of each value */
        private List<int> GetAlternatingSequences(int input)
        {
            List<int> sequences = new List<int>();
            uint searchingFor = 0;
            int counter = 0;
            uint n = (uint)input;

            for (int i = 0; i < MAX_BITS; i++)
            {
                if ((n & 1) != searchingFor)
                {
                    sequences.Add(counter);
                    searchingFor = n & 1; // Flip 1 to 0 or 0 to 1
                    counter = 0;
                }

                counter++;
                n >>= 1;
            }

            sequences.Add(counter);
            return sequences;
        }

        // Given the lengths of alternating sequences of 0s and 1s, find the longest one
        private int FindLongestSequence(List<int> seq)
        {
            int maxSeq = 1;
            
            for (int i = 0; i < seq.Count; i += 2)
            {
                int zerosSeq = seq[i];
                int onesSeqRight = i - 1 >= 0 ? seq[i - 1] : 0;
                int onesSeqLeft = i + 1 < seq.Count ? seq[i + 1] : 0;

                int thisSeq = 0;
                if (zerosSeq == 1) // Can merge
                {
                    thisSeq = onesSeqLeft + 1 + onesSeqRight; ;
                }
                else if (zerosSeq > 1) // just add a zero to either side
                {
                    thisSeq = 1 + Math.Max(onesSeqRight, onesSeqLeft);
                }
                else if (zerosSeq == 0) // no zero, but take either side
                {
                    thisSeq = Math.Max(onesSeqRight, onesSeqLeft);
                }

                maxSeq = Math.Max(thisSeq, maxSeq);
            }
            return maxSeq;
        }
    }
}
