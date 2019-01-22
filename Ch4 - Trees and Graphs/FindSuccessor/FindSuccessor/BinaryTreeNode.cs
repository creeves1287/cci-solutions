using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSuccessor
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Parent { set; get; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }
}
