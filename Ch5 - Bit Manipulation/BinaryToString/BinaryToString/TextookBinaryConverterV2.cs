using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToString
{
    public class TextookBinaryConverterV2 : IBinaryConverter
    {
        public string BinaryToString(double num)
        {
            if (num >= 1 || num <= 0)
            {
                return "ERROR";
            }

            StringBuilder binary = new StringBuilder();
            binary.Append(".");
            double digitValue = 0.5;

            while (num > 0)
            {
                if (binary.Length > 32)
                {
                    return "ERROR";
                }

                if (num - digitValue >= 0)
                {
                    binary.Append(1);
                    num -= digitValue;
                }
                else
                {
                    binary.Append(0);
                }

                digitValue /= 2;
            }

            return binary.ToString();
        }
    }
}
