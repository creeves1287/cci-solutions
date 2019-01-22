using System;
using System.Collections.Generic;
using BinaryTreeToLinkedList;
using GraphsInfrastructure;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalTree;

namespace BinaryTreeToLinkedListTests
{
    [TestClass]
    public class LinkedListFromTreeCreatorTests
    {
        [TestMethod]
        public void MyLinkedListFromTreeCreatorTests()
        {
            ILinkedListFromTreeCreator<int> linkedListFromTreeCreator = new MyLinkedListFromTreeCreator<int>();
            RunTests(linkedListFromTreeCreator);
        }

        [TestMethod]
        public void TextbookLinkedListFromTreeCreatorTests()
        {
            TextbookLinkedListFromTreeCreator<int> textbookLinkedListFromTreeCreator = new TextbookLinkedListFromTreeCreator<int>();
            RunTests(textbookLinkedListFromTreeCreator);
        }

        private void RunTests(TextbookLinkedListFromTreeCreator<int> textbookLinkedListFromTreeCreator)
        {
            CreateListFromTreeTest(textbookLinkedListFromTreeCreator);
        }

        private void RunTests(ILinkedListFromTreeCreator<int> linkedListFromTreeCreator)
        {
            CreateListFromTreeTest(linkedListFromTreeCreator);
        }

        private void CreateListFromTreeTest(ILinkedListFromTreeCreator<int> linkedListFromTreeCreator)
        {
            int[] arr = CreateArray();
            IMinimalTree minimalTree = new MyMinimalTree();
            BinaryTreeNode<int> node = minimalTree.CreateMinimalTree(arr);
            var treeListNode = linkedListFromTreeCreator.CreateLinkedListFromBinaryTree(node);
            ValidateList(treeListNode, arr);
        }

        private void ValidateList(LinkedList.LinkedListNode<LinkedList.LinkedListNode<BinaryTreeNode<int>>> treeListNode, int[] arr)
        {
            var expected = new int[] { 6, 3, 8, 1, 5, 7, 23 };
            var current = treeListNode;
            int i = 0;
            while (current != null)
            {
                var subNode = current.Data;
                while (subNode != null)
                {
                    arr[i] = subNode.Data.Value;
                    Assert.AreEqual(expected[i], arr[i]);
                    i++;
                    subNode = subNode.Next;
                }
                current = current.Next;
            }
        }

        private void CreateListFromTreeTest(TextbookLinkedListFromTreeCreator<int> linkedListFromTreeCreator)
        {
            int[] arr = CreateArray();
            IMinimalTree minimalTree = new MyMinimalTree();
            BinaryTreeNode<int> node = minimalTree.CreateMinimalTree(arr);
            var treeListNode = linkedListFromTreeCreator.CreateLinkedListFromBinaryTree(node);
            ValidateList(treeListNode, arr);
        }

        private void ValidateList(List<LinkedList<BinaryTreeNode<int>>> treeList, int[] arr)
        {
            var expected = new int[] { 6, 3, 8, 1, 5, 7, 23 };
            var current = treeList;
            int i = 0;
            foreach(var list in treeList)
            {
                foreach (var item in list)
                {
                    arr[i] = item.Value;
                    Assert.AreEqual(expected[i], arr[i]);
                    i++;
                }
            }
        }


        private int[] CreateArray()
        {
            return new int[] { 1, 3, 5, 6, 7, 8, 23 };
        }
    }
}
