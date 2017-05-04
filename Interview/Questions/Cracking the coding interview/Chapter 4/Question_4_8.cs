namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Questions.Data_structures;
    using Questions.Extensions;

    /// <summary>
    /// First Common Ancestor: Design an algorithm and write code to find the first common ancestor
    /// of two nodes in a binary tree.Avoid storing additional nodes in a data structure.NOTE: This is not
    /// necessarily a binary search tree.
    /// </summary>
    public class Question_4_8
    {
        /// <summary>
        /// Time: O(h) where h is the hight of the tree
        /// Space: O(1)
        /// </summary>
        /// <returns>
        /// Returns null if no common ancestor exists. Otherwise returns the common ancestor.
        /// </returns>
        public static BinaryTreeNode<T> FindCommonAncestor<T>(BinaryTreeNode<T> a, BinaryTreeNode<T> b)
            where T : IEquatable<T>
        {

            // If the tree has parent pointers level the nodes, then
            // walk up the tree until the common ancestor is found.
            a.ValidateArgument(nameof(a));
            b.ValidateArgument(nameof(b));

            var depthA = FindDepth(a);
            var depthB = FindDepth(b);
            var lowNode = depthA > depthB ? a : b;
            var highNode = depthA <= depthB ? a : b;
            var diffInDepth = Math.Abs(depthA - depthB);
            while (diffInDepth > 0)
            {
                lowNode = lowNode.Parent;
                if (lowNode == null)
                {
                    return null;
                }

                diffInDepth--;
            }

            while (highNode != lowNode)
            {
                highNode = highNode.Parent;
                lowNode = lowNode.Parent;
                if (highNode == null || lowNode == null)
                {
                    return null;
                }
            }

            return new BinaryTreeNode<T>(lowNode.Data);
        }

        private static int FindDepth<T>(BinaryTreeNode<T> node)
            where T : IEquatable<T>
        {
            node.ValidateArgument(nameof(node));
            var depth = 0;
            while (node.Parent != null)
            {
                node = node.Parent;
                depth++;
            }

            return depth;
        }
    }
}
