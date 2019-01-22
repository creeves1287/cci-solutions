using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsInfrastructure
{
    public class Graph<TData, TNode>
        where TNode : GraphNode<TData>
    {
        private Dictionary<TData, TNode> _map = new Dictionary<TData, TNode>();

        public void AddNode(TData data)
        {
            TNode node = Activator.CreateInstance(typeof(TNode), new object[] { data }) as TNode;
            _map.Add(data, node);
            Nodes.Add(node);
        }

        public TNode GetNode(TData data)
        {
            if (_map.ContainsKey(data))
                return _map[data];

            return null;
        }

        public List<TNode> Nodes { get; } = new List<TNode>();

        public void AddEdge(TData outgoing, TData incoming)
        {
            if (!_map.ContainsKey(outgoing))
            {
                throw new InvalidOperationException("No key exists with the outgoing parameter");
            }

            if (!_map.ContainsKey(incoming))
            {
                throw new InvalidOperationException("No key exists with the incoming parameter");
            }

            _map[outgoing].Adjacent.Add(_map[incoming]);
        }
    }
}
