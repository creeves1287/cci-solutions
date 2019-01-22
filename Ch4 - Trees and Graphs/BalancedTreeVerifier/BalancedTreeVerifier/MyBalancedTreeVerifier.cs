using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTreeVerifier
{
    public class MyBalancedTreeVerifier<T> : IBalancedTreeVerifier<T>
    {
        public bool IsBalanced(BinaryTreeNode<T> root)
        {
            if (root == null) return false;

            int result = IsBalancedHelper(root);

            if (result == -1) return false;

            return true;
        }

        private int IsBalancedHelper(BinaryTreeNode<T> node)
        {
            if (node == null) return 0;

            int left = IsBalancedHelper(node.Left);
            int right = IsBalancedHelper(node.Right);

            if (left == -1 || right == -1)
                return -1;

            int levelDifference = Math.Abs(left - right);

            if (levelDifference > 1) return -1;

            int highestLevel = (left > right) ? left : right;

            return highestLevel + 1;
        }
    }
}
