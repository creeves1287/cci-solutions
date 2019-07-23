using System.Collections.Generic;

namespace CoinsCounting
{
    public class TextbookCoinCounterWithMemo : ICoinsCounter
    {
        public int CountCoinCombinations(int n)
        {
            int[] denoms = new int[] { 25, 10, 5, 1 };
            Dictionary<int, Dictionary<int, int>> map = new Dictionary<int, Dictionary<int, int>>();
            return CountCoinCombinations(n, denoms, 0, map);
        }

        private int CountCoinCombinations(int amount, int[] denoms, int index, Dictionary<int, Dictionary<int, int>> map)
        {
            if (map.ContainsKey(amount) && map[amount].ContainsKey(index))
            {
                return map[amount][index];
            }
            if (index >= denoms.Length - 1) return 1;
            int ways = 0;
            int denomAmount = denoms[index];
            for (int i = 0; i * denomAmount <= amount; i++)
            {
                int amountRemaining = amount - i * denomAmount;
                ways += CountCoinCombinations(amountRemaining, denoms, index + 1, map);
            }
            if (!map.ContainsKey(amount))
            {
                map.Add(amount, new Dictionary<int, int>());
            }
            map[amount].Add(index, ways);
            return ways;
        }
    }
}
