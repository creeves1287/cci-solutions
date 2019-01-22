using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeChecker;

namespace PalindromeCheckerTests
{
    [TestClass]
    public class PalindromeCheckerTests
    {
        [TestMethod]
        public void MyPalindromeCheckerTest()
        {
            IPalindromeChecker palindromeChecker = new MyPalindromeChecker();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void TextbookPalindromeCheckerTest()
        {
            IPalindromeChecker palindromeChecker = new TextbookPalindromeChecker();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void TextbookPalindromeCheckerAlternateTest()
        {
            IPalindromeChecker palindromeChecker = new TextbookPalindromeCheckerAlternate();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void TextbookPalindromeCheckerWithBitVectorTest()
        {
            IPalindromeChecker palindromeChecker = new TextbookPalindromeCheckerWithBitVector();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void MyPalindromeCheckerWithBitVectorTest()
        {
            IPalindromeChecker palindromeChecker = new MyPalindromeCheckerWithBitVector();
            RunTests(palindromeChecker);
        }

        private void RunTests(IPalindromeChecker palindromeChecker)
        {
            IsPalindromeEvenCharacters(palindromeChecker);
            IsPalindromeOddCharacters(palindromeChecker);
            IsNotPalindrome(palindromeChecker);
            IsPalindromeWithSpaces(palindromeChecker);
        }

        private void IsPalindromeEvenCharacters(IPalindromeChecker palindromeChecker)
        {
            string phrase = "abcabc";
            AssertIsPalindrome(phrase, palindromeChecker);
        }

        private void IsPalindromeOddCharacters(IPalindromeChecker palindromeChecker)
        {
            string phrase = "abcdabc";
            AssertIsPalindrome(phrase, palindromeChecker);
        }

        private void IsNotPalindrome(IPalindromeChecker palindromeChecker)
        {
            string phrase = "abcdefgh";
            AssertIsNotPalindrome(phrase, palindromeChecker);
        }

        private void IsPalindromeWithSpaces(IPalindromeChecker palindromeChecker)
        {
            string phrase = "Tact Coa";
            AssertIsPalindrome(phrase, palindromeChecker);
        }

        private void AssertIsPalindrome(string phrase, IPalindromeChecker palindromeChecker)
        {
            bool result = palindromeChecker.IsPermutationOfPalindrome(phrase);
            Assert.AreEqual(true, result);
        }

        private void AssertIsNotPalindrome(string phrase, IPalindromeChecker palindromeChecker)
        {
            bool result = palindromeChecker.IsPermutationOfPalindrome(phrase);
            Assert.AreEqual(false, result);
        }
    }
}
