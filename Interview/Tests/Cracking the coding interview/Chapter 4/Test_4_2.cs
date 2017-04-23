namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_2
    {
        [TestMethod]
        public void Question_4_2_BasicCases()
        {
            // Single node tree test.
            var binaryTree = TreeHelpers.CreateBinaryTree(data: 0);
            this.Validate<int>(1, binaryTree);

            // Two node tree
            // Both trees valid:    1      0
            //                     /   or   \
            //                    0          1
            // This test is specific to the implementation.

            binaryTree = TreeHelpers.CreateBinaryTree(
                data: 1,
                left: new BinaryTreeNode<int>(0),
                right: null);

            this.Validate<int>(2, binaryTree);

            // Thee node tree
            binaryTree = TreeHelpers.CreateBinaryTree(data: 1, left: 0, right: 2);
            this.Validate<int>(3, binaryTree);

            // Four node tree
            binaryTree = TreeHelpers.CreateBinaryTree(
                data: 2,
                left: TreeHelpers.CreateBinaryTree(
                    data: 1,
                    left: new BinaryTreeNode<int>(0),
                    right: null),
                right: new BinaryTreeNode<int>(3));

            this.Validate<int>(4, binaryTree);

            // Five node tree
            binaryTree = TreeHelpers.CreateBinaryTree(
                data: 2,
                left: TreeHelpers.CreateBinaryTree(
                    data: 1,
                    left: new BinaryTreeNode<int>(0),
                    right: null),
                right: TreeHelpers.CreateBinaryTree(
                    data: 4,
                    left: new BinaryTreeNode<int>(3),
                    right: null));

            this.Validate<int>(5, binaryTree);

            // Six node tree
            binaryTree = TreeHelpers.CreateBinaryTree(
                data: 3,
                left: TreeHelpers.CreateBinaryTree(
                    data: 1,
                    left: 0,
                    right: 2),
                right: TreeHelpers.CreateBinaryTree(
                    data: 5,
                    left: new BinaryTreeNode<int>(4),
                    right: null));

            this.Validate<int>(6, binaryTree);

            // Seven node tree
            binaryTree = TreeHelpers.CreateBinaryTree(
                data: 3,
                left: TreeHelpers.CreateBinaryTree(
                    data: 1,
                    left: 0,
                    right: 2),
                right: TreeHelpers.CreateBinaryTree(
                    data: 5,
                    left: 4,
                    right: 6));

            this.Validate<int>(7, binaryTree);

            // Eight node tree
            binaryTree = TreeHelpers.CreateBinaryTree(
                data: 4,
                left: TreeHelpers.CreateBinaryTree(
                    data: 2,
                    left: TreeHelpers.CreateBinaryTree(
                        data: 1,
                        left: new BinaryTreeNode<int>(0),
                        right: null),
                    right: new BinaryTreeNode<int>(3)),
                right: TreeHelpers.CreateBinaryTree(6, 5, 7));

            this.Validate<int>(8, binaryTree);
        }

        [TestMethod]
        public void Question_4_2_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_2.CreateMinimalBinaryTree(null), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_4_2.CreateMinimalBinaryTree(new int[0]), typeof(ArgumentOutOfRangeException));
        }

        private void Validate<T>(int size, BinaryTreeNode<int> expected)
            where T : IEquatable<T>
        {
            var result = Question_4_2.CreateMinimalBinaryTree(Enumerable.Range(0, size).ToArray());
            TreeHelpers.AssertBinaryTreesEqual<int>(expected, result);
        }
    }
}
