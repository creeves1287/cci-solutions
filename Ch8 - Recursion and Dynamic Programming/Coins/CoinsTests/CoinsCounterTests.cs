using System;
using System.Collections.Generic;
using System.Diagnostics;
using CoinsCounting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinsTests
{
    [TestClass]
    public class CoinsCounterTests
    {
        [TestMethod]
        public void MyCoinCounterTests()
        {
            ICoinsCounter coinsCounter = new MyCoinCounter();
            RunTests(coinsCounter);
        }

        [TestMethod]
        public void TextbookCoinCounterTests()
        {
            ICoinsCounter coinsCounter = new TextbookCoinCounter();
            RunTests(coinsCounter);
        }

        [TestMethod]
        public void TextbookCoinCounterWithMemoTests()
        {
            ICoinsCounter coinsCounter = new TextbookCoinCounterWithMemo();
            RunTests(coinsCounter);
        }

        private void RunTests(ICoinsCounter coinsCounter)
        {
            int n = 100;
            int expected = 242;
            int result = coinsCounter.CountCoinCombinations(n);
            Assert.AreEqual(expected, result);
        }

        //private void PrintResult(List<Coins> result)
        //{
        //    foreach(Coins coins in result)
        //    {
        //        Trace.WriteLine($"Quarters: { coins.Quarters }");
        //        Trace.WriteLine($"Dimes: { coins.Dimes }");
        //        Trace.WriteLine($"Nickels: { coins.Nickels }");
        //        Trace.WriteLine($"Pennies: { coins.Pennies }\n");
        //    }
        //    Trace.WriteLine($"Total Count: { result.Count }");
        //}
    }
}
