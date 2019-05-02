using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleStep;

namespace TripleStepTests
{
    [TestClass]
    public class WaysToStepTests
    {
        [TestMethod]
        public void MyWaysToStepTests()
        {
            IWaysToStepCounter waysToStepCounter = new MyWaysToStepCounter();
            RunTests(waysToStepCounter);
        }

        [TestMethod]
        public void TextbookWaysToStepTests()
        {
            IWaysToStepCounter waysToStepCounter = new TextbookCountWaysToStepCounter();
            RunTests(waysToStepCounter);
        }

        private void RunTests(IWaysToStepCounter waysToStepCounter)
        {
            NegativeStepsTest(waysToStepCounter);
            ZeroStepsTest(waysToStepCounter);
            CountWaysToStepTest(waysToStepCounter);
        }

        private void NegativeStepsTest(IWaysToStepCounter waysToStepCounter)
        {
            int n = -1;
            int expected = 0;
            AssertResult(waysToStepCounter, expected, n);
        }

        private void ZeroStepsTest(IWaysToStepCounter waysToStepCounter)
        {
            //int n = 0;
            //int expected = 0;
            //AssertResult(waysToStepCounter, expected, n);
        }

        private void CountWaysToStepTest(IWaysToStepCounter waysToStepCounter)
        {
            int n = 5;
            int expected = 13;
            AssertResult(waysToStepCounter, expected, n);
        }

        private void AssertResult(IWaysToStepCounter waysToStepCounter, int expected, int n)
        {
            int result = waysToStepCounter.CountWaysToStep(n);
            Assert.AreEqual(expected, result);
        }
    }
}
