using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parens;

namespace ParensTests
{
    [TestClass]
    public class ParensPrinterTests
    {
        [TestMethod]
        public void MyParensPrinterTests()
        {
            IParensPrinter parensPrinter = new MyParensPrinter();
            RunTests(parensPrinter);
        }

        [TestMethod]
        public void TextbookParensPrinterTests()
        {
            IParensPrinter parensPrinter = new TextbookParensPrinter();
            RunTests(parensPrinter);
        }

        [TestMethod]
        public void TextbookParensPrinterEfficientTests()
        {
            IParensPrinter parensPrinter = new TextbookParensPrinterEfficient();
            RunTests(parensPrinter);
        }

        private void RunTests(IParensPrinter parensPrinter)
        {
            int n = 5;
            IEnumerable<string> result = parensPrinter.PrintParens(n);
            PrintResult(result);
        }

        private void PrintResult(IEnumerable<string> result)
        {
            List<string> resultList = result.ToList();
            for (int i = 0; i < resultList.Count; i++)
            {
                Trace.WriteLine(resultList[i]);
            }
            Trace.WriteLine($"Total Count: { resultList.Count }");
        }
    }
}
