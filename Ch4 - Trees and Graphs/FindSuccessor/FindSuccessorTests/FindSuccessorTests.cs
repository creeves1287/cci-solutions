using System;
using FindSuccessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindSuccessorTests
{
    [TestClass]
    public class FindSuccessorTests
    {
        [TestMethod]
        public void MyFindSuccessorTests()
        {
            IFindSuccessor findSuccessor = new MyFindSuccessor();
            RunTests(findSuccessor);
        }

        [TestMethod]
        public void TextbookFindSuccessorTests()
        {
            IFindSuccessor findSuccessor = new TextbookFindSuccessor();
            RunTests(findSuccessor);
        }

        private void RunTests(IFindSuccessor findSuccessor)
        {
            FindSuccessorTest(findSuccessor);
        }

        private void FindSuccessorTest(IFindSuccessor findSuccessor)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            BinaryTreeNode<int> root = CreateMinimalTree(arr);
            TraverseTree(root, findSuccessor);
        }
        private void TraverseTree(BinaryTreeNode<int> root, IFindSuccessor findSuccessor)
        {
            if (root == null) return;
            int expected = root.Value + ((root.Value == 13) ? 0 : 1);
            TraverseTree(root.Left, findSuccessor);
            BinaryTreeNode<int> n = findSuccessor.FindSuccessor(root);
            Assert.AreEqual(expected, n.Value);
            TraverseTree(root.Right, findSuccessor);
        }

        private BinaryTreeNode<int> CreateMinimalTree(int[] arr)
        {
            int index = arr.Length / 2;
            BinaryTreeNode<int> root = CreateNode(arr, -1, arr.Length, null);
            return root;
        }

        private BinaryTreeNode<int> CreateNode(int[] arr, int leftBoundary, int rightBoundary, BinaryTreeNode<int> parent)
        {
            int index = (leftBoundary + rightBoundary + 1) / 2;
            if (index == leftBoundary || index == rightBoundary) return null;
            BinaryTreeNode<int> n = new BinaryTreeNode<int>(arr[index]);
            n.Parent = parent;
            n.Left = CreateNode(arr, leftBoundary, index, n);
            n.Right = CreateNode(arr, index, rightBoundary, n);
            return n;
        }

    }
}
