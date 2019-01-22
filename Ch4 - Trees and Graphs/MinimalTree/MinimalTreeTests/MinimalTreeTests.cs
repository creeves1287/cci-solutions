using System;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalTree;

namespace MinimalTreeTests
{
    [TestClass]
    public class MinimalTreeTests
    {
        [TestMethod]
        public void MyMinimalTreeTests()
        {
            IMinimalTree minimalTree = new MyMinimalTree();
            RunTests(minimalTree);
        }

        private void RunTests(IMinimalTree minimalTree)
        {
            CreateTree(minimalTree);
        }

        private void CreateTree(IMinimalTree minimalTree)
        {
            int[] arr = CreateValues();
            BinaryTreeNode<int> root = minimalTree.CreateMinimalTree(arr);
            ValidateTree(root, arr);
        }

        private void ValidateTree(BinaryTreeNode<int> root, int[] arr)
        {
            int index = 0;
            bool isValid = (CheckNodeIndex(root, arr, index) != -1);
            Assert.AreEqual(true, isValid);
        }

        private bool CheckNode(BinaryTreeNode<int> node, int[] arr, int index)
        {
            if (node == null)
                return true;

            bool leftValid = CheckNode(node.Left, arr, index / 2);
            bool nodeValid = (node.Value == arr[index]);
            bool rightValid = CheckNode(node.Right, arr, index + (arr.Length - index - 1) / 2);
            return (leftValid && nodeValid && rightValid);
        }

        private int CheckNodeIndex(BinaryTreeNode<int> node, int[] arr, int index)
        {
            if (node == null || index == -1)
                return index;

            index = CheckNodeIndex(node.Left, arr, index);
            index = (node.Value == arr[index]) ? index + 1 : -1;
            index = CheckNodeIndex(node.Right, arr, index);
            return index;
        }



        private int[] CreateValues()
        {
            return new int[] { 2, 5, 9, 12, 18, 30, 40, 52, 68, 74, 79, 82, 86, 91 };
        }
    }
}
