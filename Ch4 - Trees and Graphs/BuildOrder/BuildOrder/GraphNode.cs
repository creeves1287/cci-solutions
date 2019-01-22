using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildOrder
{
    public class GraphNode : GraphsInfrastructure.GraphNode<string>
    {
        public int Incoming { get; set; }
        public bool IsBuilt { get; set; }

        public new List<GraphNode> Adjacent { get; } = new List<GraphNode>();

        public GraphNode(string data)
           : base(data) { }
    }
}
