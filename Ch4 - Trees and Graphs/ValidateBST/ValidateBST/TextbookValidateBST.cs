using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST
{
    public class TextbookValidateBST : IValidateBST
    {
        private int? _last = null;

        public bool IsBST(BinaryTreeNode<int> root)
        {
            if (root == null) return true;

            if (!IsBST(root.Left)) return false;

            if (_last != null && root.Value <= _last) return false;

            _last = root.Value;

            if (!IsBST(root.Right)) return false;

            return true;
        }
    }
}
