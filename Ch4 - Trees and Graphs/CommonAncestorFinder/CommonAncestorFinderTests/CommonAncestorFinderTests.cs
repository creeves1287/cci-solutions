using System;
using CommonAncestorFinder;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonAncestorFinderTests
{
    [TestClass]
    public class CommonAncestorFinderTests
    {
        [TestMethod]
        public void MyCommonAncestorFinderTests()
        {
            ICommonAncestorFinder commonAncestorFinder = new MyCommonAncestorFinder();
            RunTests(commonAncestorFinder);
        }

        private void RunTests(ICommonAncestorFinder commonAncestorFinder)
        {
            NullRootTest(commonAncestorFinder);
            NullNodesTest(commonAncestorFinder);
            AncestorFoundTest(commonAncestorFinder);
        }

        private void NullRootTest(ICommonAncestorFinder commonAncestorFinder)
        {
            BinaryTreeNode<int> root = null;
            BinaryTreeNode<int> node1 = new BinaryTreeNode<int>(9);
            BinaryTreeNode<int> node2 = new BinaryTreeNode<int>(10);
            BinaryTreeNode<int> result = commonAncestorFinder.FindCommonAncestor(root, node1, node2);
            BinaryTreeNode<int> expected = null;
            Assert.AreEqual(expected, result);
        }

        private void NullNodesTest(ICommonAncestorFinder commonAncestorFinder)
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(9);
            BinaryTreeNode<int> node1 = null;
            BinaryTreeNode<int> node2 = new BinaryTreeNode<int>(10);
            BinaryTreeNode<int> result1 = commonAncestorFinder.FindCommonAncestor(root, node1, node2);
            BinaryTreeNode<int> result2 = commonAncestorFinder.FindCommonAncestor(root, node2, node1);
            BinaryTreeNode<int> expected = null;
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
        }

        private void AncestorFoundTest(ICommonAncestorFinder commonAncestorFinder)
        {
            BinaryTreeNode<int> root = BuildBinaryTree();
            BinaryTreeNode<int> node1 = root.Left.Right;
            BinaryTreeNode<int> node2 = root.Left.Left.Right;
            BinaryTreeNode<int> expected = root.Left;
            BinaryTreeNode<int> result = commonAncestorFinder.FindCommonAncestor(root, node1, node2);
            Assert.AreEqual(expected, result);
        }

        private BinaryTreeNode<int> BuildBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10)
            {
                Left = new BinaryTreeNode<int>(6)
                {
                    Left = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(1),
                        Right = new BinaryTreeNode<int>(4)
                    },
                    Right = new BinaryTreeNode<int>(8)
                    {
                        Left = new BinaryTreeNode<int>(7),
                        Right = new BinaryTreeNode<int>(9)
                    }
                },
                Right = new BinaryTreeNode<int>(13)
                {
                    Left = new BinaryTreeNode<int>(12)
                    {
                        Left = new BinaryTreeNode<int>(11),
                        Right = new BinaryTreeNode<int>(14)
                    },
                    Right = new BinaryTreeNode<int>(16)
                    {
                        Left = new BinaryTreeNode<int>(15),
                        Right = new BinaryTreeNode<int>(18)
                    }
                }
            };

            return root;
        }

    }
}
