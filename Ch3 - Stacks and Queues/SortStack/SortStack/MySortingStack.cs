using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStack
{
    public class MySortingStack : ISortingStack
    {
        private Stack<int> _stack = new Stack<int>();

        public void Push(int value)
        {
            Stack<int> temp = new Stack<int>();

            while (_stack.Count > 0 && value > _stack.Peek())
            {
                temp.Push(_stack.Pop());
            }

            _stack.Push(value);

            while (temp.Count > 0)
            {
                _stack.Push(temp.Pop());
            }
        }

        public int Pop()
        {
            ValidateStackNotEmpty();
            return _stack.Pop();
        }

        public int Peek()
        {
            ValidateStackNotEmpty();
            return _stack.Peek();
        }

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        private void ValidateStackNotEmpty()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack empty.");
            }
        }
    }
}
