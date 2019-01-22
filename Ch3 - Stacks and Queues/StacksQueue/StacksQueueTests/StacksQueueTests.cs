using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksQueue;

namespace StacksQueueTests
{
    [TestClass]
    public class StacksQueueTests
    {
        private readonly int _size = 10;

        [TestMethod]
        public void MyStacksQueueTests()
        {
            IStacksQueue<int> stacksQueue = new MyStacksQueue<int>();
            RunTests(stacksQueue);
        }

        private void RunTests(IStacksQueue<int> stacksQueue)
        {
            AddTest(stacksQueue);
            RemoveTest(stacksQueue);
            AddAndRemoveTest(stacksQueue);
        }

        private void AddAndRemoveTest(IStacksQueue<int> stacksQueue)
        {
            AddTest(stacksQueue);
            RemoveHalf(stacksQueue);
            AddTest(stacksQueue);
            RemoveRest(stacksQueue);
        }

        private void RemoveRest(IStacksQueue<int> stacksQueue)
        {
            for (int i = _size / 2; i < _size; i++)
            {
                int value = stacksQueue.Remove();
                Assert.AreEqual(i, value);
            }

            RemoveTest(stacksQueue);
        }

        private void RemoveTest(IStacksQueue<int> stacksQueue)
        {
            try
            {
                for (int i = 0; i < _size + 1; i++)
                {
                    int value = stacksQueue.Remove();
                    Assert.AreEqual(i, value);
                }
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Queue is empty.", ex.Message);
            }
        }

        private void AddTest(IStacksQueue<int> stacksQueue)
        {
            for (int i = 0; i < _size; i++)
            {
                stacksQueue.Add(i);
            }

            Assert.AreEqual(false, stacksQueue.IsEmpty());
        }

        private void RemoveHalf(IStacksQueue<int> stacksQueue)
        {
            for (int i = 0; i < _size / 2; i++)
            {
                int value = stacksQueue.Remove();
                Assert.AreEqual(i, value);
            }
        }
    }
}
