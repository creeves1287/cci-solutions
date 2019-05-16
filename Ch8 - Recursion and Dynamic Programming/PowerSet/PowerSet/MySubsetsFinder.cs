using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSet
{
    public class MySubsetsFinder : ISubsetsFinder
    {
        public List<List<int>> FindSubsets(int[] a)
        {
            if (a == null || a.Length == 0) return null;
            List<List<int>> subsets = new List<List<int>>();
            FindSubsets(subsets, a, 0);
            return subsets;
        }

        private void FindSubsets(List<List<int>> subsets, int[] a, int index)
        {
            int value = a[index];
            if (index == a.Length - 1)
            {
                AddValueAsSubset(value, subsets);
                return;
            }

            FindSubsets(subsets, a, index + 1);
            int length = subsets.Count;
            for (int i = 0; i < length; i++)
            {
                List<int> subset = subsets[i];
                List<int> clone = new List<int>(subset);
                clone.Add(value);
                subsets.Add(clone);
            }

            AddValueAsSubset(value, subsets);
        }

        private void AddValueAsSubset(int value, List<List<int>> subsets)
        {
            List<int> subset = new List<int>();
            subset.Add(value);
            subsets.Add(subset);
        }
    }
}
