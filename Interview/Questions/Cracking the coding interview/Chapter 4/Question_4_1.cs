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
        // Assume single direction search from start -> end only.
        public static bool AreConnectedBFS<T>(GraphNode<T> start, GraphNode<T> end)
            where T : IEquatable<T>
        {
            if (start == null)
            {
                throw new ArgumentNullException(nameof(start));
            }

            if (end == null)
            {
                throw new ArgumentNullException(nameof(end));
            }

            var queue = new Queue<GraphNode<T>>();
            queue.Enqueue(start);
            var visited = new HashSet<T>();
            visited.Add(start.Data);

            while (queue.Count != 0)
            {
                var nextNode = queue.Dequeue();
                if (nextNode.Data.Equals(end.Data))
                {
                    return true;
                }

                foreach (var child in nextNode.Children)
                {
                    if (!visited.Contains(child.Data))
                    {
                        visited.Add(child.Data);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        // Time:
        // Space:
        // Assume connected means there is at least one directional path from node1 to node2.
        public static bool AreConnectedBiDirectionalBFS<T>(GraphNode<T> node1, GraphNode<T> node2)
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

            var queue1 = new Queue<Tuple<GraphNode<T>, int>>();
            queue1.Enqueue(new Tuple<GraphNode<T>, int>(node1, 0));
            var visited1 = new HashSet<T>();
            visited1.Add(node1.Data);
            var queue2 = new Queue<Tuple<GraphNode<T>, int>>();
            queue2.Enqueue(new Tuple<GraphNode<T>, int>(node2, 0));
            var visited2 = new HashSet<T>();
            visited2.Add(node2.Data);
            int level = 0;

            while (queue1.Count != 0 || queue2.Count != 0)
            {
                while (queue1.Count != 0 && queue1.Peek().Item2 == level)
                {
                    var nextNode = queue1.Dequeue();
                    if (nextNode.Item1.Data.Equals(node2.Data) ||
                        visited2.Contains(nextNode.Item1.Data))
                    {
                        return true;
                    }

                    foreach (var child in nextNode.Item1.Children)
                    {
                        if (!visited1.Contains(child.Data))
                        {
                            visited1.Add(child.Data);
                            queue1.Enqueue(new Tuple<GraphNode<T>, int>(child, level + 1));
                        }
                    }
                }

                while (queue2.Count != 0 && queue2.Peek().Item2 == level)
                {
                    var nextNode = queue2.Dequeue();
                    if (nextNode.Item1.Data.Equals(node1.Data) ||
                        visited1.Contains(nextNode.Item1.Data))
                    {
                        return true;
                    }

                    foreach (var child in nextNode.Item1.Children)
                    {
                        if (!visited2.Contains(child.Data))
                        {
                            visited2.Add(child.Data);
                            queue2.Enqueue(new Tuple<GraphNode<T>, int>(child, level + 1));
                        }
                    }
                }

                level++;
            }

            return false;
        }
    }
}
