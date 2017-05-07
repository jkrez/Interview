namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Data_structures;

    public static class TreeHelpers
    {
        public static BinaryTreeNode<T> CreateBinaryTree<T>(T data)
            where T : IEquatable<T>
        {
            return new BinaryTreeNode<T>(data);
        }

        public static BinaryTreeNode<T> CreateBinaryTree<T>(T data, T left, T right)
            where T : IEquatable<T>
        {
            return CreateBinaryTree(data, new BinaryTreeNode<T>(left), new BinaryTreeNode<T>(right));
        }

        public static BinaryTreeNode<T> CreateBinaryTree<T>(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
            where T : IEquatable<T>
        {
            return new BinaryTreeNode<T>(data, left, right);
        }

        public static void AssertBinaryTreesEqual<T>(BinaryTreeNode<T> expected, BinaryTreeNode<T> result)
            where T : IEquatable<T>
        {
            if (expected == null && result == null)
            {
                return;
            }

            Assert.IsNotNull(expected);
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Data, result.Data);
            AssertBinaryTreesEqual<T>(expected.Left, result.Left);
            AssertBinaryTreesEqual<T>(expected.Right, result.Right);
        }

        public static BinaryTreeNode<T> CreateBinaryTreeFromArray<T>(params T[] nodes)
            where T : IComparable<T>, IEquatable<T>
        {
            if (nodes.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nodes));
            }

            var result = new BinaryTreeNode<T>(nodes[0]);
            for (int i = 1; i < nodes.Length; i++)
            {
                result.Insert(nodes[i]);
            }

            return result;
        }

        /// <summary>
        /// Does a simple insert operation following binary
        /// search tree rules. Does not re-balance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="node"></param>
        public static void Insert<T>(this BinaryTreeNode<T> root, T node)
            where T : IComparable<T>, IEquatable<T>
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            while (true)
            {
                if (node.CompareTo(root.Data) < 0)
                {
                    if (root.Left != null)
                    {
                        root = root.Left;
                    }
                    else
                    {
                        root.Left = new BinaryTreeNode<T>(node);
                        break;
                    }
                }
                else
                {
                    if (root.Right != null)
                    {
                        root = root.Right;
                    }
                    else
                    {
                        root.Right = new BinaryTreeNode<T>(node);
                        break;
                    }
                }
            }

            return;
        }
    }
}
