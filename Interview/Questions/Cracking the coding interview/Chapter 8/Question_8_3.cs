namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System;

    /// <summary>
    /// Magic Index: A magic index in an array A [e ... n -1] is defined to be an index such that A[ i] =
    /// i.Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in
    /// array A.
    /// Note: Question answered for non distict values.
    /// </summary>
    public class Question_8_3
    {
        // Time: O(n)
        // Space: O(n)
        public static int GetMagicIndex(int[] array)
        {
            return GetMagicIndex(array, 0, array.Length - 1);
        }

        private static int GetMagicIndex(int[] array, int start, int end)
        {
            if (end < start || start < 0 || end < 0 || start >= array.Length || end >= array.Length)
            {
                return -1;
            }

            int midIndex = (start + end) / 2;
            int midVal = array[midIndex];
            if (midVal == midIndex)
            {
                return midIndex;
            }

            int leftIndex = Math.Min(midVal, midIndex - 1);
            int result = GetMagicIndex(array, start, leftIndex);
            if (result != -1)
            {
                return result;
            }

            int rightIndex = Math.Max(midVal, midIndex + 1);
            result = GetMagicIndex(array, rightIndex, end);
            return result;
        }
    }
}
