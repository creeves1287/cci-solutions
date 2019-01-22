using System;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalTree;
using ValidateBST;

namespace ValidateBSTTests
{
    [TestClass]
    public class ValidateBSTTests
    {
        [TestMethod]
        public void MyValidateBSTTests()
        {
            IValidateBST validateBST = new MyValidateBST();
            RunTests(validateBST);
        }

        [TestMethod]
        public void TextbookValidatBSTTests()
        {
            IValidateBST validateBST = new TextbookValidateBST();
            RunTests(validateBST);
        }

        [TestMethod]
        public void TextbookValidateBSTWithMinMaxTests()
        {
            IValidateBST validateBST = new TextbookValidateBSTWithMinMax();
            RunTests(validateBST);
        }

        private void RunTests(IValidateBST validateBST)
        {
            ValidBST(validateBST);
            InvalidBST(validateBST);
        }

        private void ValidBST(IValidateBST validateBST)
        {
            BinaryTreeNode<int> bst = CreateBinarySearchTree();
            bool result = validateBST.IsBST(bst);
            Assert.AreEqual(true, result);
        }

        private void InvalidBST(IValidateBST validateBST)
        {
            BinaryTreeNode<int> bst = CreateInvalidBST();
            bool result = validateBST.IsBST(bst);
            Assert.AreEqual(false, result);
        }

        private BinaryTreeNode<int> CreateBinarySearchTree()
        {
            int[] arr = new int[] { 1, 3, 5, 7, 9, 11, 13 };
            BinaryTreeNode<int> bst = CreateTree(arr);
            return bst;
        }

        private BinaryTreeNode<int> CreateInvalidBST()
        {
            int[] arr = new int[] { 1, 5, 10, 7, 9, 11, 13 };
            BinaryTreeNode<int> tree = CreateTree(arr);
            return tree;
        }

        private BinaryTreeNode<int> CreateTree(int[] arr)
        {
            IMinimalTree minimalTree = new MyMinimalTree();
            BinaryTreeNode<int> tree = minimalTree.CreateMinimalTree(arr);
            return tree;
        }
    }
}
