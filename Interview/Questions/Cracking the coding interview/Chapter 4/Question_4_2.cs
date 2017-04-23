namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Data_structures;

    /// <summary>
    /// Minimal Tree: Given a sorted (increasing order) array with unique integer
    /// elements, write an algorithm to create a binary search tree with minimal
    /// height.
    ///
    /// Assume no duplicates.
    /// </summary>
    public class Question_4_2
    {
        public static BinaryTreeNode<int> CreateMinimalBinaryTree(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input));
            }

            return CreateMinimalBinaryTreeHelper(input, 0, input.Length);
        }

        private static BinaryTreeNode<int> CreateMinimalBinaryTreeHelper(int[] input, int lower, int upper)
        {
            if (lower >= upper)
            {
                return null;
            }

            var numElements = upper - lower;
            var middle = lower + (numElements / 2);
            var root = new BinaryTreeNode<int>(input[middle]);
            root.Left = CreateMinimalBinaryTreeHelper(input, lower, middle);
            root.Right = CreateMinimalBinaryTreeHelper(input, middle + 1, upper);
            return root;
        }
    }
}
