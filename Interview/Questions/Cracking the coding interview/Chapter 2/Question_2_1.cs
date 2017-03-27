namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using Questions.Data_structures;

    /// <summary>
    /// Remove Dups: Write code to remove duplicates from an unsorted linked list.
    /// FOLLOW UP
    /// How would you solve this problem if a temporary buffer is not allowed?
    /// </summary>
    public class Question_2_1
    {
        // Time: O(n)
        // Space: O(n)
        public static void RemoveDuplicates<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            HashSet<T> nodes = new HashSet<T>();
            nodes.Add(head.Data);
            while (head.Next != null)
            {
                if (!nodes.Contains(head.Next.Data))
                {
                    nodes.Add(head.Next.Data);
                    head = head.Next;
                }
                else
                {
                    head.Next = head.Next.Next;
                }
            }
        }

        // Time: O(n^2)
        // Space: O(1)
        public static void RemoveDuplicatesNoSpace2<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            while (head != null)
            {
                var prev = head;
                var next = head.Next;
                while (next != null)
                {
                    if (next.Data.Equals(prev.Data))
                    {
                        prev.Next = next.Next;
                        next = next.Next;
                    }
                    else
                    {
                        prev = next;
                        next = next.Next;
                    }
                }

                head = head.Next;
            }
        }

        // Time: O(n^2)
        // Space: O(1)
        public static void RemoveDuplicatesNoSpace<T>(Node<T> head)
              where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var inputHead = head;
            var prev = head;
            var next = head.Next;
            while (next != null)
            {
                var runner = inputHead;
                while (runner != next)
                {
                    if (runner.Data.Equals(next.Data))
                    {
                        break;
                    }

                    runner = runner.Next;
                }

                if (runner == next)
                {
                    prev = next;
                    next = next.Next;
                }
                else
                {
                    prev.Next = next.Next;
                    next = next.Next;
                }
            }
        }
    }
}