using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthToLast
{
    public class MyKthToLastAnalyzer<T> : IKthToLastAnalyzer<T>
    {
        public Node<T> GetKthToLastNode(Node<T> head, int k)
        {
            Node<T> runner = head;
            Node<T> current = null;
            int counter = 1;

            while (runner != null)
            {
                if (counter >= k)
                {
                    if (current == null)
                    {
                        current = head;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }

                runner = runner.Next;
                counter++;
            }

            if (current == null)
            {
                throw new ArgumentException("k cannot be greater than the length of the list!");
            }

            return current;
        }
    }
}
