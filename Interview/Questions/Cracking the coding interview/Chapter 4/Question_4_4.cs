namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Questions.Data_structures;

    public class Question_4_4
    {
        public static bool IsBalanced<T>(BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            int maxDepth;
            return IsBalancedHelper(root, /* height */ 0, out maxDepth);
        }

        private static bool IsBalancedHelper<T>(BinaryTreeNode<T> root, int height, out int maxDepth)
            where T : IEquatable<T>
        {
            maxDepth = height;
            if (root == null)
            {
                return true;
            }

            int leftDepth;
            var leftBalanced = IsBalancedHelper(root.Left, height + 1, out leftDepth);
            if (!leftBalanced)
            {
                return false;
            }

            int rightDepth;
            var rightBalanced = IsBalancedHelper(root.Right, height + 1, out rightDepth);
            if (!rightBalanced)
            {
                return false;
            }

            maxDepth = Math.Max(leftDepth, rightDepth);
            return Math.Abs(leftDepth - rightDepth) <= 1;
        }
    }
}
