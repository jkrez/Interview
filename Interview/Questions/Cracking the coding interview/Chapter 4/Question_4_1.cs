namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using Data_structures;

    /// <summary>
    /// Route Between Nodes: Given a directed graph, design an algorithm
    /// to find out whether there is a route between two nodes.
    ///
    /// Solution:
    /// There are many ways to approach this problem. Depth first search,
    /// breadth first search, bi directional search. If there is a shortest
    /// path requirement then Dijkstra or A*
    /// </summary>
    public class Question_4_1
    {
        // Time: O(n)
        // Space: O(n)
        public static bool AreConnectedBFS<T>(GraphNode<T> node1, GraphNode<T> node2)
            where T : IEquatable<T>
        {
            if (node1 == null)
            {
                throw new ArgumentNullException(nameof(node1));
            }

            if (node2 == null)
            {
                throw new ArgumentNullException(nameof(node2));
            }

            var queue = new Queue<GraphNode<T>>();
            queue.Enqueue(node1);
            var visited = new HashSet<GraphNode<T>>();
            visited.Add(node1);

            while (queue.Count != 0)
            {
                var nextNode = queue.Dequeue();
                if (nextNode.Data.Equals(node2.Data))
                {
                    return true;
                }

                foreach (var child in nextNode.Children)
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }
    }
}
