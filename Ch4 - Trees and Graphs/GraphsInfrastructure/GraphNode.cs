using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsInfrastructure
{
    public class GraphNode<T>
    {
        public List<GraphNode<T>> Adjacent { get; }
        public T Value { get; set; }

        public GraphNode(T value)
        {
            Value = value;
            Adjacent = new List<GraphNode<T>>();
        }
    }
}
