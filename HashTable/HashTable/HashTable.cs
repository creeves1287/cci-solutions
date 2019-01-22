using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable<TKey, TValue>
    {
        private int _size;
        private List<KeyValuePair<TKey, TValue>>[] _pairCollections;

        public HashTable(int size)
        {
            _size = size;
            _pairCollections = new List<KeyValuePair<TKey, TValue>>[size];
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);
            if(_pairCollections[index] == null)
            {
                _pairCollections[index] = new List<KeyValuePair<TKey, TValue>>();
            }
            _pairCollections[index].Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue GetValue(TKey key)
        {
            int index = GetIndex(key);
            List<KeyValuePair<TKey, TValue>> pairCollection = _pairCollections[index];
            if(pairCollection == null)
            {
                throw new ArgumentNullException("pairCollection");
            }
            if(pairCollection.Count == 0)
            {
                throw new ArgumentException("The key provided does not map to any value.");
            }
            if(pairCollection.Count > 1)
            {
                return FindValue(pairCollection, key);
            }
            return pairCollection[0].Value;
        }

        private TValue FindValue(List<KeyValuePair<TKey, TValue>> pairCollection, TKey key)
        {
            for(int i = 0; i < pairCollection.Count; i++)
            {
                KeyValuePair<TKey, TValue> pair = pairCollection[i];
                TKey pairKey = pair.Key;
                if (KeysAreEqual(key, pairKey))
                {
                    return pair.Value;
                }
            }
            throw new ArgumentException("The key provided did not return any values from the pairCollection.");
        }

        private int GetIndex(TKey key)
        {
            int hash = GetHash(key);
            int index = GetIndexFromHash(hash);
            return index;
        }

        private int GetIndexFromHash(int hash)
        {
            int index = Math.Abs(hash) % _size;
            return index;
        }

        private bool KeysAreEqual(TKey key1, TKey key2)
        {
            return (key1.Equals(key2) || key1.ToString() == key2.ToString());
        }

        private int GetHash(TKey key)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = ConvertToBytes(key);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                int hash = BitConverter.ToInt32(hashBytes, 0);
                return hash;
            }
        }

        private byte[] ConvertToBytes(TKey key)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using(MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, key);
                return ms.ToArray();
            }
        }

    }
}
