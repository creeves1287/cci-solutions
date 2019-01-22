using System;
using CheckSubtree;
using GraphsInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SubtreeCheckerTests
{
    [TestClass]
    public class SubtreeCheckerTests
    {
        [TestMethod]
        public void MyCheckSubtreeTests()
        {
            ISubtreeChecker subtreeChecker = new MySubtreeChecker();
            RunTests(subtreeChecker);
        }

        [TestMethod]
        public void TextbookCheckSubtreeWithExtraMemory()
        {
            ISubtreeChecker subtreeChecker = new TextbookSubtreeCheckerExtraMemory();
            RunTests(subtreeChecker);
        }

        [TestMethod]
        public void TextbookCheckSubtreeWithSearch()
        {
            ISubtreeChecker subtreeChecker = new TextbookSubtreeCheckerWithSearch();
            RunTests(subtreeChecker);
        }

        private void RunTests(ISubtreeChecker subtreeChecker)
        {
            //NullTreeTest(subtreeChecker);
            //IncorrectTreeLengthsTest(subtreeChecker);
            IsSubtreeTest(subtreeChecker);
            IsNotSubtreeTest(subtreeChecker);
        }

        private void NullTreeTest(ISubtreeChecker subtreeChecker)
        {
            BinaryTreeNode t1 = new BinaryTreeNode(1);
            BinaryTreeNode t2 = null;
            RunExceptionTest<ArgumentException>(t1, t2, subtreeChecker);
            RunExceptionTest<ArgumentException>(t2, t1, subtreeChecker);
        }

        private void IncorrectTreeLengthsTest(ISubtreeChecker subtreeChecker)
        {
            BinaryTreeNode t1 = CreateMainTree();
            BinaryTreeNode t2 = CreateSubtree();
            RunExceptionTest<ArgumentException>(t2, t1, subtreeChecker);
        }

        private void IsSubtreeTest(ISubtreeChecker subtreeChecker)
        {
            BinaryTreeNode t1 = CreateMainTree();
            BinaryTreeNode t2 = CreateSubtree();
            bool result = subtreeChecker.IsSubtree(t1, t2);
            Assert.AreEqual(true, result);
        }

        private void IsNotSubtreeTest(ISubtreeChecker subtreeChecker)
        {
            BinaryTreeNode t1 = CreateMainTree();
            BinaryTreeNode t2 = CreateNotSubtree();
            bool result = subtreeChecker.IsSubtree(t1, t2);
            Assert.AreEqual(false, result);
        }

        private BinaryTreeNode CreateMainTree()
        {
            BinaryTreeNode root = new BinaryTreeNode
            {
                Value = 1,
                Left = new BinaryTreeNode
                {
                    Value = 2,
                    Left = new BinaryTreeNode
                    {
                        Value = 3,
                        Left = null,
                        Right = null
                    },
                    Right = new BinaryTreeNode
                    {
                        Value = 4,
                        Left = null,
                        Right = null
                    }
                },
                Right = new BinaryTreeNode
                {
                    Value = 5,
                    Left = new BinaryTreeNode
                    {
                        Value = 6,
                        Left = null,
                        Right = null
                    },
                    Right = new BinaryTreeNode
                    {
                        Value = 7,
                        Left = null,
                        Right = null
                    }
                }
            };

            return root;
        }

        private BinaryTreeNode CreateSubtree()
        {
            BinaryTreeNode root = new BinaryTreeNode
            {
                Value = 2,
                Left = new BinaryTreeNode
                {
                    Value = 3,
                    Left = null,
                    Right = null
                },
                Right = new BinaryTreeNode
                {
                    Value = 4,
                    Left = null,
                    Right = null
                }
            };
            return root;
        }

        private BinaryTreeNode CreateNotSubtree()
        {
            BinaryTreeNode root = new BinaryTreeNode
            {
                Value = 6,
                Left = new BinaryTreeNode
                {
                    Value = 3,
                    Left = null,
                    Right = null
                },
                Right = new BinaryTreeNode
                {
                    Value = 4,
                    Left = null,
                    Right = null
                }
            };
            return root;
        }


        private void RunExceptionTest<TException>(BinaryTreeNode t1, BinaryTreeNode t2, ISubtreeChecker subtreeChecker) where TException : Exception
        {
            try
            {
                subtreeChecker.IsSubtree(t1, t2);
                Assert.Fail();
            }
            catch (TException)
            {

            }
        }
    }
}
