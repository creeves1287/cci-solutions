using System;
using BooleanEvaluation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BooleanEvaluationTests
{
    [TestClass]
    public class BooleanEvaluatorTests
    {
        [TestMethod]
        public void MyBooleanEvaluatorTests()
        {
            IBooleanEvaluator booleanEvaluator = new MyBooleanEvaluator();
            RunTests(booleanEvaluator);
        }

        private void RunTests(IBooleanEvaluator booleanEvaluator)
        {
            NullTest(booleanEvaluator);
            EmptyStringTest(booleanEvaluator);
            BooleanEvaluationTest1(booleanEvaluator);
        }

        private void NullTest(IBooleanEvaluator booleanEvaluator)
        {
            string expression = null;
            int expected = -1;
            int result = booleanEvaluator.CountBooleanEvaluations(expression, true);
            Assert.AreEqual(expected, result);
        }

        private void EmptyStringTest(IBooleanEvaluator booleanEvaluator)
        {
            string expression = "";
            int expected = 0;
            int result = booleanEvaluator.CountBooleanEvaluations(expression, true);
            Assert.AreEqual(expected, result);
        }

        private void BooleanEvaluationTest1(IBooleanEvaluator booleanEvaluator)
        {
            string expression = "1^0|0|1";
            int expected = 2;
            bool evaluation = false;
            TestBooleanEvaluation(booleanEvaluator, expression, evaluation, expected);
        }

        private void BooleanEvaluationTest2(IBooleanEvaluator booleanEvaluator)
        {
            string expression = "0&0&0&1^1|0";
            int expected = 10;
            bool evaluation = true;
            TestBooleanEvaluation(booleanEvaluator, expression, evaluation, expected);
        }

        private void TestBooleanEvaluation(IBooleanEvaluator booleanEvaluator, string expression, bool evaluation, int expected)
        {
            int result = booleanEvaluator.CountBooleanEvaluations(expression, evaluation);
            Assert.AreEqual(expected, result);
        }
    }
}
