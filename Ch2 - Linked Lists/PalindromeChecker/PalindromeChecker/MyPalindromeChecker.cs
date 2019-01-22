using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class MyPalindromeChecker : IPalindromeChecker
    {
        public bool IsPalindrome(Node<char> node)
        {
            Node<char> mirror = GetLastNode(node);
            int length = GetLengthOnlyLetters(node);

            if (length < 1) return false;

            for (int i = 0; i < length / 2; i++)
            {
                node = GetClosestLetter(node);
                mirror = GetClosestLetter(mirror);

                int val1 = GetCharacterValue(node.Data);
                int val2 = GetCharacterValue(mirror.Data);

                if (val1 != val2)
                {
                    return false;
                }

                node = node.Next;
                mirror = mirror.Previous;
            }

            return true;
        }

        private Node<T> GetLastNode<T>(Node<T> node)
        {
            if (node == null) return null;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        private int GetLengthOnlyLetters(Node<char> node)
        {
            int counter = 0;

            while (node != null)
            {
                int val = GetCharacterValue(node.Data);

                if (val != -1)
                {
                    counter++;
                }

                node = node.Next;
            }

            return counter;
        }

        private Node<char> GetClosestLetter(Node<char> node)
        {
            while (node != null)
            {
                int val = GetCharacterValue(node.Data);

                if (val != -1)
                {
                    return node;
                }

                node = node.Next;
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
    }
}
