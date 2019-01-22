using System;
using KthToLast;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KthToLastTests
{
    [TestClass]
    public class KthToLastAnalyzerTests
    {
        [TestMethod]
        public void MyKthToLastAnalyzerTest()
        {
            IKthToLastAnalyzer<int> kthToLastAnalyzer = new MyKthToLastAnalyzer<int>();
            RunTests(kthToLastAnalyzer);
        }

        private void RunTests(IKthToLastAnalyzer<int> kthToLastAnalyzer)
        {
            KthToLastTest(kthToLastAnalyzer);
        }

        private void KthToLastTest(IKthToLastAnalyzer<int> kthToLastAnalyzer)
        {
            int length = 2000000;
            int k = 1500000;
            int expected = 1;
            Node<int> head = CreateList(length, k);

            Node<int> result = kthToLastAnalyzer.GetKthToLastNode(head, k);

            Assert.AreEqual(expected, result.Data);
        }

        private Node<int> CreateList(int length, int k)
        {
            Node<int> head = new Node<int>();
            Node<int> current = head;
            for (int i = 0; i < length; i++)
            {
                current.Next = new Node<int>();
                current = current.Next;

                if (length - k == i)
                {
                    current.Data = 1;
                }
            }
            return head;
        }
    }
}
