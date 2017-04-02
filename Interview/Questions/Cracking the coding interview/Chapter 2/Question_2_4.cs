namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Data_structures;

    /// <summary>
    /// Partition: Write code to partition a linked list around a value x, such that all nodes less
    /// than x come before all nodes greater than or equal to x.lf x is contained within the list,
    /// the values of x only need to be after the elements less than x (see below). The partition
    /// element x can appear anywhere in the "right partition"; it does not need to appear between
    /// the left and right partitions.
    /// EXAMPLE
    /// Input:
    ///     3 -> 5 -> 8 -> 5 - > 10 -> 2 -> 1 [partition = 5]
    /// Output: 
    ///     3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
    /// </summary>
    public class Question_2_4
    {
        // Space: O(1)
        // Time: O(n)
        public static void PartitionList<T>(Node<T> head, T dataPartition)
            where T : IEquatable<T>, IComparable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var leftEnd = head;
            var consider = head.Next;
            while (consider != null)
            {
                if (IsLeftPartition(dataPartition, leftEnd.Data))
                {
                    if (IsLeftPartition(dataPartition, consider.Data))
                    {
                        // swap right start with consider (might be the same node in some cases)
                        swap(leftEnd.Next, consider);
                        leftEnd = leftEnd.Next;
                    }
                }
                else
                {
                    // No left end yet, swap nodes if a left partition is found.
                    if (IsLeftPartition(dataPartition, consider.Data))
                    {
                        swap(leftEnd, consider);
                    }
                }

                consider = consider.Next;
            }
        }

        private static void swap<T>(Node<T> node1, Node<T> node2)
            where T : IEquatable<T>
        {
            var temp = node1.Data;
            node1.Data = node2.Data;
            node2.Data = temp;
        }

        private static bool IsRightPartition<T>(T partition, T data)
            where T : IEquatable<T>, IComparable<T>
        {
            return data.CompareTo(partition) >= 0;
        }

        private static bool IsLeftPartition<T>(T partition, T data)
            where T : IEquatable<T>, IComparable<T>
        {
            return !IsRightPartition(partition, data);
        }
    }
}
