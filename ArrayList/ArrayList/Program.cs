using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> list = new ArrayList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(7);
            list.Add(9);
            list.Add(7);
            PrintListElements(list);
        }

        private static void PrintListElements<T>(ArrayList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                T item = list.GetValue(i);
                Console.WriteLine(item);                
            }
            Console.Read();
        }
    }
}
