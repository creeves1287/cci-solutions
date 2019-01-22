using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfStacks
{
    public class TextbookSetOfStacks : ISetOfStacks<int>
    {
        List<Stack> _stacks = new List<Stack>();

        private int _capacity;

        public TextbookSetOfStacks(int capacity)
        {
            _capacity = capacity;
        }

        public Stack GetLastStack()
        {
            if (_stacks.Count == 0)
            {
                return null;
            }

            return _stacks[_stacks.Count - 1];
        }

        public void Push(int value)
        {
            Stack last = GetLastStack();

            if (last != null && !last.IsFull())
            {
                last.Push(value);
            }
            else
            {
                Stack stack = new Stack(_capacity);
                stack.Push(value);
                _stacks.Add(stack);
            }
        }

        public int Pop()
        {
            Stack last = GetLastStack();

            if (last == null)
                throw new InvalidOperationException("Stack empty.");

            int value = last.Pop();

            if (last.IsEmpty())
                _stacks.RemoveAt(_stacks.Count - 1);

            return value;
        }

        public bool IsEmpty()
        {
            Stack last = GetLastStack();
            return (last == null || last.IsEmpty());
        }

        public int PopAt(int index)
        {
            return LeftShift(index, true);
        }

        public int LeftShift(int index, bool removeTop)
        {
            Stack stack = _stacks[index];

            int value;

            if (removeTop)
            {
                value = stack.Pop();
            }
            else
            {
                value = stack.RemoveBottom();
            }

            if (stack.IsEmpty())
            {
                _stacks.RemoveAt(index);
            } else if (_stacks.Count > index + 1)
            {
                int val = LeftShift(index + 1, false);
                stack.Push(val);
            }

            return value;
        }

        public int Peek()
        {
            Stack last = GetLastStack();
            return last.Peek();
        }

        public class Stack
        {
            private int _capacity;
            private Node _top, _bottom;
            private int _size = 0;

            private class Node
            {
                public Node Above { get; set; }
                public Node Below { get; set; }
                public int Value { get; set; }

                public Node(int value)
                {
                    Value = value;
                }
            }

            public Stack(int capacity)
            {
                _capacity = capacity;
            }

            public bool IsFull()
            {
                return _capacity == _size;
            }

            private void Join(Node above, Node below)
            {
                if (below != null)
                    below.Above = above;

                if (above != null)
                    above.Below = below;
            }

            public bool Push(int value)
            {
                if (_size >= _capacity)
                    return false;

                _size++;

                Node n = new Node(value);

                if (_size == 1)
                    _bottom = n;

                Join(n, _top);

                _top = n;

                return true;
            }

            public int Pop()
            {
                Node t = _top;
                _top = _top.Below;
                _size--;
                return t.Value;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public int RemoveBottom()
            {
                Node b = _bottom;
                _bottom = _bottom.Above;

                if (_bottom != null)
                    _bottom.Below = null;

                _size--;

                return b.Value;
            }

            public int Peek()
            {
                return _top.Value;
            }
        }
    }
}
