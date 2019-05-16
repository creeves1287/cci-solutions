using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSet;

namespace PowerSetTests
{
    [TestClass]
    public class SubsetFinderTests
    {
        [TestMethod]
        public void MySubsetFinderTests()
        {
            ISubsetsFinder subsetsFinder = new MySubsetsFinder();
            RunTests(subsetsFinder);
        }

        [TestMethod]
        public void TextbookSubsetFinderCombinatorics()
        {
            ISubsetsFinder subsetsFinder = new TextbookSubsetsFinderCombinatorics();
            RunTests(subsetsFinder);
        }

        private void RunTests(ISubsetsFinder subsetsFinder)
        {
            NullTest(subsetsFinder);
            SubsetFinderTest(subsetsFinder);
        }

        private void NullTest(ISubsetsFinder subsetsFinder)
        {
            int[] a = null;
            List<List<int>> result = subsetsFinder.FindSubsets(a);
            Assert.IsNull(result);
        }

        private void SubsetFinderTest(ISubsetsFinder subsetsFinder)
        {
            int[] a = CreateSet(3);
            //List<List<int>> expected = GetExpectedSet();
            List<List<int>> result = subsetsFinder.FindSubsets(a);
            PrintSubsets(result);
        }

        private int[] CreateSet(int length)
        {
            int[] a = new int[length];
            for (int i = 0; i < length; i++)
            {
                a[i] = i;
            }
            return a;
        }

        private void PrintSubsets(List<List<int>> result)
        {
            Trace.Write("[");
            for (int i = 0; i < result.Count; i++)
            {
                Trace.Write("[");
                for (int j = 0; j < result[i].Count; j++)
                {
                    Trace.Write(result[i][j]);
                    if (j < result[i].Count - 1)
                    {
                        Trace.Write(", ");
                    }
                }
                Trace.Write("]");
                if (i < result.Count - 1)
                {
                    Trace.Write(", ");
                }
            }
            Trace.Write("]");
        }
    }
}
