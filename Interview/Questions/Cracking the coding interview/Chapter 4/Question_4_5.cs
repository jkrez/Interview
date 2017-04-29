namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Data_structures;

    public class Question_4_5
    {
        public static bool IsBST(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // Note that if this was to be generic IsBST<T> would require a
            // class type that implemented IComparable and IEquatable and
            // the min and max values could be null until set.
            return IsBSTHelper(root, int.MinValue, int.MaxValue);
        }

        private static bool IsBSTHelper(BinaryTreeNode<int> root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            // This allows duplicates to be on either side of the tree.
            if (root.Data > max ||
                root.Data < min)
            {
                return false;
            }

            var leftTreeValid = IsBSTHelper(root.Left, min, root.Data);
            if (!leftTreeValid)
            {
                return false;
            }

            var rightValid = IsBSTHelper(root.Right, root.Data, max);
            return rightValid;
        }
    }
}
