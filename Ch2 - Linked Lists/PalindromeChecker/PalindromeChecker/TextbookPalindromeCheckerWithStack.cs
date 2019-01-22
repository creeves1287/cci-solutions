using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class TextbookPalindromeCheckerWithStack : IPalindromeChecker
    {
        public bool IsPalindrome(Node<char> head)
        {
            Node<char> fast = head;
            Node<char> slow = head;

            Stack<int> stack = new Stack<int>();

            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Data);
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (fast != null)
            {
                slow = slow.Next;
            }

            while (slow != null)
            {
                int top = stack.Pop();

                if (top != slow.Data)
                {
                    return false;
                }

                slow = slow.Next;
            }

            return true;
        }
    }
}
