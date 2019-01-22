using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicatesRemover
{
    public class DuplicatesRemover
    {
        public void RemoveDuplicates(LinkedListNode<int> head)
        {
            Dictionary<int, LinkedListNode<int>> dict = new Dictionary<int, LinkedListNode<int>>();
            LinkedListNode<int> n = head;
            LinkedListNode<int> previous = null;

            while (n.Next != null)
            {
                if (dict.ContainsKey(n.Value))
                {
                    previous.Next = n.next;
                }
            }
        }
    }
}
