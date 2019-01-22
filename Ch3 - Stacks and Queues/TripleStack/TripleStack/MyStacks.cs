using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleStack
{
    public class MyStacks<T> : IStacks<T>
    {
        private int NumberOfStacks { get; set; }
        private int[] Counters { get; set; }
        private T[] Data { get; set; }

        private readonly int Test = 3;

        public MyStacks (int numberOfStacks)
        {
            NumberOfStacks = numberOfStacks;
            Counters = new int[numberOfStacks];
            Data = new T[numberOfStacks];
        }

        public void Push (T item, int stackIndex)
        {
            Counters[stackIndex]++;
            int dataIndex = GetDataIndex(stackIndex);
            if (dataIndex >= Data.Length)
            {
                IncreaseDataSize();
            }
            Data[dataIndex] = item;
        }

        public T Pop(int stackIndex)
        {
            int dataIndex = GetDataIndex(stackIndex);
            Counters[stackIndex]--;
            T data = Data[dataIndex];
            Data[dataIndex] = default(T);
            return data;
        }

        public T Peek(int stackIndex)
        {
            int dataIndex = GetDataIndex(stackIndex);
            if (dataIndex < 0)
            {
                throw new Exception("Stack is empty.");
            }
            return Data[dataIndex];
        }

        public bool IsEmpty(int stackIndex)
        {
            int counter = Counters[stackIndex];
            return (counter == 0);
        }

        private void IncreaseDataSize()
        {
            T[] newData = new T[Data.Length * 2];
            for (int i = 0; i < Data.Length; i++)
            {
                newData[i] = Data[i];
            }
            Data = newData;
        }

        private int GetDataIndex(int stackIndex)
        {
            int counter = Counters[stackIndex];
            int dataIndex = counter * NumberOfStacks - stackIndex - 1;
            return dataIndex;
        }
    }
}
