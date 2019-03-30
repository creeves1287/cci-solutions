using System;
using System.Diagnostics;
using LineDraw;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LineDrawTests
{
    [TestClass]
    public class LineDrawTests
    {
        [TestMethod]
        public void MyLineDrawerTests()
        {
            ILineDrawer lineDrawer = new MyLineDrawer();
            RunTests(lineDrawer);
        }

        [TestMethod]
        public void TextbookLineDrawerTests()
        {
            ILineDrawer lineDrawer = new TextbookLineDrawer();
            RunTests(lineDrawer);
        }

        private void RunTests(ILineDrawer lineDrawer)
        {
            int width = 32;
            int height = 5;
            byte[] screen = new byte[(width / 8) * height];
            int x1 = 9;
            int x2 = 24;
            int y = 2;
            lineDrawer.DrawLine(screen, width, x1, x2, y);
            for (int i = 0; i < screen.Length; i++)
            {
                if (i > 0 && i % (width / 8) == 0)
                {
                    Trace.Write("\n");
                }
                string pixels = Convert.ToString(screen[i], 2).PadLeft(8, '0');
                Trace.Write(pixels + " ");
            }
        }
    }
}
