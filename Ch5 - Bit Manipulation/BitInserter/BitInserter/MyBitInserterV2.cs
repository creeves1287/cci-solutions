using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitInserter
{
    public class MyBitInserterV2 : IBitInserter
    {
        public int InsertBits(int n, int m, int i, int j)
        {
            int shiftedM = m << i;
            int clearedN = ClearBits(n, i, j);
            return (shiftedM | clearedN);
        }

        private int ClearBits(int n, int i, int j)
        {
            int clearedLeft = ClearLeft(n, i);
            int clearedRight = ClearRight(n, j);
            return (clearedLeft | clearedRight);
        }

        private int ClearLeft(int n, int i)
        {
            int mask = 1 << i;
            mask -= 1;
            return (n & mask);
        }

        private int ClearRight(int n, int j)
        {
            int mask = 1 << j;
            mask -= 1;
            mask = ~(mask);
            return (n & mask);
        }
    }
}
