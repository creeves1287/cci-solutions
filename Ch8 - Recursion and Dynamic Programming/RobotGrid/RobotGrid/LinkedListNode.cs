using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGrid
{
    public class LinkedListNode
    {
        public LinkedListNode(Cell data)
        {
            Value = data;
        }
        public Cell Value { get; }
        public LinkedListNode Next { get; set; }
    }
}
