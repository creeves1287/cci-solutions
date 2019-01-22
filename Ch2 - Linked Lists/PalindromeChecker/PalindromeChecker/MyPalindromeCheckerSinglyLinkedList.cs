using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class MyPalindromeCheckerSinglyLinkedList : IPalindromeChecker
    {
        public bool IsPalindrome(Node<char> node)
        {
            LinkedListEnds<char> reverse = ReverseList(node);
            Node<char> reverseNode = reverse.Head;

            while (node != null)
            {
                node = GetNextLetterNode(node);
                reverseNode = GetNextLetterNode(reverseNode);

                int val1 = GetCharacterValue(node.Data);
                int val2 = GetCharacterValue(reverseNode.Data);

                if (val1 != val2)
                {
                    return false;
                }

                node = node.Next;
                reverseNode = reverseNode.Next;
            }

            return true;
        }

        private LinkedListEnds<T> ReverseList<T>(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            Node<T> reverse = CopyNode(node);

            if (node.Next == null)
            {
                LinkedListEnds<T> ends = new LinkedListEnds<T>();
                ends.Head = CopyNode(node);
                return ends;
            }

            LinkedListEnds<T> listEnds = ReverseList(node.Next);

            if (listEnds.Tail == null)
            {
                listEnds.Head.Next = reverse;
                listEnds.Tail = reverse;
            }
            else
            {
                listEnds.Tail.Next = reverse; ;
                listEnds.Tail = reverse;
            }

            return listEnds;
        } 

        private Node<char> GetNextLetterNode(Node<char> node)
        {
            if (node == null)
            {
                return null;
            }

            int val = GetCharacterValue(node.Data);

            if (val == -1)
            {
                return GetNextLetterNode(node.Next);
            }

            return node;
        }

        private int GetCharacterValue(char c)
        {
            char lowerC = char.ToLower(c);

            if (lowerC >= 'a' && lowerC <= 'z')
            {
                return lowerC;
            }

            return -1;
        }

        private Node<T> CopyNode<T>(Node<T> node)
        {
            Node<T> copy = new Node<T>();
            copy.Data = node.Data;
            return copy;
        }

        private class LinkedListEnds<T>
        {
            public Node<T> Head { get; set; }
            public Node<T> Tail { get; set; }
        }
    }
}
