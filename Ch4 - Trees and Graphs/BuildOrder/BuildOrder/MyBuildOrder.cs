using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildOrder
{
    public class MyBuildOrder : IBuildOrder
    {
        public string[] GetBuildOrder(string[] projects, string[][] dependencies)
        {
            Graph<string, GraphNode> graph = CreateProjectGraph(projects, dependencies);
            return GetBuildOrder(graph, projects);
        }

        private string[] GetBuildOrder(Graph<string, GraphNode> graph, string[] projects)
        {
            string[] builds = new string[projects.Length];
            int index = 0;
            foreach (string project in projects)
            {
                GraphNode node = graph.GetNode(project);
                if (AlreadyBuilt(node))
                    continue;

                if (CanBuild(node))
                {
                    int addIndex = AddAndManageBuilds(builds, node, index);
                    index = (addIndex == -1) ? index : addIndex + 1;
                }
            }

            if (IsError(builds, projects))
                throw new InvalidOperationException("Cannot build.");

            return builds;
        }

        private Graph<string, GraphNode> CreateProjectGraph(string[] projects, string[][] dependencies)
        {
            Graph<string, GraphNode> graph = new Graph<string, GraphNode>();

            foreach (string project in projects)
            {
                graph.AddNode(project);
            }

            foreach (string[] dependency in dependencies)
            {
                GraphNode parent = graph.GetNode(dependency[0]);
                GraphNode child = graph.GetNode(dependency[1]);
                parent.Adjacent.Add(child);
                child.Incoming++;
            }

            return graph;
        }

        private int AddAndManageBuilds(string[] builds, GraphNode node, int index)
        {
            if (AlreadyBuilt(node))
                return -1;

            builds[index] = node.Value;
            node.IsBuilt = true;

            foreach (GraphNode child in node.Adjacent)
            {
                child.Incoming--;

                if (CanBuild(child))
                {
                    index++;
                    int addIndex = AddAndManageBuilds(builds, child, index);
                    index = (addIndex == -1) ? index : addIndex;
                }
                    
            }

            return index;
        }

        private bool AlreadyBuilt(GraphNode node)
        {
            return node.IsBuilt;
        }

        private bool CanBuild(GraphNode node)
        {
            return (node.Incoming == 0);
        }

        private bool IsError(string[] builds, string[] projects)
        {
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            foreach (string project in projects)
            {
                dict.Add(project, true);
            }

            int count = 0;
            foreach (string build in builds)
            {
                if (dict.ContainsKey(build))
                    count++;
            }

            return (count != builds.Length);
        }
    }
}
