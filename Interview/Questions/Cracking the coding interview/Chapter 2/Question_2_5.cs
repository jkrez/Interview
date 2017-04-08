﻿namespace Questions.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Data_structures;

    /// <summary>
    /// Sum Lists: You have two numbers represented by a linked list, where
    /// each node contains a single digit. The digits are stored in reverse
    /// order, such that the 1 's digit is at the head of the list. Write a
    /// function that adds the two numbers and returns the sum as a linked
    /// list.
    /// EXAMPLE
    /// Input:
    ///     (7-> 1 -> 6) + (5 -> 9 -> 2). That is, 617 + 295.
    /// Output:
    ///    2 -> 1 -> 9. That is, 912.
    /// FOLLOW UP
    /// Suppose the digits are stored in forward order. Repeat the above problem.
    /// EXAMPLE
    /// Input:
    ///     (6 -> 1 -> 7) + (2 -> 9 -> 5).That is, 617 + 295.
    /// Output: 
    ///     9 -> 1 -> 2. That is, 912.
    /// </summary>
    public class Question_2_5
    {
        public static Node<Digit> SumLists(Node<Digit> l1, Node<Digit> l2)
        {
            if (l1 == null)
            {
                throw new ArgumentNullException(nameof(l1));
            }

            if (l2 == null)
            {
                throw new ArgumentNullException(nameof(l2));
            }

            Node<Digit> resultHead = null;
            Node<Digit> resultLast = null;
            bool carryOver = false;
            while (l1 != null || l2 != null || carryOver)
            {
                int nextDigit = l1?.Data + l2?.Data + (carryOver ? 1 : 0);
                carryOver = nextDigit > 9;
                nextDigit = nextDigit % 10;
                var newNode = new Node<Digit>(new Digit(nextDigit));

                if (resultHead == null)
                {
                    resultHead = newNode;
                    resultLast = newNode;
                }
                else
                {
                    resultLast.Next = newNode;
                    resultLast = resultLast.Next;
                }

                l1 = l1?.Next;
                l2 = l2?.Next;
            }

            return resultHead;
        }
    }
}
