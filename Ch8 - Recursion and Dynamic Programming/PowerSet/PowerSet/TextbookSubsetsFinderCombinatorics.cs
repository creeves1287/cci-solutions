using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSet
{
    public class TextbookSubsetsFinderCombinatorics : ISubsetsFinder
    {
        public List<List<int>> FindSubsets(int[] a)
        {
            if (a == null) return null;
            List<List<int>> subsets = new List<List<int>>();
            int max = 1 << a.Length;
            for (int k = 0; k < max; k++)
            {
                List<int> subset = ConvertIntToSet(k, a);
                subsets.Add(subset);
            }
            return subsets;
        }

        private List<int> ConvertIntToSet(int x, int[] a)
        {
            List<int> subset = new List<int>();
            int index = 0;
            for (int k = x; k > 0; k >>= 1)
            {
                if ((k & 1) == 1)
                {
                    subset.Add(a[index]);
                }
                index++;
            }
            return subset;
        }
    }
}
