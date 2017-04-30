namespace Questions.Data_structures
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerDisplay("Data = {DebuggerString}")]
    public class Graph<T>
        where T : IEquatable<T>
    {
        public Graph()
            : this((List<GraphNode<T>>)null)
        {
        }

        public Graph(List<GraphNode<T>> nodes)
        {
            this.Nodes = new Dictionary<T, GraphNode<T>>();
            foreach (var node in nodes)
            {
                this.Nodes.Add(node.Data, node);
            }
        }

        public Dictionary<T, GraphNode<T>> Nodes;

        private string DebuggerString => string.Join("_", this.Nodes.ToList().Select(n => n.Value.ToString()));
    }
}
