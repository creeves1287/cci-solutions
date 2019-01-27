using System;
using BitInserter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitInserterTests
{
    [TestClass]
    public class BitInserterTests
    {
        [TestMethod]
        public void MyBitInserterTest()
        {
            IBitInserter bitInserter = new MyBitInserter();
            RunTests(bitInserter);
        }

        [TestMethod]
        public void TextbookBitInserterTest()
        {
            IBitInserter bitInserter = new TextbookBitInserter();
            RunTests(bitInserter);
        }

        private void RunTests(IBitInserter bitInserter)
        {
            BitInsertionTest(bitInserter);
        }

        private void BitInsertionTest(IBitInserter bitInserter)
        {
            int n = 127;
            int m = 13;
            int i = 2;
            int j = 5;
            int expected = 119;
            int result = bitInserter.InsertBits(n, m, i, j);
            Assert.AreEqual(expected, result);
        }
    }
}
