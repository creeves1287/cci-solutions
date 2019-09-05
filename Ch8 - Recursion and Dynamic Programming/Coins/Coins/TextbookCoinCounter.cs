using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCounting
{
    public class TextbookCoinCounter : ICoinsCounter
    {
        public int CountCoinCombinations(int n)
        {
            int[] denom = new int[] { 25, 10, 5, 1 };
            return CountCoinCombinations(n, denom, 0);
        }

        private int CountCoinCombinations(int amount, int[] denoms, int index)
        {
            if (index >= denoms.Length - 1) return 1; // last denom
            int denom = denoms[index];
            int ways = 0;
            for (int i = 0; i * denom <= amount; i++)
            {
                int amountRemaining = amount - i * denom;
                ways += CountCoinCombinations(amountRemaining, denoms, index + 1);
            }
            return ways;
        }
    }
}
