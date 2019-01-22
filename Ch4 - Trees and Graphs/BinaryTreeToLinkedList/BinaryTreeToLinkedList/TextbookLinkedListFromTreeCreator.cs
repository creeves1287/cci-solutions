using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeToLinkedList
{
    public class TextbookLinkedListFromTreeCreator<T>
    {
        public List<LinkedList<BinaryTreeNode<T>>> CreateLinkedListFromBinaryTree(BinaryTreeNode<T> root)
        {
            List<LinkedList<BinaryTreeNode<T>>> lists = new List<LinkedList<BinaryTreeNode<T>>>();
            int level = 0;
            CreateLinkedListFromBinaryTree(root, lists, level);
            return lists;
        }

        private void CreateLinkedListFromBinaryTree(BinaryTreeNode<T> root, List<LinkedList<BinaryTreeNode<T>>> lists, int level)
        {
            if (root == null) return;

            if (lists.Count == level)
                lists.Add(new LinkedList<BinaryTreeNode<T>>());

            lists[level].AddLast(root);

            CreateLinkedListFromBinaryTree(root.Left, lists, level + 1);
            CreateLinkedListFromBinaryTree(root.Right, lists, level + 1);
        }
    }
}
