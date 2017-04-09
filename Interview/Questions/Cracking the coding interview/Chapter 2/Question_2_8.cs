namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Data_structures;

    /// <summary>
    /// Loop Detection: Given a circular linked list, implement an algorithm
    /// that returns the node at the beginning of the loop.
    ///
    /// DEFINITION
    /// Circular linked list: A (corrupt) linked list in which a node's next
    /// pointer points to an earlier node, so as to make a loop in the linked
    /// list.
    ///
    /// EXAMPLE
    /// Input: A -> B -> C -> D -> E -> C (the same C as earlier)
    ///
    /// Output: C
    /// </summary>
    public class Question_2_8
    {
        // Floyd's algorithm
        // Space: O(1)
        // Time: O(n + m)
        public static Node<T> BeginningOfCycle<T>(Node<T> head)
             where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var runner = head;
            var runnerFast = head;
            do
            {
                if (runnerFast.Next == null || runnerFast.Next.Next == null)
                {
                    throw new ArgumentException(@"No cycle in list.");
                }

                runner = runner.Next;
                runnerFast = runnerFast.Next.Next;
            } while (runner != runnerFast);

            runner = head;
            while (runner != runnerFast)
            {
                runner = runner.Next;
                runnerFast = runnerFast.Next;
            }

            return runner;
        }
    }
}
