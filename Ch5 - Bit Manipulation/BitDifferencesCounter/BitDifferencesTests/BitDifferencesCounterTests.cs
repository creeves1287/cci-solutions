using System;
using BitDifferencesCounting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitDifferencesTests
{
    [TestClass]
    public class BitDifferencesCounterTests
    {
        [TestMethod]
        public void MyBitDifferencesCounterTests()
        {
            IBitDiffernecesCounter bitDiffernecesCounter = new MyBitDifferencesCounter();
            RunTests(bitDiffernecesCounter);
        }

        private void RunTests(IBitDiffernecesCounter bitDiffernecesCounter)
        {
            BitDifferencesTest(bitDiffernecesCounter);
            NoBitDifferencesTest(bitDiffernecesCounter);
        }

        private void BitDifferencesTest(IBitDiffernecesCounter bitDiffernecesCounter)
        {
            int n = 75; //1001011
            int m = 62; //0111110
            int expected = 5;
            int result = bitDiffernecesCounter.CountBitDifferences(n, m);
            Assert.AreEqual(expected, result);
        }

        private void NoBitDifferencesTest(IBitDiffernecesCounter bitDiffernecesCounter)
        {
            int n = 75;
            int m = 75;
            int expected = 0;
            int result = bitDiffernecesCounter.CountBitDifferences(n, m);
            Assert.AreEqual(expected, result);
        }

    }
}
