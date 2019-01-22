using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinStack;

namespace MinStackTests
{
    [TestClass]
    public class MinStackTests
    {
        [TestMethod]
        public void MyMinStackTest()
        {
            IMinStack minStack = new MyMinStack();
            RunTests(minStack);
        }

        [TestMethod]
        public void TextbookMinStackTest()
        {
            IMinStack minStack = new TextbookMinStack();
            RunTests(minStack);
        }

        [TestMethod]
        public void TextbookMinDoubleStackTest()
        {
            IMinStack minStack = new TextbookMinDoubleStack();
            RunTests(minStack);
        }

        private void RunTests(IMinStack minStack)
        {
            PushTest(minStack);
            PopAndMinTest(minStack);
        }

        private void PushTest(IMinStack minStack)
        {
            int[] data = new int[] { 3, 6, 1 };
            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i];
                minStack.Push(value);
                Assert.AreEqual(value, minStack.Peek());
            }
        }

        private void PopAndMinTest(IMinStack minStack)
        {
            int min = minStack.Min();
            Assert.AreEqual(1, min);
            int pop = minStack.Pop();
            Assert.AreEqual(1, pop);

            min = minStack.Min();
            Assert.AreEqual(3, min);
            pop = minStack.Pop();
            Assert.AreEqual(6, pop);

            min = minStack.Min();
            Assert.AreEqual(3, min);
            pop = minStack.Pop();
            Assert.AreEqual(3, pop);

            try
            {
                pop = minStack.Pop();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Stack empty.", ex.Message);
            }
        }
    }
}
