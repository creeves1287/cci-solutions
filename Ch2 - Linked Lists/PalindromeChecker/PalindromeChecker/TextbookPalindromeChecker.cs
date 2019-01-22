using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class TextbookPalindromeChecker : IPalindromeChecker
    {
        public bool IsPalindrome(Node<char> head)
        {
            Node<char> reversed = ReverseAndClone(head);
            return IsEqual(head, reversed);
        }

        public Node<T> ReverseAndClone<T>(Node<T> node)
        {
            Node<T> head = null;

            while (node != null)
            {
                Node<T> n = new Node<T>(node.Data);
                n.Next = head;
                head = n;
                node = node.Next;
            }

            return head;
        }

        public bool IsEqual(Node<char> one, Node<char> two)
        {
            while (one != null && two != null)
            {
                if (one.Data != two.Data)
                {
                    return false;
                }

                one = one.Next;
                two = two.Next;
            }

            return (one == null) && (two == null);
        }
    }
}
