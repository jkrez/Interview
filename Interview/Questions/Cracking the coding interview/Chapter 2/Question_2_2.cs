namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Data_structures;

    /// <summary>
    /// Return Kth to Last: Implement an algorithm to find the kth
    /// to last element of a singly linked list.
    /// </summary>
    public class Question_2_2
    {
        // Time: O(n)
        // Space: O(1)
        public static T ReturnKthToLast<T>(Node<T> head, int k)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            if (k < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k));
            }

            var count = 0;
            var runner = head;
            while (runner != null)
            {
                count++;
                runner = runner.Next;
            }

            if (k >= count)
            {
                throw new ArgumentOutOfRangeException("List is shorter than k");
            }

            runner = head;
            for (var i = 1; i < (count - k); i++)
            {
                runner = runner.Next;
            }

            return runner.Data;
        }
    }
}
