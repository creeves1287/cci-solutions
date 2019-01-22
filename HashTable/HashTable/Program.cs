using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(10);
            string key1 = "Hello";
            string key2 = "World";
            hashTable.Add(key1, 1);
            hashTable.Add(key2, 2);
            Console.WriteLine(hashTable.GetValue(key1));
            Console.WriteLine(hashTable.GetValue(key2));
        }
    }
}
