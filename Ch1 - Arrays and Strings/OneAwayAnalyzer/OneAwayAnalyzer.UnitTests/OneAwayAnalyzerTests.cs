using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneAwayAnalyzer.UnitTests
{
    [TestClass]
    public class OneAwayAnalyzerTests
    {
        [TestMethod]
        public void SetUpMethod()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void OneAwayAnalyzerTest()
        {
            IOneAwayAnalyzer analyzer = new OneAwayAnalyzer();
            RunTests(analyzer);
        }

        [TestMethod]
        public void OneAwayAnalyzerCompactTest()
        {
            IOneAwayAnalyzer analyzer = new OneAwayAnalyzerCompact();
            RunTests(analyzer);
        }

        private void RunTests(IOneAwayAnalyzer analyzer)
        {
            OneInsertAwayTest(analyzer);
            OneReplaceAwayTest(analyzer);
            OneDeleteAwayTest(analyzer);
            NotOneInsertAwayTest(analyzer);
            NotOneReplaceAwayTest(analyzer);
            NotOneDeleteAwayTest(analyzer);
        }

        private void OneInsertAwayTest(IOneAwayAnalyzer analyzer)
        {
            string phrase = "scab";
            string phraseWithInsert = "scabs";
            IsOneAway(analyzer, phrase, phraseWithInsert);
        }

        private void OneReplaceAwayTest(IOneAwayAnalyzer analyzer)
        {
            string phrase = "scab";
            string phraseWithReplace = "slab";
            IsOneAway(analyzer, phrase, phraseWithReplace);
        }

        private void OneDeleteAwayTest(IOneAwayAnalyzer analyzer)
        {
            string phrase = "scab";
            string phraseWithDelete = "sab";
            IsOneAway(analyzer, phrase, phraseWithDelete);
        }

        private void NotOneInsertAwayTest(IOneAwayAnalyzer analyzer)
        {
            string phrase = "scab";
            string phraseWithInserts = "scabies";
            IsNotOneAway(analyzer, phrase, phraseWithInserts);
        }

        private void NotOneReplaceAwayTest(IOneAwayAnalyzer analyzer)
        {
            string phrase = "scab";
            string phraseWithReplace = "slap";
            IsNotOneAway(analyzer, phrase, phraseWithReplace);
        }

        private void NotOneDeleteAwayTest(IOneAwayAnalyzer analyzer)
        {
            string phrase = "scab";
            string phraseWithDelete = "sa";
            IsNotOneAway(analyzer, phrase, phraseWithDelete);
        }

        private void IsOneAway(IOneAwayAnalyzer analyzer, string s, string t)
        {
            bool result = analyzer.OneEditAway(s, t);
            Assert.AreEqual(true, result);
        }

        private void IsNotOneAway(IOneAwayAnalyzer analyzer, string s, string t)
        {
            bool result = analyzer.OneEditAway(s, t);
            Assert.AreEqual(false, result);
        }
    }
}
