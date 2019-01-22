using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeChecker;

namespace PalindromeCheckerTests
{
    [TestClass]
    public class PalindromeCheckerTests
    {
        [TestMethod]
        public void MyPalindromeCheckerTests()
        {
            IPalindromeChecker palindromeChecker = new MyPalindromeChecker();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void MyPalindromeCheckerSinglyLinkedListTests()
        {
            IPalindromeChecker palindromeChecker = new MyPalindromeCheckerSinglyLinkedList();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void TextbookPalindromeCheckerTests()
        {
            IPalindromeChecker palindromeChecker = new TextbookPalindromeChecker();
            RunTests(palindromeChecker);
        }

        [TestMethod]
        public void TextbookPalindromeCheckerWithStackTests()
        {
            IPalindromeChecker palindromeChecker = new TextbookPalindromeCheckerWithStack();
            RunTests(palindromeChecker);
        }

        private void RunTests(IPalindromeChecker palindromeChecker)
        {
            IsPalindromeTest(palindromeChecker);
            IsPalindromeExtraCharactersTest(palindromeChecker);
        }

        private void IsPalindromeTest(IPalindromeChecker palindromeChecker)
        {
            int length = 20;
            var list = GeneratePalindromeList(length);
            bool result = palindromeChecker.IsPalindrome(list);
            Assert.AreEqual(true, result);
        }

        private void IsPalindromeExtraCharactersTest(IPalindromeChecker palindromeChecker)
        {
            int length = 80;
            var list = GeneratePalindromeList(length);
            bool result = palindromeChecker.IsPalindrome(list);
            Assert.AreEqual(true, result);
        }

        private Node<char> GeneratePalindromeList(int length)
        {
            Node<char> node = new Node<char>();
            node.Data = (char)('a' + Convert.ToChar(0));
            node.Next = CreatePalindromeNodes(node, 1, length);
            return node;
        }

        private Node<char> CreatePalindromeNodes(Node<char> node, int i, int length)
        {
            if (i > length) return null;
            Node<char> nextNode = new Node<char>();
            if (i < length / 2)
            {
                nextNode.Data = (char)('a' + Convert.ToChar(i));
            }
            else
            {
                nextNode.Data = (char)(('a' + Convert.ToChar(length / 2) - (i - length / 2)));
            }
            nextNode.Next = CreatePalindromeNodes(nextNode, i + 1, length);
            node.Next = nextNode;
            nextNode.Previous = node;
            return nextNode;
        }
    }
}
