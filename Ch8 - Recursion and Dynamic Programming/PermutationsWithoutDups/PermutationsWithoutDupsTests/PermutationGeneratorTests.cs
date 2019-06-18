using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationsWithoutDups;

namespace PermutationsWithoutDupsTests
{
    [TestClass]
    public class PermutationGeneratorTests
    {
        [TestMethod]
        public void MyPermutationGeneratorTest()
        {
            IPermutationGenerator permutationGenerator = new MyPermutationGenerator();
            RunTests(permutationGenerator);
        }

        [TestMethod]
        public void TextbookPermutationGeneratorTest()
        {
            IPermutationGenerator permutationGenerator = new TextbookPermutationsGenerator();
            RunTests(permutationGenerator);
        }

        private void RunTests(IPermutationGenerator permutationGenerator)
        {
            string s = "abcde";
            List<string> results = permutationGenerator.GeneratePermutations(s);
            PrintResults(results);
        }

        private void PrintResults(List<string> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                string result = results[i];
                Trace.WriteLine(result);
            }
            Trace.WriteLine($"Total Permutations: {results.Count}");
        }
    }
}
