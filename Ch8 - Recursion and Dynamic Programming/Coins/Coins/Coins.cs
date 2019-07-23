using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCounting
{
    public class Coins
    {
        public Coins(int quarters, int dimes, int nickels, int pennies)
        {
            Quarters = quarters;
            Dimes = dimes;
            Nickels = nickels;
            Pennies = pennies;
        }
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickels { get; set; }
        public int Pennies { get; set; }
    }
}
