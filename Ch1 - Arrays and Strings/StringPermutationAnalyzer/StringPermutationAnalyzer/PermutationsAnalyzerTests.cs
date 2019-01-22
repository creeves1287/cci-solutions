using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringPermutationAnalyzer
{
    [TestClass]
    public class PermutationsAnalyzerTests
    {
        [TestMethod]
        public void SetUpMethod()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void MyPermutationAnalyzerTest()
        {
            IPermutationsAnalyzer analyzer = new MyPermutationsAnalyzer();
            RunTests(analyzer);
        }

        [TestMethod]
        public void TextbookPermutationsAnalyzerWithSortTest()
        {
            IPermutationsAnalyzer analyzer = new TextbookPermutationsAnalyzerWithSort();
            RunTests(analyzer);
        }

        public void RunTests(IPermutationsAnalyzer analyzer)
        {
            AreTheSameTest(analyzer);
            ArePermutationsTest(analyzer);
            AreNotPermutationsTest(analyzer);
            AreNotPermutationsSameLengthTest(analyzer);
            ArePermutationsCaseInsensitive(analyzer);
            ArePermutationsWithWhiteSpace(analyzer);
            AreNotPermutationsWithSimilarValues(analyzer);
        }

        public void AreTheSameTest(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "abcdefgh";
            string secondPhrase = firstPhrase;

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(true, result);
        }

        public void ArePermutationsTest(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "abcdefgh";
            string secondPhrase = "hgfedcba";

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(true, result);
        }

        public void AreNotPermutationsTest(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "This is a random string";
            string secondPhrase = "This is a random string again";

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(false, result);
        }

        public void AreNotPermutationsSameLengthTest(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "abcdefghijk";
            string secondPhrase = "aedkendiend";

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(false, result);
        }

        public void ArePermutationsCaseInsensitive(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "abcdefghijk";
            string secondPhrase = "aBcDeFghijk";

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(false, result);
        }

        public void ArePermutationsWithWhiteSpace(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "abcdefghijk";
            string secondPhrase = "ab cde fg hi jk";

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(false, result);
        }

        public void AreNotPermutationsWithSimilarValues(IPermutationsAnalyzer analyzer)
        {
            string firstPhrase = "ad";
            string secondPhrase = "bc";

            bool result = analyzer.ArePermutations(firstPhrase, secondPhrase);

            Assert.AreEqual(false, result);
        }
    }
}
