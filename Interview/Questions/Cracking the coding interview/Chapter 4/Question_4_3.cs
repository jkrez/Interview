namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using Data_structures;

    public class Question_4_3
    {
        // Time: O(n)
        // Space: O(n)
        public static List<List<BinaryTreeNode<T>>> CreateDepthList<T>(BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return CreateDepthListHelper(root, 0, new List<List<BinaryTreeNode<T>>>());
        }

        private static List<List<BinaryTreeNode<T>>> CreateDepthListHelper<T>(
            BinaryTreeNode<T> root,
            int depth,
            List<List<BinaryTreeNode<T>>> lists)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                return lists;
            }

            while (lists.Count <= depth)
            {
                lists.Add(new List<BinaryTreeNode<T>>());
            }

            lists[depth].Add(root);
            CreateDepthListHelper(root.Left, depth + 1, lists);
            CreateDepthListHelper(root.Right, depth + 1, lists);
            return lists;
        }

        // Time: O(n)
        // Space: O(n)
        public static List<List<BinaryTreeNode<T>>> CreateDepthListIterative<T>(BinaryTreeNode<T> root)
           where T : IEquatable<T>
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var result = new List<List<BinaryTreeNode<T>>>();
            result.Add(new List<BinaryTreeNode<T>>());
            result[0].Add(root);
            var depth = 0;
            while (result[depth].Count != 0)
            {
                result.Add(new List<BinaryTreeNode<T>>());
                foreach (var node in result[depth])
                {
                    if (node.Left != null)
                    {
                        result[depth + 1].Add(node.Left);
                    }

                    if (node.Right != null)
                    {
                        result[depth + 1].Add(node.Right);
                    }
                }

                depth++;
            }

            result.RemoveAt(depth);
            return result;
        }
    }
}
