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
    }
}
