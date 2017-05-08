namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Data_structures;

    /// <summary>
    /// Random Node: You are implementing a binary tree class from scratch which,
    /// in addition to insert, find, and delete, has a method getRandomNode()
    /// which returns a random node from the tree.All nodes should be equally
    /// likely to be chosen. Design and implement an algorithm for getRandomNode,
    /// and explain how you would implement the rest of the methods.
    /// </summary>
    public class Question_4_11
    {
        public static BinaryTreeNode<T> GetRandomNode<T>(BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                return null;
            }

            var rand = new Random();
            var nthNumber = rand.Next(0, root.NodeCount);
            return GetNthNode(root, nthNumber);
        }

        // Exposed for testing
        public static BinaryTreeNode<T> GetNthNode<T>(BinaryTreeNode<T> root, int n)
             where T : IEquatable<T>
        {
            if ((root.Left == null && n == 0) ||
                (root.Left?.NodeCount == n))
            {
                return root;
            }

            if (root.Left?.NodeCount > n)
            {
                return GetNthNode(root.Left, n);
            }

            var nodeCount = root.Left?.NodeCount ?? 0;
            return GetNthNode<T>(root.Right, n - (nodeCount + 1));
        }
    }
}
