using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAncestorFinder
{
    public class MyCommonAncestorFinder : ICommonAncestorFinder
    {
        public BinaryTreeNode<int> FindCommonAncestor(BinaryTreeNode<int> root, BinaryTreeNode<int> node1, BinaryTreeNode<int> node2)
        {
            if (root == null || node1 == null || node2 == null) return null;

            if (node1 == node2) return node1;

            return FindCommonAncestorHelper(root, node1, node2);
        }

        private BinaryTreeNode<int> FindCommonAncestorHelper(BinaryTreeNode<int> root, BinaryTreeNode<int> node1, BinaryTreeNode<int> node2)
        {
            if (root == null) return null;

            BinaryTreeNode<int> ancestor1 = FindCommonAncestorHelper(root.Left, node1, node2);
            BinaryTreeNode<int> ancestor2 = FindCommonAncestorHelper(root.Right, node1, node2);

            if (ancestor1 != null && ancestor2 != null)
                return root;

            if (root == node1 || root == node2)
                return root;

            if (ancestor1 != null)
                return ancestor1;

            if (ancestor2 != null)
                return ancestor2;

            return null;
        }
    }
}
