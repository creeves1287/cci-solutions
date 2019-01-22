using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortStack;

namespace SortStackTests
{
    [TestClass]
    public class SortStackTests
    {
        [TestMethod]
        public void MySortStackTests()
        {
            ISortStack sortStack = new MySortStack();
            RunTests(sortStack);
        }

        private void RunTests(ISortStack sortStack)
        {
            AddTest(sortStack);
        }

        private void AddTest(ISortStack sortStack)
        {
            int[] values = new int[] { 5, 2, 8, 1, 6, 4 };
            int[] sortedValues = (int[])values.Clone();
            Array.Sort(sortedValues);
            Stack<int> input = new Stack<int>();

            for (int i = 0; i < values.Length; i++)
            {
                int value = values[i];
                input.Push(value);
            }

            LinkedList<int>

            sortStack.Sort(input);

            for (int i = 0; i < values.Length; i++)
            {
                int value = input.Pop();
                int expected = sortedValues[i];
                Assert.AreEqual(expected, value);
            }
        }
    }
}
