using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCounting
{
    public class MyCoinCounter : ICoinsCounter
    {
        public int CountCoinCombinations(int n)
        {
            if (n < 1) return -1;

            HashSet<string> memo = new HashSet<string>();
            List<Coins> result = new List<Coins>();
            CountCoinCombinations(result, new Coins(0, 0, 0, 0), memo, n);
            return result.Count;
        }

        private void CountCoinCombinations(List<Coins> result, Coins coins, HashSet<string> memo, int remainder)
        {
            if (remainder < 0)
            {
                return;
            }

            string key = CreateKey(coins);
            if (memo.Contains(key))
            {
                return;
            }
            memo.Add(key);

            if (remainder == 0)
            {
                result.Add(coins);
                return;
            }

            CountCoinCombinations(result, new Coins(coins.Quarters + 1, coins.Dimes, coins.Nickels, coins.Pennies), memo, remainder - 25);
            CountCoinCombinations(result, new Coins(coins.Quarters, coins.Dimes + 1, coins.Nickels, coins.Pennies), memo, remainder - 10);
            CountCoinCombinations(result, new Coins(coins.Quarters, coins.Dimes, coins.Nickels + 1, coins.Pennies), memo, remainder - 5);
            CountCoinCombinations(result, new Coins(coins.Quarters, coins.Dimes, coins.Nickels, coins.Pennies + 1), memo, remainder - 1);
        }

        private string CreateKey(Coins coins)
        {
            string key = coins.Quarters.ToString() + ":" + coins.Dimes.ToString() + ":" + coins.Nickels.ToString() + ":" + coins.Pennies.ToString();
            return key;
        }
    }
}
