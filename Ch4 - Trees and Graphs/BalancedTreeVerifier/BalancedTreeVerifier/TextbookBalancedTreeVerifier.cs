using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTreeVerifier
{
    public class TextbookBalancedTreeVerifier<T> : IBalancedTreeVerifier<T>
    {
        public bool IsBalanced(BinaryTreeNode<T> root)
        {
            return CheckHeight(root) != int.MinValue;
        }

        private int CheckHeight(BinaryTreeNode<T> root)
        {
            if (root == null) return -1;

            int leftHeight = CheckHeight(root.Left);
            if (leftHeight == int.MinValue) return int.MinValue;

            int rightHeight = CheckHeight(root.Right);
            if (rightHeight == int.MinValue) return int.MinValue;

            int heightDifference = leftHeight - rightHeight;

            if (Math.Abs(heightDifference) > 1) return int.MinValue;

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
