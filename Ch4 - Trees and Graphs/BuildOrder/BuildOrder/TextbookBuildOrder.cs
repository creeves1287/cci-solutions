using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildOrder
{
    public class TextbookBuildOrder : IBuildOrder
    {
        public string[] GetBuildOrder(string[] projects, string[][] dependencies)
        {
            Graph<string, GraphNode> graph = BuildGraph(projects, dependencies);
            GraphNode[] build = GetBuildOrder(graph.Nodes);
            string[] names = build.Select(p => p.Value).ToArray();
            return names;
        }

        private Graph<string, GraphNode> BuildGraph(string[] projects, string[][] dependencies)
        {
            Graph<string, GraphNode> graph = new Graph<string, GraphNode>();
            foreach (string project in projects)
            {
                graph.AddNode(project);
            }
            foreach (string[] dependency in dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.AddEdge(first, second);
            }
            return graph;
        }

        private GraphNode[] GetBuildOrder(List<GraphNode> projects)
        {
            GraphNode[] order = new GraphNode[projects.Count];

            /*Add roots to the build order first */
            int endOfList = AddNonDependent(order, projects, 0);
            int toBeProcessed = 0;

            while (toBeProcessed < order.Length)
            {
                GraphNode current = order[toBeProcessed];

                /* We have a circular dependency since there are no remaining projects with zero dependencies */
                if (current == null)
                    return null;

                /* Remove myself as a dependency */
                List<GraphNode> children = current.Adjacent;

                foreach (GraphNode child in children)
                {
                    child.Incoming--;
                }

                /* Add children that have no one depending on them */
                endOfList = AddNonDependent(order, children, endOfList);

                toBeProcessed++;
            }

            return order;
        }

        /* A helper function to insert projects with zero dependencies into the order array, starting at index offset */
        private int AddNonDependent(GraphNode[] order, List<GraphNode> projects, int offset)
        {
            foreach (GraphNode project in projects)
            {
                if (project.Incoming == 0)
                {
                    order[offset] = project;
                    offset++;
                }
            }

            return offset;
        }
    }
}
