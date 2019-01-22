using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleStack;

namespace StacksTests
{
    [TestClass]
    public class StacksTests
    {
        [TestMethod]
        public void MyStacksTests()
        {
            IStacks<int> stacks = new MyStacks<int>(3);
            RunTests(stacks);
        }

        private void RunTests(IStacks<int> stacks)
        {
            PushTest(stacks);
            PopTest(stacks);
        }

        private void PushTest(IStacks<int> stacks)
        {
            int[][] stackValues = GetStackValues();
            for (int i = 0; i < stackValues.Length; i++)
            {
                for (int j = 0; j < stackValues[i].Length; j++)
                {
                    int value = stackValues[i][j];
                    int stackIndex = i;
                    stacks.Push(value, stackIndex);
                    int result = stacks.Peek(stackIndex);
                    Assert.AreEqual(value, result);
                }
            }
        }

        private void PopTest(IStacks<int> stacks)
        {
            int[][] stackValues = GetStackValues();
            for (int i = 0; i < stackValues.Length; i++)
            {
                for (int j = 0; j < stackValues[i].Length; j++)
                {
                    int stackIndex = i;
                    int value = stacks.Peek(stackIndex);
                    int result = stacks.Pop(stackIndex);
                    int newValue = (j < stackValues[i].Length - 1) ? stacks.Peek(stackIndex) : 0;
                    Assert.AreEqual(value, result);
                    Assert.AreEqual(false, (result == newValue));
                }
            }
        }


        private void AddStackValues<T>(IStacks<T> stacks, T[][] stackValues)
        {
            for (int i = 0; i < stackValues.Length; i++)
            {
                for (int j = 0; j < stackValues[i].Length; j++)
                {
                    T value = stackValues[i][j];
                    int stackIndex = i;
                    stacks.Push(value, stackIndex);
                }
            }
        }

        private int[][] GetStackValues()
        {
            int[][] values = new int[3][];
            values[0] = new int[] { 3, 5, 4 };
            values[1] = new int[] { 9, 7 };
            values[2] = new int[] { 8, 6, 7, 3 };
            return values;
        }
    }
}
