using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitInserter
{
    public class MyBitInserter : IBitInserter
    {
        public int InsertBits(int n, int m, int i, int j)
        {
            int shiftedM = m << i;
            int clearedN = ClearBits(n, i, j);
            int result = clearedN | shiftedM;
            return result;
        }

        private int ClearBits(int num, int minBit, int maxBit)
        {
            int mask = 1 << (maxBit - minBit);
            mask = mask - 1;
            mask = mask << minBit;
            mask = ~(mask);
            return (mask & num);
        }
    }
}
