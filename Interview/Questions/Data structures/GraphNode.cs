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
        public T Data;
        public GraphNode<T>[] Children;

        public GraphNode(T data)
            : this(data, null)
        {
        }

        public GraphNode(T data, IEnumerable<GraphNode<T>> children)
        {
            this.Data = data;
            this.Children = children?.ToArray() ?? new GraphNode<T>[0];
        }

        private string DebuggerString
            => string.Join("_", this.Children.Select(c => c?.Data.ToString() ?? "null"));
    }
}
