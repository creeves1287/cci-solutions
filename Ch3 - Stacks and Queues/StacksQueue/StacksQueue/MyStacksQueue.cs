using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksQueue
{
    public class MyStacksQueue<T> : IStacksQueue<T>
    {
        Stack<T> _add = new Stack<T>();
        Stack<T> _remove = new Stack<T>();

        public void Add(T item)
        {
            _add.Push(item);
        }

        public T Remove()
        {
            ValidateWhetherQueueIsEmpty();
            RebalanceStacksIfNeeded();
            T item = _remove.Pop();
            return item;
        }

        public T Peek()
        {
            ValidateWhetherQueueIsEmpty();
            RebalanceStacksIfNeeded();
            T item = _remove.Peek();
            return item;
        }

        public bool IsEmpty()
        {
            return (_add.Count == 0 && _remove.Count == 0);
        }

        private void RebalanceStacksIfNeeded()
        {
            if (_remove.Count == 0)
            {
                RebalanceStacks();
            }
        }

        private void RebalanceStacks()
        {
            while (_add.Count > 0)
            {
                T item = _add.Pop();
                _remove.Push(item);
            }
        }

        private void ValidateWhetherQueueIsEmpty()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
        }
    }
}
