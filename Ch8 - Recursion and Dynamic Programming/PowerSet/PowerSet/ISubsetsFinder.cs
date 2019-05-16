using System.Collections.Generic;

namespace PowerSet
{
    public interface ISubsetsFinder
    {
        List<List<int>> FindSubsets(int[] a);
    }
}