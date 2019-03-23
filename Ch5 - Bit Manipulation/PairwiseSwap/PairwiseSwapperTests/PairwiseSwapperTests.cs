using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairwiseSwap;

namespace PairwiseSwapperTests
{
    [TestClass]
    public class PairwiseSwapperTests
    {
        [TestMethod]
        public void MyPairwiseSwapperTests()
        {
            IPairwiseSwapper pairwiseSwapper = new MyPairwiseSwapper();
            RunTests(pairwiseSwapper);
        }

        [TestMethod]
        public void MyPairwiseSwapperWithAlternatingZerosMaskTests()
        {
            IPairwiseSwapper pairwiseSwapper = new MyPairwiseSwapperWithAlternatingZerosMask();
            RunTests(pairwiseSwapper);
        }

        private void RunTests(IPairwiseSwapper pairwiseSwapper)
        {
            int n = 9;
            int expected = 6;
            int result = pairwiseSwapper.SwapPairwiseBits(n);
            Assert.AreEqual(expected, result);
        }
    }
}
