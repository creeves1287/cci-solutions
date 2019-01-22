using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSubtree
{
    public class MySubtreeChecker : ISubtreeChecker
    {
        int _base = 128;
        public bool IsSubtree(BinaryTreeNode main, BinaryTreeNode sub)
        {
            if (main == null)
                throw new ArgumentException("main cannot be null.");

            if (sub == null)
                throw new ArgumentException("sub cannot be null.");

            List<int> a1 = new List<int>();
            List<int> a2 = new List<int>();
            PreorderTraverse(main, a1);
            PreorderTraverse(sub, a2);
            return IsSubarray(a1, a2);
        }

        private void PreorderTraverse(BinaryTreeNode root, List<int> values)
        {
            if (root == null)
            {
                values.Add(_base);
                return;
            }

            values.Add(root.Value);
            PreorderTraverse(root.Left, values);
            PreorderTraverse(root.Right, values);
        }

        private bool IsSubarray(List<int> mainArr, List<int> subArr)
        {
            if (mainArr.Count < subArr.Count)
                throw new ArgumentException("Length of mainArr must be greater than or equal to the length of subArr");

            long subHash = CreateHash(subArr, subArr.Count);
            long mainHash = CreateHash(mainArr, subArr.Count);

            if (subHash == mainHash)
                return true;

            for (int i = subArr.Count; i < mainArr.Count; i++)
            {
                mainHash = UpdateHash(i - subArr.Count, mainArr, i, mainHash);
                if (mainHash == subHash)
                    return true;
            }
            return false;
        }

        private long CreateHash(List<int> values, int length)
        {
            if (length > values.Count)
                throw new ArgumentException("Length cannot be larger than the number of values.");

            long hash = 0;

            for (int i = 0; i < length; i++)
            {
                hash += values[i] * (long)Math.Pow(_base, i);
            }

            return hash;
        }

        private long UpdateHash(int indexToRemove, List<int> values, int indexToAdd, long hash)
        {
            int exp = indexToAdd - indexToRemove - 1;
            hash -= values[indexToRemove];
            hash /= _base;
            hash += values[indexToAdd] * (long)Math.Pow(_base, exp);
            return hash;
        }
    }
}
