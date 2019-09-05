using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackOfBoxes;

namespace StackOfBoxesTests
{
    [TestClass]
    public class BoxStackerTests
    {
        [TestMethod]
        public void MyBoxStackerTests()
        {
            IBoxStacker boxStacker = new MyBoxStacker();
            RunTests(boxStacker);
        }

        [TestMethod]
        public void TextbookBoxStackerTests()
        {
            IBoxStacker boxStacker = new TextbookBoxStacker();
            RunTests(boxStacker);
        }

        [TestMethod]
        public void TextbookBoxStackerMemoTests()
        {
            IBoxStacker boxStacker = new TextbookBoxStackerMemo();
            RunTests(boxStacker);
        }

        [TestMethod]
        public void TextbookBoxStackerWithChoicesTests()
        {
            IBoxStacker boxStacker = new TextbookBoxStackerWithChoices();
            RunTests(boxStacker);
        }

        private void RunTests(IBoxStacker boxStacker)
        {
            RunPresetTest(boxStacker);
            RunRandomTest(boxStacker);
        }

        private void RunPresetTest(IBoxStacker boxStacker)
        {
            List<Box> boxes = CreateBoxStack();
            int expected = 9;
            int result = boxStacker.GetLargestStackHeight(boxes);
            Assert.AreEqual(expected, result);
        }

        private void RunRandomTest(IBoxStacker boxStacker)
        {
            int numberOfBoxes = 10;
            int maxDimension = 5;
            List<Box> boxes = CreateBoxStack(numberOfBoxes, maxDimension);
            int result = boxStacker.GetLargestStackHeight(boxes);
            PrintResult(boxes, result);
        }

        private List<Box> CreateBoxStack()
        {
            List<Box> boxes = new List<Box>()
            {
                new Box()
                {
                    Width = 2,
                    Height = 3,
                    Depth = 4
                },
                new Box()
                {
                    Width = 5,
                    Height = 6,
                    Depth = 7
                },
                new Box()
                {
                    Width = 14,
                    Height = 9,
                    Depth = 3
                }
            };
            return boxes;
        }

        private List<Box> CreateBoxStack(int numberOfBoxes, int max)
        {
            Random r = new Random();
            List<Box> boxes = new List<Box>();
            for (int i = 0; i < numberOfBoxes; i++)
            {
                Box box = new Box
                {
                    Width = r.Next(max),
                    Height = r.Next(max),
                    Depth = r.Next(max)
                };
                boxes.Add(box);
            }
            return boxes;
        }

        private void PrintResult(List<Box> boxes, int result)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < boxes.Count; i++)
            {
                Box box = boxes[i];
                s.Append($"Box { i + 1 }:\n");
                s.Append($"Width: { box.Width }\n");
                s.Append($"Height: { box.Height }\n");
                s.Append($"Depth: { box.Depth }\n\n");
            }
            s.Append($"Result: { result }");
            Trace.WriteLine(s.ToString());
        }
    }
}
