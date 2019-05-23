using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecursiveMultiply;

namespace RecursiveMultiplyTests
{
    [TestClass]
    public class RecursiveMultiplierTests
    {
        [TestMethod]
        public void MyRecursiveMultiplierTests()
        {
            IRecursiveMultiplier recursiveMultiplier = new MyRecursiveMultiplier();
            RunTests(recursiveMultiplier);
        }

        private void RunTests(IRecursiveMultiplier recursiveMultiplier)
        {
            ZeroInputTests(recursiveMultiplier);
            EvenInputTests(recursiveMultiplier);
            OddInputTests(recursiveMultiplier);
        }

        private void ZeroInputTests(IRecursiveMultiplier recursiveMultiplier)
        {
            int a = 0;
            MultiplyTests(recursiveMultiplier, a);
        }

        private void EvenInputTests(IRecursiveMultiplier recursiveMultiplier)
        {
            int a = 12;
            MultiplyTests(recursiveMultiplier, a);
        }

        private void OddInputTests(IRecursiveMultiplier recursiveMultiplier)
        {
            int a = 11;
            MultiplyTests(recursiveMultiplier, a);
        }

        private void MultiplyTests(IRecursiveMultiplier recursiveMultiplier, int a)
        {
            Random rand = new Random();
            int b = rand.Next();
            MultiplyTest(recursiveMultiplier, a, b);
            MultiplyTest(recursiveMultiplier, b, a);
        }

        private void MultiplyTest(IRecursiveMultiplier recursiveMultiplier, int a, int b)
        {
            long expected = a * b;
            long result = recursiveMultiplier.Multiply(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}
