using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    public class TextbookMinStack : Stack<NodeWithMin>, IMinStack
    {
        public void Push(int data)
        {
            int newMin = Math.Min(data, Min());
            NodeWithMin node = new NodeWithMin(data, newMin);
            Push(node);
        }

        public new int Pop()
        {
            NodeWithMin node = base.Pop();
            return node.Data;
        }

        public int Min()
        {
            if (Count == 0)
            {
                return int.MaxValue;
            }
            return base.Peek().Min;
        }

        public new int Peek()
        {
            return base.Peek().Data;
        }

        public bool IsEmpty()
        {
            return (Count == 0);
        }
    }

    public class NodeWithMin
    {
        public int Data { get; set; }
        public int Min { get; set; }

        public NodeWithMin(int data, int min)
        {
            Data = data;
            Min = min;
        }
    }
}
