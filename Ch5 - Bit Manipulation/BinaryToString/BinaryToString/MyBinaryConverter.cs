using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToString
{
    public class MyBinaryConverter : IBinaryConverter
    {
        public string BinaryToString(int x)
        {
            if (x < 0) throw new ArgumentException("x must be greater than or equal to 0.");
            int remainder = x;
            StringBuilder result = new StringBuilder();
            int significantDigit = (int)Math.Log(x, 2);
            for (int i = significantDigit; i >= 0; i--)
            {
                int digitValue = (int)Math.Pow(2, i);
                if (remainder - digitValue < 0)
                {
                    result.Append(0);
                }
                else
                {
                    result.Append(1);
                    remainder -= digitValue;
                }
            }
            return result.ToString();
        }
    }
}
