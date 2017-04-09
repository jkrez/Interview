namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Data_structures;

    /// <summary>
    /// Intersection: Given two (singly) linked lists, determine if the two
    /// lists intersect. Return the intersecting node. Note that the intersection
    /// is defined based on reference, not value. That is, if the kth node of
    /// the first linked list is the exact same node (by reference) as the jth
    /// node of the second linked list, then they are intersecting. 
    /// </summary>
    public class Question_2_7
    {
        public static Node<T> FindIntersection<T>(Node<T> head1, Node<T> head2)
            where T : IEquatable<T>
        {
            if (head1 == null)
            {
                throw new ArgumentNullException(nameof(head1));
            }

            if (head2 == null)
            {
                throw new ArgumentNullException(nameof(head2));
            }

            var length1 = Question_2_2.GetListLength(head1);
            var length2 = Question_2_2.GetListLength(head2);

            var diff = Math.Abs(length1 - length2);
            var longerHead = length1 > length2 ? head1 : head2;
            var shorterHead = length1 <= length2 ? head1 : head2;

            for (int i = 0; i < diff; i++)
            {
                longerHead = longerHead.Next;
            }

            while (longerHead != null && shorterHead != null)
            {
                if (ReferenceEquals(longerHead, shorterHead))
                {
                    return longerHead;
                }

                longerHead = longerHead.Next;
                shorterHead = shorterHead.Next;
            }

            // Depending on the use case, should consider throwing and exception here.
            return null;
        }
    }
}
