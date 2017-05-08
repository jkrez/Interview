namespace Questions.Data_structures
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("Data = {Data}, {debuggerString}")]
    public class BinaryTreeNode<T>
        where T : IEquatable<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

        /// <summary>
        /// Inclusive Node count.
        /// </summary>
        public int NodeCount { get; set; }

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
            : this(data)
        {
            this.Left = left;
            if (this.Left != null)
            {
                this.Left.Parent = this;
            }

            this.Right = right;
            if (this.Right != null)
            {
                this.Right.Parent = this;
            }
        }

        private string debuggerString =>
            "Left: " + this.Left?.Data.ToString() +
            " Right: " + this.Right?.Data.ToString() +
            " Parent: " + this.Parent?.Data.ToString();
    }
}
