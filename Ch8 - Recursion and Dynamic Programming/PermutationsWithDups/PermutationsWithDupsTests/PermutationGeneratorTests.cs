using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationsWithDups;

namespace PermutationsWithDupsTests
{
    [TestClass]
    public class PermutationGeneratorTests
    {
        [TestMethod]
        public void PermutationGeneratorTest()
        {
            IPermutationsGenerator permutationsGenerator = new PermutationsGenerator();
            RunTests(permutationsGenerator);
        }

        private void RunTests(IPermutationsGenerator permutationsGenerator)
        {
            string s = "abcda";
            List<string> result = permutationsGenerator.GeneratePermutations(s);
            foreach (string item in result)
            {
                Trace.WriteLine(item);
            }
            Trace.WriteLine($"Total Permutations: { result.Count }");
        }
    }
}
