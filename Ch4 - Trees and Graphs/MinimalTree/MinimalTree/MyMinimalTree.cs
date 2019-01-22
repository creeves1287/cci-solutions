using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalTree
{
    public class MyMinimalTree : IMinimalTree
    {
        public BinaryTreeNode<int> CreateMinimalTree(int[] arr)
        {
            int index = arr.Length / 2;
            BinaryTreeNode<int> root = CreateNode(arr, -1, arr.Length);
            return root;
        }

        private BinaryTreeNode<int> CreateNode(int[] arr, int leftBoundary, int rightBoundary)
        {
            int index = (leftBoundary + rightBoundary + 1) / 2;
            if (index == leftBoundary || index == rightBoundary) return null;
            BinaryTreeNode<int> n = new BinaryTreeNode<int>(arr[index]);
            n.Left = CreateNode(arr, leftBoundary, index);
            n.Right = CreateNode(arr, index, rightBoundary);
            return n;
        }
    }
}
