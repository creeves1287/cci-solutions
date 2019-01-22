using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    public class TextbookMinDoubleStack : Stack<int>, IMinStack
    {
        private Stack<int> _minStack;

        public TextbookMinDoubleStack()
        {
            _minStack = new Stack<int>();
        }

        public new void Push(int value)
        {
            if(Min() >= value)
            {
                _minStack.Push(value);
            }
            base.Push(value);
        }

        public new int Pop()
        {
            int value = base.Pop();
            if (value == Min())
            {
                _minStack.Pop();
            }
            return value;
        }

        public int Min()
        {
            if (_minStack.Count == 0)
            {
                return int.MaxValue;
            }

            return _minStack.Peek();
        }

        public bool IsEmpty()
        {
            return (Count == 0);
        }
    }
}
