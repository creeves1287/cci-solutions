using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleStep
{
    public class MyWaysToStepCounter : IWaysToStepCounter
    {
        public int CountWaysToStep(int n)
        {
            if (n <= 0) return 0;
            int[] memo = new int[n];
            return CountWaysToStep(n, 0, memo);
        }

        private int CountWaysToStep(int n, int step, int[] memo)
        {
            if (step >= n) return 0;

            if (memo[step] == 0)
            {
                memo[step] = CalculateStep(n, step + 1, memo)
                    + CalculateStep(n, step + 2, memo)
                    + CalculateStep(n, step + 3, memo);
            }
            return memo[step];
        }

        private int CalculateStep(int n, int step, int[] memo)
        {
            if (step <= n)
            {
                int ways = CountWaysToStep(n, step, memo);
                return (ways > 1) ? ways : 1;
            }
            return 0;
        }
    }
}
