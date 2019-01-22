using System;
using BalancedTreeVerifier;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalTree;

namespace BalancedTreeVerifierTests
{
    [TestClass]
    public class BalancedTreeVerifierTests
    {
        [TestMethod]
        public void MyBalancedTreeVerifierTest()
        {
            IBalancedTreeVerifier<int> balancedTreeVerifier = new MyBalancedTreeVerifier<int>();
            RunTests(balancedTreeVerifier);
        }

        [TestMethod]
        public void TextbookBalancedTreeVerifierTest()
        {
            IBalancedTreeVerifier<int> balancedTreeVerifier = new TextbookBalancedTreeVerifier<int>();
            RunTests(balancedTreeVerifier);
        }

        private void RunTests(IBalancedTreeVerifier<int> balancedTreeVerifier)
        {
            VerifyUnbalancedTree(balancedTreeVerifier);
            VerifyBalancedTree(balancedTreeVerifier);
        }

        private void VerifyUnbalancedTree(IBalancedTreeVerifier<int> balancedTreeVerifier)
        {
            BinaryTreeNode<int> root = BuildUnbalancedBinaryTree();
            bool result = balancedTreeVerifier.IsBalanced(root);
            Assert.AreEqual(false, result);
        }
        private void VerifyBalancedTree(IBalancedTreeVerifier<int> balancedTreeVerifier)
        {
            BinaryTreeNode<int> root = BuildBalancedBinaryTree();
            bool result = balancedTreeVerifier.IsBalanced(root);
            Assert.AreEqual(true, result);
        }

        private BinaryTreeNode<int> BuildUnbalancedBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5)
            {
                Left = new BinaryTreeNode<int>(3)
                {
                    Left = new BinaryTreeNode<int>(2),
                    Right = new BinaryTreeNode<int>(6)
                },
                Right = null
            };

            return root;
        }
        private BinaryTreeNode<int> BuildBalancedBinaryTree()
        {
            MyMinimalTree myMinimalTree = new MyMinimalTree();
            int[] arr = new int[] { 3, 4, 6, 8, 10 };
            BinaryTreeNode<int> root = myMinimalTree.CreateMinimalTree(arr);
            return root;
        }
    }
}
