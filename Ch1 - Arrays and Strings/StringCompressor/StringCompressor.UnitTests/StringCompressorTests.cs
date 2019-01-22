using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCompressor.UnitTests
{
    [TestClass]
    public class StringCompressorTests
    {
        [TestMethod]
        public void MyStringCompressorTest()
        {
            IStringCompressor compressor = new MyStringCompressor();
            RunTests(compressor);
        }

        [TestMethod]
        public void TextbookStringCompressorTest()
        {
            IStringCompressor compressor = new TextbookStringCompressor();
            RunTests(compressor);
        }

        [TestMethod]
        public void TextBookStringCompressorWithLengthCheckTest()
        {
            IStringCompressor compressor = new TextbookStringCompressorWithLengthCheck();
            RunTests(compressor);
        }

        private void RunTests(IStringCompressor compressor)
        {
            CompressStringTest(compressor);
            CompressStringShorterInputTest(compressor);
            CompressStringLong(compressor);
        }

        private void CompressStringTest(IStringCompressor compressor)
        {
            string input = "aaabbbbdddddeefccfssss";

            string result = compressor.CompressString(input);

            Assert.AreEqual("a3b4d5e2f1c2f1s4", result);
        }

        private void CompressStringShorterInputTest(IStringCompressor compressor)
        {
            string input = "abcdefg";

            string result = compressor.CompressString(input);

            Assert.AreEqual(input, result);
        }

        private void CompressStringLong(IStringCompressor compressor)
        {
            string input = "aaaaaaaaaaaaaaaaaaddddddddddddddddddddiiiiiiiiiiiiiiiiiiiiiiiibcde";

            string result = compressor.CompressString(input);

            Assert.AreEqual("a18d20i24b1c1d1e1", result);
        }
    }
}
