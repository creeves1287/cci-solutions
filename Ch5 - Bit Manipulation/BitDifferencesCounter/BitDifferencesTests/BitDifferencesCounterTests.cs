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
            IBitDifferencesCounter bitDiffernecesCounter = new MyBitDifferencesCounter();
            RunTests(bitDiffernecesCounter);
        }

        [TestMethod]
        public void TextbookBitDifferencesCounterTests()
        {
            IBitDifferencesCounter bitDifferencesCounter = new TextbookBitDifferencesCounter();
            RunTests(bitDifferencesCounter);
        }

        private void RunTests(IBitDifferencesCounter bitDiffernecesCounter)
        {
            BitDifferencesTest(bitDiffernecesCounter);
            NoBitDifferencesTest(bitDiffernecesCounter);
        }

        private void BitDifferencesTest(IBitDifferencesCounter bitDiffernecesCounter)
        {
            int n = 75; //1001011
            int m = 62; //0111110
            int expected = 5;
            int result = bitDiffernecesCounter.CountBitDifferences(n, m);
            Assert.AreEqual(expected, result);
        }

        private void NoBitDifferencesTest(IBitDifferencesCounter bitDiffernecesCounter)
        {
            int n = 75;
            int m = 75;
            int expected = 0;
            int result = bitDiffernecesCounter.CountBitDifferences(n, m);
            Assert.AreEqual(expected, result);
        }

    }
}
