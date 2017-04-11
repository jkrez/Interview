namespace Questions.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sort Stack: Write a program to sort a stack such that the smallest items
    /// are on the top. You can use an additional temporary stack, but you may
    /// not copy the elements into any other data structure (such as an array).
    /// The stack supports the following operations: push, pop, peek, and isEmpty.
    /// </summary>
    public class Question_3_5
    {
        // Space: O(n)
        // Time: O(n^2)
        public static void SortStack<T>(Stack<T> stack)
            where T : IComparable<T>
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            if (stack.Count == 0)
            {
                return;
            }

            var helperStack = new Stack<T>();

            // Move all of stack to helperStack
            while (stack.Count != 0)
            {
                helperStack.Push(stack.Pop());
            }

            stack.Push(helperStack.Pop());
            while (helperStack.Count != 0)
            {
                var next = helperStack.Pop();
                while (stack.Count != 0 &&
                       stack.Peek().CompareTo(next) < 0)
                {
                    helperStack.Push(stack.Pop());
                }

                stack.Push(next);
            }
        }
    }
}
