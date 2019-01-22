using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST
{
    public class TextbookValidateBSTWithMinMax : IValidateBST
    {
        public bool IsBST(BinaryTreeNode<int> n)
        {
            return IsBST(n, null, null);
        }

        public bool IsBST(BinaryTreeNode<int> n, int? min, int? max)
        {
            if (n == null) return true;

            if ((min != null && n.Value <= min) || (max != null && n.Value > max))
                return false;

            if (!IsBST(n.Left, min, n.Value) || !IsBST(n.Right, n.Value, max))
                return false;

            return true;
        }
    }
}
