using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSubtree
{
    public class TextbookSubtreeCheckerWithSearch : ISubtreeChecker
    {
        public bool IsSubtree(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t2 == null)
                return true; //empty tree is always a subtree

            return SubtreeHelper(t1, t2);
        }

        public bool SubtreeHelper(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t1 == null)
                return false; //big tree empty and subtree still not found

            if (t1.Value == t2.Value && MatchTree(t1, t2))
            {
                return true;
            }

            return SubtreeHelper(t1.Left, t2) || SubtreeHelper(t1.Right, t2);
        }

        public bool MatchTree(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true; //nothing left in the subtree

            if (t1 == null || t2 == null)
                return false; //exactly one tree is empty, and therefore the trees do not match

            if (t1.Value != t2.Value)
                return false; //data does not match

            return MatchTree(t1.Left, t2.Left) && MatchTree(t1.Right, t2.Right);
        }
    }
}
