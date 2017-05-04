namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_8
    {
        [TestMethod]
        public void Question_4_8_BasicCases()
        {
            // Single Node tree tests.
            var tree = TreeHelpers.CreateBinaryTree(1, null, null);
            Validate(tree, tree, tree);

            // Small tree tests.
            tree = TreeHelpers.CreateBinaryTree(1, 0, 2);
            Validate(tree, tree, tree.Left);
            Validate(tree, tree, tree.Right);
            Validate(tree, tree.Left, tree.Right);
            Validate(tree, tree.Right, tree.Left);
            Validate(tree.Right, tree.Right, tree.Right);
            Validate(tree.Left, tree.Left, tree.Left);

            // Large tree tests.
            tree = TreeHelpers.CreateBinaryTree(
                data: 4,
                left: TreeHelpers.CreateBinaryTree(
                    data: 2,
                    left: TreeHelpers.CreateBinaryTree(1, 0, -1),
                    right: TreeHelpers.CreateBinaryTree(10, 11, 12)),
                right: TreeHelpers.CreateBinaryTree(6, 5, 7));
            Validate(tree, tree.Left.Left, tree.Right.Right);
            Validate(tree, tree.Left.Left.Left, tree.Right.Right);
            Validate(tree, tree.Left.Right, tree.Right.Left);
            Validate(tree.Left, tree.Left.Left.Left, tree.Left.Right.Right);

        }

        [TestMethod]
        public void Question_4_8_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_8.FindCommonAncestor(null, new BinaryTreeNode<int>(1)), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_4_8.FindCommonAncestor(new BinaryTreeNode<int>(1), null), typeof(ArgumentNullException));
        }

        private static void Validate<T>(BinaryTreeNode<T> expected, BinaryTreeNode<T> a, BinaryTreeNode<T> b)
            where T : IEquatable<T>
        {
            var result = Question_4_8.FindCommonAncestor(a, b);
            Assert.AreEqual(expected.Data, result.Data);
        }
    }
}
