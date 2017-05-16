namespace Questions.Data_structures
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerDisplay("Data = {Data}, Children = {DebuggerString}")]
    public class GraphNode<T>
        where T : IEquatable<T>
    {
        public int DependencyCount;
        public T Data;
        public GraphNode<T>[] Children;

        // Added for 4.7
        public enum NodeState { NotBuilt, Building, BuildComplete }

        public NodeState State;

        public GraphNode(T data)
            : this(data, null)
        {
        }

        public GraphNode(T data, IEnumerable<GraphNode<T>> children)
        {
            this.Data = data;
            this.Children = children?.ToArray() ?? new GraphNode<T>[0];
            this.DependencyCount = this.Children.Length;
        }

        public void AddDependency(GraphNode<T> node)
        {
            var newChildren = this.Children.ToList();
            newChildren.Add(node);
            this.Children = newChildren.ToArray();
            this.DependencyCount++;
        }

        private string DebuggerString
            => string.Join("_", this.Children.Select(c => c?.Data.ToString() ?? "null"));
    }
}
