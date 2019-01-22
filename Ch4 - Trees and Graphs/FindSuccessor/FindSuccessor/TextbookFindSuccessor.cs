using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSuccessor
{
    public class TextbookFindSuccessor : IFindSuccessor
    {
        public BinaryTreeNode<int> FindSuccessor(BinaryTreeNode<int> node)
        {
            if (node == null) return null;

            if (node.Right != null)
            {
                return GetLeftmostNode(node.Right);
            }

            BinaryTreeNode<int> q = node;
            BinaryTreeNode<int> x = q;

            while (x != null && q != x.Left)
            {
                q = x;
                x = x.Parent;
            }

            return x;
        }

        private BinaryTreeNode<T> GetLeftmostNode<T>(BinaryTreeNode<T> node)
        {
            if (node == null) return null;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}
