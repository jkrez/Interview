namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Data_structures;

    /// <summary>
    /// Check Subtree: Tl and T2 are two very large binary trees, with Tl much bigger
    /// than T2. Create an algorithm to determine if T2 is a subtree of Tl. A tree
    /// T2 is a subtree ofTi if there exists a node n in Ti such that the subtree of
    /// n is identical to T2. That is, if you cut off the tree at node n, the two trees
    /// would be identical.
    /// </summary>
    public class Question_4_10
    {

        // Time: O(N * M)
        // Space: O(1)
        public static bool ContainsSubtree<T>(BinaryTreeNode<T> t1, BinaryTreeNode<T> t2)
            where T : IEquatable<T>
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }

            if (t1 == null)
            {
                return false;
            }

            if (IsSubtree(t1, t2))
            {
                return true;
            }

            if (ContainsSubtree<T>(t1.Left, t2))
            {
                return true;
            }

            return ContainsSubtree<T>(t1.Right, t2);
        }

        private static bool IsSubtree<T>(BinaryTreeNode<T> node, BinaryTreeNode<T> t2)
            where T : IEquatable<T>
        {
            if (node == null)
            {
                return t2 == null; // Nothing left to match
            }

            if (t2 == null)
            {
                return false;
            }

            if (!t2.Data.Equals(node.Data))
            {
                return false;
            }

            if (!IsSubtree<T>(node.Left, t2.Left))
            {
                return false;
            }

            return IsSubtree<T>(node.Right, t2.Right);
        }
    }
}
