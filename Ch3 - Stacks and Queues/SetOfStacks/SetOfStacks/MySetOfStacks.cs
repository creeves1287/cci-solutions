using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfStacks
{
    public class MySetOfStacks<T> : ISetOfStacks<T>
    {
        private List<Stack<T>> _stacks = new List<Stack<T>>();

        private int _capacity;

        private int _counter = 0;

        private int _stackIndex = -1;

        public MySetOfStacks(int capacity)
        {
            _capacity = capacity;
        }

        private int Capacity
        {
            get
            {
                if (_capacity <= 0)
                    throw new Exception("Capacity must be greater than 0.");

                return _capacity;
            }
        }

        private int AdjustedCounter
        {
            get
            {
                return _counter % Capacity;
            }
        }

        public void Push(T item)
        {
            if (AdjustedCounter == 0)
            {
                _stacks.Add(new Stack<T>(Capacity));
                _stackIndex++;
            }

            _stacks[_stackIndex].Push(item);
            _counter++;
        }

        public T Pop()
        {
            if (_counter == 0)
            {
                throw new InvalidOperationException("Stack empty.");
            }

            T item = _stacks[_stackIndex].Pop();
            _counter--;

            if (AdjustedCounter == 0)
            {
                _stacks.RemoveAt(_stackIndex);
                _stackIndex--;
            }

            return item;
        }

        public T Peek()
        {
            return _stacks[_stackIndex].Peek();
        }

    }
}
