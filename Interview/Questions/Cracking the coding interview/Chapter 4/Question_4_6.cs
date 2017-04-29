namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Data_structures;

    public class Question_4_6
    {
        // Time: O(h) where h is the max depth of the tree.
        // Space: O(1)
        public static BinaryTreeNode<T> FindSuccessor<T>(BinaryTreeNode<T> node)
            where T : IEquatable<T>
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // Right node or root.
            if (node.Right != null)
            {
                // Find leftmost right tree node.
                var leftMost = node.Right;
                while (leftMost.Left != null)
                {
                    leftMost = leftMost.Left;
                }

                return leftMost;
            }
            else
            {
                // Find first left parent going up.
                var current = node;
                while (current != null &&
                       current.Parent?.Left != current)
                {
                    current = current.Parent;
                }

                return current?.Parent;
            }
        }

    }
}
