namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using System.Collections;
    using System.Linq;
    using Data_structures;

    /// <summary>
    /// Palindrome: Implement a function to check if a linked list is a palindrome.
    ///  </summary>
    public class Question_2_6
    {

        // Space: O(n)
        // Time: O(n)
        public static bool IsPalindrome<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var reverseHead = CloneAndReverse(head);
            while (head != null && reverseHead != null)
            {
                if (!head.Data.Equals(reverseHead.Data))
                {
                    return false;
                }

                head = head.Next;
                reverseHead = reverseHead.Next;
            }

            return true;
        }

        private static Node<T> CloneAndReverse<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                return null;
            }

            Node<T> newHead = new Node<T>(head.Data);
            var newCur = newHead;
            var cur = head.Next;
            while (cur != null)
            {
                newCur.Next = new Node<T>(cur.Data);
                newCur = newCur.Next;
                cur = cur.Next;
            }

            return Question_2_5.ReverseList(newHead);
        }
    }
}
