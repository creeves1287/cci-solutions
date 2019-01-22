using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetOfStacks;

namespace SetOfStacksTests
{
    [TestClass]
    public class SetOfStacksTests
    {
        private int _capacity = 3;
        private int _size = 10;
        [TestMethod]
        public void MySetOfStacksTest()
        {
            ISetOfStacks<int> setOfStacks = new MySetOfStacks<int>(_capacity);
            RunTests(setOfStacks);
        }

        [TestMethod]
        public void TextbookSetOfStacks()
        {
            ISetOfStacks<int> setOfStacks = new TextbookSetOfStacks(_capacity);
            RunTests(setOfStacks);
        }

        private void RunTests(ISetOfStacks<int> setOfStacks)
        {
            PushTest(setOfStacks);
            PopTest(setOfStacks);
        }

        private void PushTest(ISetOfStacks<int> setOfStacks)
        {
            for (int i = 0; i < _size; i++)
            {
                setOfStacks.Push(i);
                Assert.AreEqual(i, setOfStacks.Peek());
            }
        }

        private void PopTest(ISetOfStacks<int> setOfStacks)
        {
            for (int i = 0; i < _size; i++)
            {
                int peek = setOfStacks.Peek();
                int item = setOfStacks.Pop();
                Assert.AreEqual(peek, item);
            }
        }
    }
}
