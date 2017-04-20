namespace Questions.Data_structures
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerDisplay("Data = {DebuggerString}")]
    public class GraphAdjacency<T>
        where T : IEquatable<T>
    {
        public GraphNode<T>[] Nodes;

        private string DebuggerString => string.Join("_", this.Nodes.Select(n => n?.Data.ToString()));
    }
}
