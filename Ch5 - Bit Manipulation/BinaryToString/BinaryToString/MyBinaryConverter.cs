using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToString
{
    public class MyBinaryConverter : IBinaryConverter
    {
        public string BinaryToString(double x)
        {
            int xInt = ConvertToInteger(x);
            if (xInt == -1)
            {
                return "ERROR";
            }
            return BinaryToString(xInt);
        }

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
            string binary = (result.Length > 32) ? "ERROR" : result.ToString();
            return binary;
        }

        private int ConvertToInteger(double x)
        {
            int xInt = (int)x;
            int counter = 0;

            while (x - xInt > 0)
            {
                x *= 10;
                xInt = (int)x;
                counter++;

                if (counter > 32)
                {
                    return -1;
                }
            }

            return xInt;
        }
    }
}
