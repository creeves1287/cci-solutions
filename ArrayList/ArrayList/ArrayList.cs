using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList<T>
    {
        private T[] _collection;
        private int _index = 0;

        public ArrayList()
        {
            _collection = new T[2];
        }

        public void Add(T item)
        {
            if(_index >= _collection.Length)
            {
                _collection = CreateLargerCollection();
            }
            _collection[_index] = item;
            _index++;
        }

        public T GetValue(int index)
        {
            return _collection[index];
        }

        public int Count
        {
            get
            {
                return _index;
            }
        }

        private T[] CreateLargerCollection()
        {
            T[] newCollection;
            int currentSize = _collection.Length;
            int newSize = currentSize * 2;
            newCollection = new T[newSize];
            PopulateCollection(newCollection);
            return newCollection;
        }

        private void PopulateCollection(T[] collection)
        {
            for(int i = 0; i < _collection.Length; i++)
            {
                collection[i] = _collection[i];
            }
        }
    }
}
