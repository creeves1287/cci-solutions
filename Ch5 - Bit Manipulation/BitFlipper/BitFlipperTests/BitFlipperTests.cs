using System;
using BitFlipper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitFlipperTests
{
    [TestClass]
    public class BitFlipperTests
    {
        [TestMethod]
        public void MyBitFlipperTest()
        {
            IBitFlipper bitFlipper = new MyBitFlipper();
            RunTests(bitFlipper);
        }

        private void RunTests(IBitFlipper bitFlipper)
        {
            GetMaximumBitSequenceTest(bitFlipper);
        }

        private void GetMaximumBitSequenceTest(IBitFlipper bitFlipper)
        {
            int input = 1775;
            int expected = 8;
            int result = bitFlipper.GetMaximumBitSequence(input);
            Assert.AreEqual(expected, result);
        }
    }
}
