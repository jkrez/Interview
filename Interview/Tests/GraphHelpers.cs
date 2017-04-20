namespace Tests
{
    using System;
    using System.Linq;
    using Questions.Data_structures;

    public class GraphHelpers
    {
        public static GraphNode<T> CreateGraph<T>(T data, params T[] children)
            where T : IEquatable<T>
        {
            var childrenNodes = children.Select(c => new GraphNode<T>(c));
            return new GraphNode<T>(data, childrenNodes);
        }
        public static GraphNode<T> CreateGraph<T>(T data, params GraphNode<T>[] children)
            where T : IEquatable<T>
        {
            return new GraphNode<T>(data, children);
        }
    }
}
