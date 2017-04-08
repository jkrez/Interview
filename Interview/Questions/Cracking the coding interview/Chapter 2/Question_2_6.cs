namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
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

        // Space: O(n)
        // Time: O(n)
        public static bool IsPalindromeRecursive<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var length = Question_2_2.GetListLength(head);
            Node<T> tempNode;
            return IsPalindromRecursiveHelper(head, length, 0, out tempNode);
        }

        private static bool IsPalindromRecursiveHelper<T>(Node<T> leftNode, int length, int count, out Node<T> rightNode)
            where T : IEquatable<T>
        {
            bool result = true;
            rightNode = null;
            if (count < length / 2)
            {
                result = IsPalindromRecursiveHelper<T>(leftNode.Next, length, ++count, out rightNode);
            }

            // True when the middle is reached.
            if (rightNode == null)
            {
                if (length % 2 == 0)
                {
                    rightNode = leftNode.Next;
                }
                else
                {
                    rightNode = leftNode;
                }
            }

            // Non middle comparison
            result &= rightNode.Data.Equals(leftNode.Data);
            rightNode = rightNode.Next;
            return result;
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
