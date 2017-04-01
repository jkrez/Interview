namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Data_structures;

    /// <summary>
    /// Delete Middle Node: Implement an algorithm to delete a node in the middle
    /// (i.e., any node but the first and last node, not necessarily the exact middle)
    /// of a singly linked list, given only access to that node.
    /// 
    /// EXAMPLE
    /// Input: the node c from the linked list a -> b -> c -> d -> e -> f
    /// Result: nothing is returned, but the new linked list looks like a -> b -> d -> e -> f
    /// </summary>
    public class Question_2_3
    {
        public static void RemoveMiddleNode<T>(Node<T> node)
            where T : IEquatable<T>
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.Next == null)
            {
                throw new ArgumentException("node should be inner node in linked list");
            }

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }
    }
}
