using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UrlFormatter.UnitTests
{
    [TestClass]
    public class UrlFormatterTests
    {
        [TestMethod]
        public void Setup()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void MyUrlFormatterTest()
        {
            IUrlFormatter formatter = new MyUrlFormatter();
            RunTests(formatter);
        }

        [TestMethod]
        public void TextbookSpaceReplacerTest()
        {
            ISpaceReplacer formatter = new TextbookUrlFormatter();
            RunTests(formatter);
        }

        private void RunTests(IUrlFormatter formatter)
        {
            UrlifyTest(formatter);
        }

        private void UrlifyTest(IUrlFormatter formatter)
        {
            string phrase = "This is a non url string          ";
            int length = 24;

            string result = formatter.Urlify(phrase, length);
            string expected = "This%20is%20a%20non%20url%20string";
            Assert.AreEqual(expected, result);
        }

        private void RunTests(ISpaceReplacer formatter)
        {
            StringReplaceTest(formatter);
            StringReplaceTestWithExtraSpace(formatter);
        }

        private void StringReplaceTest(ISpaceReplacer formatter)
        {
            string phrase = "This is a non url string          ";
            int length = 24;

            char[] content = phrase.ToCharArray();
            formatter.ReplaceSpaces(content, length);
            string expected = "This%20is%20a%20non%20url%20string";
            string actual = new string(content);
            Assert.AreEqual(expected, actual);
        }

        private void StringReplaceTestWithExtraSpace(ISpaceReplacer formatter)
        {
            string phrase = "This is a non url string                   ";
            int length = 24;

            char[] content = phrase.ToCharArray();
            formatter.ReplaceSpaces(content, length);
            string expected = "This%20is%20a%20non%20url%20string";
            string actual = new string(content);
            Assert.AreEqual(expected, actual);
        }

    }
}
