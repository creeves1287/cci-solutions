using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNumbersOperator
{
    public class MyReverseListNumbersOperatorWithStack : IListNumbersOperator
    {
        public Node<int> AddNumbers(Node<int> first, Node<int> second)
        {
            int firstLength = Length(first);
            int secondLength = Length(second);

            Node<int> shortList = (firstLength > secondLength) ? second : first;
            Node<int> longList = (firstLength > secondLength) ? first : second;

            int difference = Math.Abs(firstLength - secondLength);

            shortList = PadList(shortList, difference);

            Node<int> sumList = CreateSumList(shortList, longList);

            return sumList;
        }

        private Node<int> CreateSumList(Node<int> first, Node<int> second)
        {
            Stack<PartialSum> sums = CreateSumStack(first, second);
            int carry = 0;
            Node<int> sumList = null;
            while (sums.Count > 0)
            {
                PartialSum sum = sums.Pop();
                int digit = sum.Sum + carry;
                int extra = 0;
                if (digit >= 10)
                {
                    extra = digit / 10;
                    digit %= 10;
                }
                Node<int> node = new Node<int>(digit);
                if (sumList == null)
                {
                    sumList = node;
                }
                else
                {
                    sumList = InsertBefore(sumList, node);
                }
                carry = sum.Carry + extra;
            }

            if (carry > 0)
            {
                Node<int> node = new Node<int>(carry);
                sumList = InsertBefore(sumList, node);
            }
            return sumList;
        }

        private Stack<PartialSum> CreateSumStack(Node<int> first, Node<int> second)
        {
            Stack<PartialSum> sums = new Stack<PartialSum>();

            while (first != null && second != null)
            {
                PartialSum sum = CalculatePartialSum(first.Data, second.Data);
                sums.Push(sum);
                first = first.Next;
                second = second.Next;
            }

            return sums;
        }

        private class PartialSum
        {
            public int Carry { get; set; }
            public int Sum { get; set; }
        }

        private PartialSum CalculatePartialSum(int first, int second)
        {
            PartialSum sum = new PartialSum();
            int wholeSum = first + second;
            sum.Sum = wholeSum % 10;
            sum.Carry = wholeSum / 10;
            return sum;
        }

        private Node<int> PadList(Node<int> list, int padding)
        {
            if (list == null) return null;
            for (int i = 0; i < padding; i++)
            {
                Node<int> zero = new Node<int>(0);
                list = InsertBefore(list, zero);
            }

            return list;
        }

        private Node<T> InsertBefore<T>(Node<T> list, Node<T> node)
        {
            if (node == null) throw new ArgumentException("Node cannot be null");
            node.Next = list;
            list = node;
            return list;
        }

        private int Length<T>(Node<T> node)
        {
            int length = 0;
            while (node != null)
            {
                length++;
                node = node.Next;
            }
            return length;
        }
    }
}
