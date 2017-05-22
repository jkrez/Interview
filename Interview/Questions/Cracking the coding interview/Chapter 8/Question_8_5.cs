namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;

    /// <summary>
    /// Recursive Multiply: Write a recursive function to multiply two positive integers without using the
    /// * operator. You can use addition, subtraction, and bit shifting, but you should minimize the number
    /// of those operations.
    /// </summary>
    public class Question_8_5
    {
        // Time: O(log(smaller))
        // Space: O (log(smaller))
        public static int RecursiveMultiply(int a, int b)
        {
            int bigger = a > b ? a : b;
            int smaller = a > b ? b : a;
            return RecursiveMultipleHelper(smaller, bigger);
        }

        private static int RecursiveMultipleHelper(int smaller, int bigger)
        {
            if (smaller == 0)
            {
                return 0;
            }

            if (smaller == 1)
            {
                return bigger;
            }

            var halfSmaller = smaller >> 1;
            int half = RecursiveMultipleHelper(halfSmaller, bigger);
            if (smaller % 2 == 0)
            {
                return half + half;
            }
            else
            {
                return half + half + bigger;
            }
        }
    }
}
