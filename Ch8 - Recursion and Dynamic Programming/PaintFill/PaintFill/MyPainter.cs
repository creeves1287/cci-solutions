using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintFill
{
    public class MyPainter : IPainter
    {
        public void Fill(string[,] canvas, Point p, string color)
        {
            if (canvas[p.X, p.Y] == color) return;
            Fill(canvas, p, color, canvas[p.X, p.Y]);
        }

        private void Fill(string[,] canvas, Point p, string newColor, string oldColor)
        {
            if (p.X >= canvas.GetLength(0) || p.Y >= canvas.GetLength(1) || p.X < 0 || p.Y < 0)
            {
                return;
            }
            if (canvas[p.X, p.Y] != oldColor)
            {
                return;
            }
            canvas[p.X, p.Y] = newColor;

            Fill(canvas, new Point(p.X + 1, p.Y), newColor, oldColor);
            Fill(canvas, new Point(p.X - 1, p.Y), newColor, oldColor);
            Fill(canvas, new Point(p.X, p.Y + 1), newColor, oldColor);
            Fill(canvas, new Point(p.X, p.Y - 1), newColor, oldColor);
            Fill(canvas, new Point(p.X + 1, p.Y + 1), newColor, oldColor);
            Fill(canvas, new Point(p.X - 1, p.Y - 1), newColor, oldColor);
        }
    }
}
