using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToString
{
    public class TextbookBinaryConverter : IBinaryConverter
    {
        public string BinaryToString(double x)
        {
            if (x >= 1 || x <= 0)
            {
                return "ERROR";
            }

            StringBuilder binary = new StringBuilder();
            binary.Append(".");

            while (x > 0)
            {
                if (binary.Length > 32)
                {
                    return "ERROR";
                }

                double shiftedX = x * 2;

                if (shiftedX >= 1)
                {
                    binary.Append(1);
                    x = shiftedX - 1;
                }
                else
                {
                    binary.Append(0);
                    x = shiftedX;
                }
            }

            return binary.ToString();
        }
    }
}
