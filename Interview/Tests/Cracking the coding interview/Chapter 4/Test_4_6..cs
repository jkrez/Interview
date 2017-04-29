namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_6
    {
        // Time: O(h) where h is the max depth of the tree.
        // Space: O(1)
        [TestMethod]
        public void Question_4_6_BasicCases()
        {
            // Single Node tree tests.
            var tree = TreeHelpers.CreateBinaryTree(1, null, null);
            Validate(null, tree);

            // Small tree tests.
            tree = TreeHelpers.CreateBinaryTree(1, 0, 2);
            Validate(2, tree);
            Validate(1, tree.Left);
            Validate(null, tree.Right);

            // Large tree tests.
            tree = TreeHelpers.CreateBinaryTree(
                data: 4,
                left: TreeHelpers.CreateBinaryTree(
                    data: 2,
                    left: TreeHelpers.CreateBinaryTree(1, 0, -1),
                    right: new BinaryTreeNode<int>(3)),
                right: TreeHelpers.CreateBinaryTree(6, 5, 7));
            Validate(5, tree);
            Validate(3, tree.Left);
            Validate(-1, tree.Left.Left);
            Validate(4, tree.Left.Right);
            Validate(7, tree.Right);
            Validate(6, tree.Right.Left);
            Validate(null, tree.Right.Right);
        }

        [TestMethod]
        public void Question_4_6_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_6.FindSuccessor((BinaryTreeNode<int>)null), typeof(ArgumentNullException));
        }

        private static void Validate(int expected, BinaryTreeNode<int> node)
        {
            Validate(new BinaryTreeNode<int>(expected), node);
        }

        private static void Validate<T>(BinaryTreeNode<T> expected, BinaryTreeNode<T> node)
            where T : IEquatable<T>
        {
            var result = Question_4_6.FindSuccessor(node);
            if (expected == null)
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.AreEqual(expected.Data, result.Data);
            }
        }
    }
}
