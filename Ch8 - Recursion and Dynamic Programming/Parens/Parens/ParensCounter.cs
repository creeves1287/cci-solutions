using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parens
{
    public class ParensCounter
    {
        public ParensCounter(int n)
        {
            Open = n;
            Closed = 0;
        }

        public int Open { get; set; }
        public int Closed { get; set; }
    }
}
