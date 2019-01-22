using System;
using BuildOrder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildOrderTests
{
    [TestClass]
    public class BuildOrderTests
    {
        [TestMethod]
        public void MyBuildOrderTests()
        {
            IBuildOrder buildOrder = new MyBuildOrder();
            RunTests(buildOrder);
        }

        [TestMethod]
        public void TextbookBuildOrderTests()
        {
            IBuildOrder buildOrder = new TextbookBuildOrder();
            RunTests(buildOrder);
        }

        private void RunTests(IBuildOrder buildOrder)
        {
            BuildOrderTest(buildOrder);
        }

        private void BuildOrderTest(IBuildOrder buildOrder)
        {
            string[] projects = new string[] { "a", "b", "c", "d", "e" };
            string[][] dependencies = new string[][]
            {
                new string[] { "a", "c" },
                new string[] { "a", "b" },
                new string[] { "b", "c"},
                new string[] { "d", "e"},
                new string[] { "c", "e"}
            };

            string[] expected = new string[] { "a", "b", "c", "d", "e" };

            string[] order = buildOrder.GetBuildOrder(projects, dependencies);

            for (int i = 0; i < order.Length; i++)
            {
                Assert.AreEqual(expected[i], order[i]);
            }
        }
    }
}
