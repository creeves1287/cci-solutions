using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextNumberFinder;

namespace NextNumberFinderTests
{
    [TestClass]
    public class NextNumberFinderTests
    {
        [TestMethod]
        public void MyNextNumberFinderTests()
        {
            INextNumberFinder nextNumberFinder = new MyNextNumberFinder();
            RunTests(nextNumberFinder);
        }

        private void RunTests(INextNumberFinder nextNumberFinder)
        {
            NotPostiveTest(nextNumberFinder);
            MaxIntTest(nextNumberFinder);
            NexNumberTest(nextNumberFinder);
        }

        private void NotPostiveTest(INextNumberFinder nextNumberFinder)
        {
            int n = -1;
            NextNumbers result = nextNumberFinder.GetNextNumbers(n);
            Assert.AreEqual(null, result);
        }

        private void MaxIntTest(INextNumberFinder nextNumberFinder)
        {
            int n = int.MaxValue;
            NextNumbers result = nextNumberFinder.GetNextNumbers(n);
            Assert.AreEqual(null, result);
        }

        private void NexNumberTest(INextNumberFinder nextNumberFinder)
        {
            int n = 1775;
            NextNumbers result = nextNumberFinder.GetNextNumbers(n);
            Assert.AreEqual(1783, result.Next);
            Assert.AreEqual(1759, result.Previous);
        }
    }
}
