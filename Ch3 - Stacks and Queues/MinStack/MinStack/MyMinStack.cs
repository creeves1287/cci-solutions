using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    public class MyMinStack : IMinStack
    {
        private class StackNode
        {
            public int Data { get; set; }
            public int Min { get; set; }
            public StackNode Next { get; set; }
            
            public StackNode(int data)
            {
                Data = data;
            }
        }

        private StackNode _top;

        private StackNode Top
        {
            get
            {
                if (_top == null)
                {
                    throw new InvalidOperationException("Stack empty.");
                }
                return _top;
            }
            set
            {
                _top = value;
            }
        }

        public void Push(int data)
        {
            StackNode node = new StackNode(data);
            if (IsEmpty())
            {
                node.Min = data;
            }
            else
            {
                node.Min = (Top.Min > node.Data) ? node.Data : Top.Min;
                node.Next = Top;
            }
            Top = node;
        }

        public int Pop()
        {
            int data = Top.Data;
            Top = Top.Next;
            return data;
        }

        public int Min()
        {
            return Top.Min;
        }

        public int Peek()
        {
            return Top.Data;
        }

        public bool IsEmpty()
        {
            return (_top == null);
        }
    }
}
