using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDraw
{
    public class MyLineDrawer : ILineDrawer
    {
        public void DrawLine(byte[] screen, int width, int x1, int x2, int y)
        {
            int height = screen.Length / (width / 8);
            if (y > height || y < 0) throw new ArgumentException("y is outside the bounds of the screen.");
            if (x1 < 0) throw new ArgumentException("x1 must be greater than zero.");
            if (x2 > width) throw new ArgumentException("x2 must be less than the width of the screen.");
            if (x1 > x2) throw new ArgumentException("x1 cannot be greater than x2.");
            int heightIndex = y - 1;
            int yStart = heightIndex * width / 8;
            int xStart = yStart + (x1 / 8);
            int xEnd = yStart + (x2 / 8);
            int xBitStart = x1 % 8;
            int xBitEnd = x2 % 8;
            for (int i = xStart; i <= xEnd; i++)
            {
                byte mask = GetMask(screen, i, xStart, xEnd, xBitStart, xBitEnd);
                screen[i] = mask;
            }
        }

        private byte GetMask(byte[] screen, int i, int xStart, int xEnd, int xBitStart, int xBitEnd)
        {
            int mask = byte.MaxValue;
            if (i == xStart)
            {
                mask &= (1 << ((8 - xBitStart) + 1)) - 1;
            }
            if (i == xEnd)
            {
                mask ^= (1 << (8 - xBitEnd)) - 1;
            }
            return (byte)mask;
        }
    }
}
