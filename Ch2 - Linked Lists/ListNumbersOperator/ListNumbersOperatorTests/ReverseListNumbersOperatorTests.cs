using System;
using LinkedList;
using ListNumbersOperator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListNumbersOperatorTests
{
    [TestClass]
    public class ReverseListNumbersOperatorTests
    {
        [TestMethod]
        public void TextbookReverseListNumbersOperatorTest()
        {
            IListNumbersOperator listNumbersOperator = new TextbookReverseListNumbersOperator();
            RunTests(listNumbersOperator);
        }

        [TestMethod]
        public void MyReverseListNumbersOperatorWithStackTest()
        {
            IListNumbersOperator listNumbersOperator = new MyReverseListNumbersOperatorWithStack();
            RunTests(listNumbersOperator);
        }

        private void RunTests(IListNumbersOperator listNumbersOperator)
        {
            AddEqualListsTest(listNumbersOperator);
            AddFirstLongerListsTest(listNumbersOperator);
            AddSecondLongerListsTest(listNumbersOperator);
        }

        private void AddEqualListsTest(IListNumbersOperator listNumbersOperator)
        {
            int onesDigit = 9;
            int tensDigit = 5;
            int hundredsDigit = 7;
            Node<int> first = CreateList(hundredsDigit, tensDigit, onesDigit);

            onesDigit = 7;
            tensDigit = 4;
            hundredsDigit = 8;
            Node<int> second = CreateList(hundredsDigit, tensDigit, onesDigit);

            onesDigit = 6;
            tensDigit = 0;
            hundredsDigit = 6;
            int thousandsDigit = 1;
            Node<int> expected = CreateList(thousandsDigit, hundredsDigit, tensDigit, onesDigit);

            Node<int> result = listNumbersOperator.AddNumbers(first, second);

            AssertResult(expected, result);
        }

        private void AddFirstLongerListsTest(IListNumbersOperator listNumbersOperator)
        {
            int onesDigit = 9;
            int tensDigit = 5;
            int hundredsDigit = 7;
            int thousandsDigit = 9;
            Node<int> first = CreateList(thousandsDigit, hundredsDigit, tensDigit, onesDigit);

            onesDigit = 7;
            tensDigit = 4;
            hundredsDigit = 8;
            Node<int> second = CreateList(hundredsDigit, tensDigit, onesDigit);

            onesDigit = 6;
            tensDigit = 0;
            hundredsDigit = 6;
            thousandsDigit = 0;
            int tenThousandsDigit = 1;
            Node<int> expected = CreateList(tenThousandsDigit, thousandsDigit, hundredsDigit, tensDigit, onesDigit);

            Node<int> result = listNumbersOperator.AddNumbers(first, second);

            AssertResult(expected, result);
        }

        private void AddSecondLongerListsTest(IListNumbersOperator listNumbersOperator)
        {
            int onesDigit = 9;
            int tensDigit = 5;
            int hundredsDigit = 7;
            int thousandsDigit = 9;
            Node<int> first = CreateList(thousandsDigit, hundredsDigit, tensDigit, onesDigit);

            onesDigit = 7;
            tensDigit = 4;
            hundredsDigit = 8;
            thousandsDigit = 8;
            int tenThousandsDigit = 9;
            Node<int> second = CreateList(tenThousandsDigit, thousandsDigit, hundredsDigit, tensDigit, onesDigit);

            onesDigit = 6;
            tensDigit = 0;
            hundredsDigit = 6;
            thousandsDigit = 8;
            tenThousandsDigit = 0;
            int hundredThousandsDigit = 1;
            Node<int> expected = CreateList(hundredThousandsDigit, tenThousandsDigit, thousandsDigit, hundredsDigit, tensDigit, onesDigit);

            Node<int> result = listNumbersOperator.AddNumbers(first, second);

            AssertResult(expected, result);
        }


        private void AssertResult(Node<int> expected, Node<int> result)
        {
            while (expected != null)
            {
                Assert.AreEqual(expected.Data, result.Data);
                expected = expected.Next;
                result = result.Next;
            }

            if (result != null)
            {
                throw new AssertFailedException("Result is longer than expected.");
            }
        }

        private Node<int> CreateList(params int[] numbers)
        {
            Node<int> node = null;
            Node<int> head = null;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (node == null)
                {
                    node = head = CreateNode(number);
                    number = numbers[++i];
                }
                node.Next = CreateNode(number);
                node = node.Next;
            }
            return head;
        }

        private Node<int> CreateNode(int data)
        {
            return new Node<int>
            {
                Data = data
            };
        }
    }
}
