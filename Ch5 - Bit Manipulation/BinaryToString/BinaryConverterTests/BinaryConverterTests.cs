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

        [TestMethod]
        public void TextbookBinaryConverterTest()
        {
            IBinaryConverter binaryConverter = new TextbookBinaryConverter();
            RunTests(binaryConverter);
        }

        [TestMethod]
        public void TextbookBinaryConverterV2Test()
        {
            IBinaryConverter binaryConverter = new TextookBinaryConverterV2();
            RunTests(binaryConverter);
        }

        private void RunTests(IBinaryConverter binaryConverter)
        {
            TestTooManyCharacters(binaryConverter);
            TestBinaryConversionDouble(binaryConverter);
        }

        private void TestTooManyCharacters(IBinaryConverter binaryConverter)
        {
            double x = 0.2326595626264656564444894945643134315619811531315599488121321;
            string expected = "ERROR";
            string result = binaryConverter.BinaryToString(x);
            Assert.AreEqual(expected, result);
        }

        private void TestBinaryConversionDouble(IBinaryConverter binaryConverter)
        {
            double x = 0.90625;
            string expected = ".11101";
            string result = binaryConverter.BinaryToString(x);
            Assert.AreEqual(expected, result);
        }
    }
}
