using System;
using MagicIndex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicIndexTests
{
    [TestClass]
    public class MagicIndexFinderTests
    {
        [TestMethod]
        public void MagicIndexFinderTest()
        {
            IMagicIndexFinder magicIndexFinder = new MagicIndexFinder();
            RunTests(magicIndexFinder);
        }

        private void RunTests(IMagicIndexFinder magicIndexFinder)
        {
            NullInputTest(magicIndexFinder);
            EmptyArrayTest(magicIndexFinder);
            MagicIndexTests(magicIndexFinder);
        }

        private void NullInputTest(IMagicIndexFinder magicIndexFinder)
        {
            int[] a = null;
            int expected = -1;
            int result = magicIndexFinder.FindMagicIndex(a);
            Assert.AreEqual(expected, result);
        }

        private void EmptyArrayTest(IMagicIndexFinder magicIndexFinder)
        {
            int[] a = new int[0];
            int expected = -1;
            int result = magicIndexFinder.FindMagicIndex(a);
            Assert.AreEqual(expected, result);
        }

        private void MagicIndexTests(IMagicIndexFinder magicIndexFinder)
        {
            int[] a = new int[] { 1, 1, 3, 5, 7, 10, 12 };
            int expected = 1;
            int result = magicIndexFinder.FindMagicIndex(a);
            Assert.AreEqual(expected, result);
        }
    }
}
