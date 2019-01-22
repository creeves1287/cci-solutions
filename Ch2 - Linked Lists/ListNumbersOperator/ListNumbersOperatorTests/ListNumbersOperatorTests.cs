using System;
using LinkedList;
using ListNumbersOperator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListNumbersOperatorTests
{
    [TestClass]
    public class ListNumbersOperatorTests
    {
        [TestMethod]
        public void MyListNumbersOperatorTest()
        {
            IListNumbersOperator listNumbersOperator = new MyListNumbersOperator();
            RunTests(listNumbersOperator);
        }

        [TestMethod]
        public void TextbookListNumbersOperatorTest()
        {
            IListNumbersOperator listNumbersOperator = new TextbookListNumbersOperator();
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
            Node<int> first = CreateList(onesDigit, tensDigit, hundredsDigit);

            onesDigit = 7;
            tensDigit = 4;
            hundredsDigit = 8;
            Node<int> second = CreateList(onesDigit, tensDigit, hundredsDigit);

            onesDigit = 6;
            tensDigit = 0;
            hundredsDigit = 6;
            int thousandsDigit = 1;
            Node<int> expected = CreateList(onesDigit, tensDigit, hundredsDigit, thousandsDigit);

            Node<int> result = listNumbersOperator.AddNumbers(first, second);

            AssertResult(expected, result);
        }

        private void AddFirstLongerListsTest(IListNumbersOperator listNumbersOperator)
        {
            int onesDigit = 9;
            int tensDigit = 5;
            int hundredsDigit = 7;
            int thousandsDigit = 9;
            Node<int> first = CreateList(onesDigit, tensDigit, hundredsDigit, thousandsDigit);

            onesDigit = 7;
            tensDigit = 4;
            hundredsDigit = 8;
            Node<int> second = CreateList(onesDigit, tensDigit, hundredsDigit);

            onesDigit = 6;
            tensDigit = 0;
            hundredsDigit = 6;
            thousandsDigit = 0;
            int tenThousandsDigit = 1;
            Node<int> expected = CreateList(onesDigit, tensDigit, hundredsDigit, thousandsDigit, tenThousandsDigit);

            Node<int> result = listNumbersOperator.AddNumbers(first, second);
            
            AssertResult(expected, result);
        }

        private void AddSecondLongerListsTest(IListNumbersOperator listNumbersOperator)
        {
            int onesDigit = 9;
            int tensDigit = 5;
            int hundredsDigit = 7;
            int thousandsDigit = 9;
            Node<int> first = CreateList(onesDigit, tensDigit, hundredsDigit, thousandsDigit);

            onesDigit = 7;
            tensDigit = 4;
            hundredsDigit = 8;
            thousandsDigit = 8;
            int tenThousandsDigit = 9;
            Node<int> second = CreateList(onesDigit, tensDigit, hundredsDigit, thousandsDigit, tenThousandsDigit);

            onesDigit = 6;
            tensDigit = 0;
            hundredsDigit = 6;
            thousandsDigit = 8;
            tenThousandsDigit = 0;
            int hundredThousandsDigit = 1;
            Node<int> expected = CreateList(onesDigit, tensDigit, hundredsDigit, thousandsDigit, tenThousandsDigit, hundredThousandsDigit);

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
