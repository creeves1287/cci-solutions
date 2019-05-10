using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicIndex
{
    public class MagicIndexFinder : IMagicIndexFinder
    {
        public int FindMagicIndex(int[] a)
        {
            if (a == null || a.Length == 0) return -1;
            return FindMagicIndex(a, 0, a.Length);
        }

        private int FindMagicIndex(int[] a, int start, int end)
        {
            int midIndex = (start + end) / 2;
            int midValue = a[midIndex];

            if (midIndex == midValue)
                return midValue;

            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = FindMagicIndex(a, start, leftIndex);
            if (left > 0)
                return left;

            int rightIndex = Math.Max(midIndex + 1, midValue);
            int right = FindMagicIndex(a, rightIndex, end);

            return right;
        }
    }
}
