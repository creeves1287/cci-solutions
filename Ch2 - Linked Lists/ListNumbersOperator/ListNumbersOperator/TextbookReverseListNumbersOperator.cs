using System;
using LinkedList;

namespace ListNumbersOperator
{
    public class TextbookReverseListNumbersOperator : IListNumbersOperator
    {
        public Node<int> AddNumbers(Node<int> first, Node<int> second)
        {
            int carry = 0;
            Node<int> sum = AddNumbers(first, second, carry);
            return sum;
        }

        private Node<int> AddNumbers(Node<int> first, Node<int> second, int carry)
        {
            int firstLength = Length(first);
            int secondLength = Length(second);

            if (firstLength < secondLength)
            {
                first = PadList(first, secondLength - firstLength);
            }
            else
            {
                second = PadList(second, firstLength - secondLength);
            }

            PartialSum sum = AddNumbersHelper(first, second);

            if (sum.Carry == 0)
            {
                return sum.Sum;
            }

            Node<int> result = InsertBefore(sum.Sum, sum.Carry);

            return result;
        }

        private PartialSum AddNumbersHelper(Node<int> first, Node<int> second)
        {
            PartialSum sum;
            if (first == null && second == null)
            {
                sum = new PartialSum();
                return sum;
            }
            sum = AddNumbersHelper(first.Next, second.Next);

            int val = sum.Carry + first.Data + second.Data;

            Node<int> fullResult = InsertBefore(sum.Sum, val % 10);

            sum.Sum = fullResult;
            sum.Carry = val / 10;

            return sum;
        }

        private Node<int> PadList(Node<int> node, int padding)
        {
            for (int i = 0; i < padding; i++)
            {
                node = InsertBefore(node, 0);
            }
            return node;
        }

        private Node<int> InsertBefore(Node<int> head, int data)
        {
            Node<int> node = new Node<int>();
            node.Data = data;

            if (node != null)
            {
                node.Next = head;
            }

            return node;
        }

        private int Length(Node<int> node)
        {
            int counter = 0;

            while (node != null)
            {
                counter++;
                node = node.Next;
            }

            return counter;
        }

        private class PartialSum
        {
            public int Carry { get; set; }

            public Node<int> Sum { get; set; }
        }
    }
}
