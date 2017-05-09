namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data_structures;

    /// <summary>
    /// Build Order: You are given a list of projects and a list of dependencies (which is a list of pairs of
    /// projects, where the second project is dependent on the first project). All of a project's dependencies
    /// must be built before the project is. Find a build order that will allow the projects to be built. If there
    /// is no valid build order, return an error.
    ///
    /// EXAMPLE
    /// Input:
    ///     projects: a, b, c, d, e, f
    ///     dependencies: (a, d), (f, b), (b, d), (f, a), (d, c)
    /// Output: f, e, a, b, d, c
    /// </summary>
    public class Question_4_7
    {
        // Time: O(p + d), p is # of projects, d # of dependencies
        // Space: O(p + d), p is # of projects, d # of dependencies
        public static List<string> FindBuildOrder(List<string> projects, Dictionary<string, string> dependencies)
        {
            ValidateInput(projects, dependencies);
            var graph = BuildGraph(projects, dependencies);
            return FindProjectOrder(graph);
        }

        public static List<string> FindBuildOrderDFS(List<string> projects, Dictionary<string, string> dependencies)
        {
            ValidateInput(projects, dependencies);
            var graph = BuildGraph(projects, dependencies);
            return FindProjectOrderDFS(graph);
        }

        private static void ValidateInput(List<string> projects, Dictionary<string, string> dependencies)
        {
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }

            if (dependencies == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var dependency in dependencies)
            {
                if (!projects.Contains(dependency.Key) ||
                    !projects.Contains(dependency.Value))
                {
                    throw new ArgumentOutOfRangeException(nameof(dependencies));
                }
            }
        }

        private static Graph<string> BuildGraph(List<string> projects, Dictionary<string, string> dependencies)
        {
            var graphNodes = new List<GraphNode<string>>();
            foreach (var project in projects)
            {
                graphNodes.Add(new GraphNode<string>(project));
            }

            var graph = new Graph<string>(graphNodes);

            // Add dependencies.
            foreach (var dependency in dependencies)
            {
                graph.Nodes[dependency.Value].AddDependency(graph.Nodes[dependency.Key]);
            }

            return graph;
        }

        private static List<string> FindProjectOrder(Graph<string> graph)
        {
            var projectOrder = new List<string>();
            var nextAddIndex = 0;
            var totalProjects = graph.Nodes.Count;
            while (projectOrder.Count != totalProjects)
            {
                foreach (var node in graph.Nodes)
                {
                    if (node.Value.DependencyCount == 0)
                    {
                        projectOrder.Add(node.Key);
                    }
                }

                if (projectOrder.Count == nextAddIndex)
                {
                    // No valid project order (cycle) because no projects added.
                    return null;
                }

                for (int i = nextAddIndex; i < projectOrder.Count; i++)
                {
                    foreach (var node in graph.Nodes)
                    {
                        if (node.Value.Children.ToList().Contains(graph.Nodes[projectOrder[i]]))
                        {
                            node.Value.DependencyCount--;
                        }
                    }

                    graph.Nodes.Remove(projectOrder[i]);
                }

                nextAddIndex = projectOrder.Count;
            }

            return projectOrder;
        }

        private static List<string> FindProjectOrderDFS(Graph<string> graph)
        {
            var order = new List<string>();
            foreach (var node in graph.Nodes)
            {
                if (node.Value.State == GraphNode<string>.NodeState.NotBuilt)
                {
                    if (!AddDfsOrder(node.Value, order))
                    {
                        return null;
                    }
                }
            }

            return order;
        }

        private static bool AddDfsOrder(GraphNode<string> node, List<string> projectOrder)
        {
            if (node.State == GraphNode<string>.NodeState.Building)
            {
                return false;
            }

            if (node.State == GraphNode<string>.NodeState.NotBuilt)
            {
                node.State = GraphNode<string>.NodeState.Building;
                foreach (var child in node.Children)
                {
                    if (!AddDfsOrder(child, projectOrder))
                    {
                        return false;
                    }
                }

                node.State = GraphNode<string>.NodeState.BuildComplete;
                projectOrder.Add(node.Data);
            }

            return true;
        }
    }
}
