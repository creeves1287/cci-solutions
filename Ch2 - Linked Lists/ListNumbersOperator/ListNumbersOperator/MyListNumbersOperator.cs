using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNumbersOperator
{
    public class MyListNumbersOperator : IListNumbersOperator
    {
        public Node<int> AddNumbers(Node<int> first, Node<int> second)
        {
            Node<int> head = first;
            Node<int> extra = second;

            while (second != null)
            {
                if (first == null) break;

                first.Data += second.Data;

                if (first.Next == null && second.Next != null)
                {
                    first.Next = second.Next;
                }

                if (first.Data >= 10)
                {
                    if (first.Next == null)
                    {
                        first.Next = extra;
                        first.Next.Data = 0;
                        first.Next.Next = null;
                    }

                    first.Next.Data++;
                    first.Data %= 10;
                }

                first = first.Next;
                second = second.Next;
            }

            if (first != null && first.Data >= 10)
            {
                first.Next = extra;
                first.Next.Data = 1;
                first.Next.Next = null;
                first.Data %= 10;
            }

            return head;
        }
    }
}
