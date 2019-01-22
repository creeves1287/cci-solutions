using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringRotationChecker;

namespace StringRotationCheckerTests
{
    [TestClass]
    public class StringRotationCheckerTests
    {
        [TestMethod]
        public void MyStringRotationCheckerTest()
        {
            IStringRotationChecker stringRotationChecker = new MyStringRotationChecker();
            RunTests(stringRotationChecker);
        }

        [TestMethod]
        public void TextbookStringRotationCheckerTest()
        {
            IStringRotationChecker stringRotationChecker = new TextbookStringRotationChecker();
            RunTests(stringRotationChecker);
        }

        private void RunTests(IStringRotationChecker stringRotationChecker)
        {
            IsStringRotation(stringRotationChecker);
            IsNotStringRotation(stringRotationChecker);
            IsNotStringRotationSameLength(stringRotationChecker);
            IsNotRotatedStringDifferentTail(stringRotationChecker);
        }

        private void IsStringRotation(IStringRotationChecker stringRotationChecker)
        {
            string s1 = "iamastring";
            string s2 = "astringiam";

            bool expected = true;
            bool actual = stringRotationChecker.IsRotatedString(s1, s2);

            Assert.AreEqual(expected, actual);
        }

        private void IsNotStringRotation(IStringRotationChecker stringRotationChecker)
        {
            string s1 = "iamastring";
            string s2 = "thisisgarbage";
            AssertFalse(s1, s2, stringRotationChecker);
        }

        private void IsNotStringRotationSameLength(IStringRotationChecker stringRotationChecker)
        {
            string s1 = "iamastring";
            string s2 = "thisisgarb";
            AssertFalse(s1, s2, stringRotationChecker);
        }

        private void IsNotRotatedStringDifferentTail(IStringRotationChecker stringRotationChecker)
        {
            string s1 = "iamastring";
            string s2 = "astringino";
            AssertFalse(s1, s2, stringRotationChecker);
        }

        private void AssertFalse(string s1, string s2, IStringRotationChecker stringRotationChecker)
        {
            bool expected = false;
            bool actual = stringRotationChecker.IsRotatedString(s1, s2);
            Assert.AreEqual(expected, actual);
        }
    }
}
