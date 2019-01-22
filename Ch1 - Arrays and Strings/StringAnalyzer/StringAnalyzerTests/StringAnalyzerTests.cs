using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringAnalyzer;

namespace StringAnalyzerTests
{
    [TestClass]
    public class StringAnalyzerTests
    {
        [TestMethod]
        public void SetUpMethod()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void MyStringAnalyzerTest()
        {
            IStringAnalyzer analyzer = new MyStringAnalyzer();
            RunTests(analyzer);
        }

        [TestMethod]
        public void TextbookStringAnalyzerTest()
        {
            IStringAnalyzer analyzer = new TextbookStringAnalyzer();
            RunTests(analyzer);

        }

        [TestMethod]
        public void SlowStringAnalyzerTest()
        {
            IStringAnalyzer analyzer = new SlowStringAnalyzer();
            RunTests(analyzer);
        }

        private void RunTests(IStringAnalyzer analyzer)
        {
            CharactersAreNotUnique(analyzer);
            CharactersAreUnique(analyzer);
        }

        private void CharactersAreNotUnique(IStringAnalyzer analyzer)
        {
            string phraseWithRepeatedCharacters = "This is a test string, which should fail";

            bool result = analyzer.CharactersAreUnique(phraseWithRepeatedCharacters);

            Assert.AreEqual(false, result);
        }

        private void CharactersAreUnique(IStringAnalyzer analyzer)
        {
            string phraseWithUniqueCharacters = "abcdefghijklmnopqrstuvwxyz";

            bool result = analyzer.CharactersAreUnique(phraseWithUniqueCharacters);

            Assert.AreEqual(true, result);
        }
    }
}
