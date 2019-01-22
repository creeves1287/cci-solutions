using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortStack;

namespace SortStackTests
{
    [TestClass]
    public class SortingStackTests
    {
        [TestMethod]
        public void MySortStackTests()
        {
            ISortingStack sortStack = new MySortingStack();
            RunTests(sortStack);
        }

        private void RunTests(ISortingStack sortStack)
        {
            AddTests(sortStack);
        }

        private void AddTests(ISortingStack sortStack)
        {
            int[] values = new int[] { 5, 2, 8, 1, 6, 4 };
            int[] sortedValues = (int[])values.Clone();
            Array.Sort(sortedValues);

            for (int i = 0; i < values.Length; i++)
            {
                int value = values[i];
                sortStack.Push(value);
            }

            for (int i = 0; i < values.Length; i++)
            {
                int value = sortStack.Pop();
                int expected = sortedValues[i];
                Assert.AreEqual(expected, value);
            }
        }
    }
}
