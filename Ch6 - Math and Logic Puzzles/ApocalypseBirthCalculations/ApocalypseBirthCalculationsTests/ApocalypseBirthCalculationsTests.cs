using System;
using ApocalypseBirthCalculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApocalypseBirthCalculationsTests
{
    [TestClass]
    public class ApocalypseBirthCalculationsTests
    {
        [TestMethod]
        public void ApocalypseBirthCalculatorTests()
        {
            IApocalypseBirthCalculator apocalypseBirthCalculator = new ApocalypseBirthCalculator();
            RunTests(apocalypseBirthCalculator);
        }

        private void RunTests(IApocalypseBirthCalculator apocalypseBirthCalculator)
        {
            int families = 16;
            int expected = 16;
            int result = apocalypseBirthCalculator.GetNumberOfBoys(families);
            Assert.AreEqual(expected, result);
        }
    }
}
