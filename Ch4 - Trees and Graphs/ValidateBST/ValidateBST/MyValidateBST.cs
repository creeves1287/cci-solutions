using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST
{
    public class MyValidateBST : IValidateBST
    {
        public bool IsBST(BinaryTreeNode<int> root)
        {
            if (root == null) return false;
            return IsBSTHelper(root).IsValid;
        }

        private NodeValueWithValidity<int> IsBSTHelper(BinaryTreeNode<int> root)
        {
            if (root == null) return null;

            NodeValueWithValidity<int> result = new NodeValueWithValidity<int>(root.Value);
            result.IsValid = false;

            NodeValueWithValidity<int> left = IsBSTHelper(root.Left);
            if (left != null && (!left.IsValid || left.Value >= root.Value))
                return result;

            NodeValueWithValidity<int> right = IsBSTHelper(root.Right);
            if (right != null && (!right.IsValid || right.Value <= root.Value))
                return result;

            result.IsValid = true;
            return result;
        }
    }
}
