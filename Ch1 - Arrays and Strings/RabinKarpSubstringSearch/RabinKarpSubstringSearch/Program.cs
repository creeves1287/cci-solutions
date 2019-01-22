using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpSubstringSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullPhrase = "abcdefabcdefadeabckef";
            string subPhrase = "abc";
            StringSearcher searcher = new StringSearcher();
            int count = searcher.CountSubstringInstances(subPhrase, fullPhrase);
            Console.WriteLine("The total number of instances is: " + count);
            Console.Read();
        }
    }
}
