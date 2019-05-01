using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocalypseBirthCalculations
{
    public class ApocalypseBirthCalculator : IApocalypseBirthCalculator
    {
        public int GetNumberOfBoys(int families)
        {
            int boys = families / 2;
            if (families != 0)
            {
                boys += GetNumberOfBoys(families / 2);
            }
            return boys;
        }
    }
}
