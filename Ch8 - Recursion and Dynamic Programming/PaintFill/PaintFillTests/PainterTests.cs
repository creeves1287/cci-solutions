using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintFill;

namespace PaintFillTests
{
    [TestClass]
    public class PainterTests
    {
        [TestMethod]
        public void MyPainterTests()
        {
            IPainter painter = new MyPainter();
            RunTests(painter);
        }

        private void RunTests(IPainter painter)
        {
            int x = 10;
            int y = 20;
            int colors = 3;
            string paintColor = "X";
            Random r = new Random();
            string[,] canvas = CreateCanvas(x, y, colors, r);
            Point p = GetRandomPoint(x, y, r);
            PrintCanvas(canvas);
            painter.Fill(canvas, p, paintColor);
            PrintCanvas(canvas);
        }

        private string[,] CreateCanvas(int x, int y, int colors, Random r)
        {
            string[,] canvas = new string[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    string color = r.Next(colors).ToString();
                    canvas[i, j] = color;
                }
            }
            return canvas;
        }

        private Point GetRandomPoint(int x, int y, Random r)
        {
            int rX = r.Next(x);
            int rY = r.Next(y);
            Point p = new Point(rX, rY);
            return p;
        }

        private void PrintCanvas(string[,] canvas)
        {
            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLength(1); j++)
                {
                    Trace.Write(canvas[i, j]);
                }
                Trace.Write("\n");
            }
            Trace.Write("\n");
        }
    }
}
