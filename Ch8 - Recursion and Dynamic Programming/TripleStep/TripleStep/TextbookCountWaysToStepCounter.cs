using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleStep
{
    public class TextbookCountWaysToStepCounter : IWaysToStepCounter
    {
        public int CountWaysToStep(int n)
        {
            int[] memo = new int[n + 1];
            FillArray(memo, n + 1);
            return CountWaysToStep(n, memo);
        }

        private int CountWaysToStep(int n, int[] memo)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (memo[n] == -1)
                memo[n] = CountWaysToStep(n - 1, memo)
                    + CountWaysToStep(n - 2, memo)
                    + CountWaysToStep(n - 3, memo);
            return memo[n];
        }

        private void FillArray(int[] memo, int n)
        {
            for (int i = 0; i < n; i++)
            {
                memo[i] = -1;
            }
        }
    }
}
