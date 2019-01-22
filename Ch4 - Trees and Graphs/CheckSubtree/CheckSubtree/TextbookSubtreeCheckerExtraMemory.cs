using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSubtree
{
    public class TextbookSubtreeCheckerExtraMemory : ISubtreeChecker
    {
        public bool IsSubtree(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t1 == null)
                throw new ArgumentNullException("t1");

            if (t2 == null)
                throw new ArgumentNullException("t2");

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            GetOrderString(t1, sb1);
            GetOrderString(t2, sb2);

            string s1 = sb1.ToString();
            string s2 = sb2.ToString();

            return s1.Contains(s2);
        }

        private void GetOrderString(BinaryTreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("x");
                return;
            }

            sb.Append(node.Value + " ");
            GetOrderString(node.Left, sb);
            GetOrderString(node.Right, sb);
        }
    }
}
