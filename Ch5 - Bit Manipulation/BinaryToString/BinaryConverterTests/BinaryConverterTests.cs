using System;
using BinaryToString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryConverterTests
{
    [TestClass]
    public class BinaryConverterTests
    {
        [TestMethod]
        public void MyBinaryConverterTest()
        {
            IBinaryConverter binaryConverter = new MyBinaryConverter();
            RunTests(binaryConverter);
        }

        private void RunTests(IBinaryConverter binaryConverter)
        {
            TestBinaryConversionInt(binaryConverter);
            TestBinaryConversionDouble(binaryConverter);
        }

        private void TestBinaryConversionInt(IBinaryConverter binaryConverter)
        {
            int x = 54;
            string expected = "110110";
            string result = binaryConverter.BinaryToString(x);
            Assert.AreEqual(expected, result);
        }

        private void TestBinaryConversionDouble(IBinaryConverter binaryConverter)
        {
            double x = 0.753;
            string expected = "1011110001";
            string result = binaryConverter.BinaryToString(x);
            Assert.AreEqual(expected, result);
        }
    }
}
