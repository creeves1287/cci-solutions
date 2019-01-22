using System;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumOfPaths;

namespace SumOfPathsTests
{
    [TestClass]
    public class SumOfPathsTests
    {
        [TestMethod]
        public void MySumOfPathsTests()
        {
            ISumOfPaths sumOfPaths = new MySumOfPaths();
            RunTests(sumOfPaths);
        }

        [TestMethod]
        public void MySumOfPathsTestsWithDict()
        {
            ISumOfPaths sumOfPaths = new MySumOfPathsQuick();
            RunTests(sumOfPaths);
        }

        private void RunTests(ISumOfPaths sumOfPaths)
        {
            NullTreeTest(sumOfPaths);
            SumOfPathsTest(sumOfPaths);
        }

        private void NullTreeTest(ISumOfPaths sumOfPaths)
        {
            BinaryTreeNode<int> node = null;
            int result = sumOfPaths.GetTotalSumsOfPaths(node, 5);
            Assert.AreEqual(0, result);
        }

        private void SumOfPathsTest(ISumOfPaths sumOfPaths)
        {
            BinaryTreeNode<int> root = CreateBinaryTree();
            int sumToCompare = 16;
            int result = sumOfPaths.GetTotalSumsOfPaths(root, sumToCompare);
            int expected = 5;
            Assert.AreEqual(expected, result);
        }

        private BinaryTreeNode<int> CreateBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5)
            {
                Left = new BinaryTreeNode<int>(7)
                {
                    Left = new BinaryTreeNode<int>(9)
                    {
                        Left = new BinaryTreeNode<int>(8),
                        Right = new BinaryTreeNode<int>(4)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(13),
                        Right = new BinaryTreeNode<int>(2)
                    }
                },
                Right = new BinaryTreeNode<int>(8)
                {
                    Left = new BinaryTreeNode<int>(15)
                    {
                        Left = new BinaryTreeNode<int>(-7),
                        Right = new BinaryTreeNode<int>(1)
                    },
                    Right = new BinaryTreeNode<int>(-6)
                    {
                        Left = new BinaryTreeNode<int>(22),
                        Right = new BinaryTreeNode<int>(23)
                    }
                },
            };

            return root;
        }
    }
}
