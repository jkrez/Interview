namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using System.Collections.Generic;
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
        public static Node<T> RemoveDuplicates<T>(Node<T> head)
            where T : IEquatable<T>
        {
            HashSet<T> nodes = new HashSet<T>();
            Node<T> noDuplicates = null;

            while (head != null)
            {
                if (!nodes.Contains(head.Data))
                {
                    nodes.Add(head.Data);
                    var toInsert = new Node<T>(head.Data);
                    // Case for first entry
                    if (noDuplicates == null)
                    {
                        noDuplicates = toInsert;
                    }
                    else
                    {
                        noDuplicates.Next = toInsert;
                        noDuplicates = toInsert;
                    }
                    head = head.Next;
                }
            }

            return noDuplicates;
        }
    }
}
