using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<T>
    {
        private class StackNode<TData>
        {
            public StackNode(TData data)
            {
                Data = data;
            }

            public TData Data { get; set; }

            public StackNode<TData> Next { get; set; }
        }

        private StackNode<T> Top { get; set; }

        public T Pop()
        {
            if (Top == null) throw new InvalidOperationException("Stack empty.");
            T item = Top.Data;
            Top = Top.Next;
            return item;
        }

        public void Push(T item)
        {
            StackNode<T> node = new StackNode<T>(item);
            node.Next = Top;
            Top = node;
        }

        public T Peek()
        {
            T item = Top.Data;
            return item;
        }

        public bool IsEmpty()
        {
            return (Top == null);
        }
    }
}
