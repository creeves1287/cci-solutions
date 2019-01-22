using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSuccessor
{
    public class MyFindSuccessor : IFindSuccessor
    {
        public BinaryTreeNode<int> FindSuccessor(BinaryTreeNode<int> node)
        {
            if (node == null) return null;
            BinaryTreeNode<int> current;
            if (node.Right != null)
            {
                current = node.Right;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current;
            }

            current = node;

            while (current.Parent != null)
            {
                current = current.Parent;

                if (current.Value >= node.Value)
                    return current;
            }

            return node;
        }
    }
}
