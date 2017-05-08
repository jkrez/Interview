namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;
    using Questions.LeetCode;

    [TestClass]
    public class Test_4_10
    {
        [TestMethod]
        public void Question_4_10_BasicCases()
        {
            // Null tree
            var t1 = (BinaryTreeNode<int>) null;
            var t2 = t1;
            Validate(t1, t2, expected: true);
            t2 = new BinaryTreeNode<int>(1);
            Validate(t1, t2, expected: false);

            // Single Node tree tests.
            t1 = TreeHelpers.CreateBinaryTree(1, null, null);
            t2 = (BinaryTreeNode<int>) null;
            Validate(t1, t2, expected: true);
            t2 = new BinaryTreeNode<int>(1);
            Validate(t1, t2, expected: true);
            t2 = new BinaryTreeNode<int>(2);
            Validate(t1, t2, expected: false);

            // Small tree tests.
            t1 = TreeHelpers.CreateBinaryTree(1, new BinaryTreeNode<int>(0), null);
            t2 = t1.Left;
            Validate(t1, t2, expected: true);
            Validate(t1, new BinaryTreeNode<int>(4), expected: false);
            Validate(t1, TreeHelpers.CreateBinaryTree(1, 0, 0), expected: false);
            t2 = TreeHelpers.CreateBinaryTree(1, new BinaryTreeNode<int>(0), null);
            Validate(t1, t2, expected: true);

            // Larger tree tests
            t1 = TreeHelpers.CreateBinaryTree(9, new BinaryTreeNode<int>(8), t1);
            t2 = TreeHelpers.CreateBinaryTree(9, new BinaryTreeNode<int>(8), t2);
            Validate(t1, t2, expected: true);
            Validate(t1, t2.Left, expected: true);
            Validate(t1, t2.Right, expected: true);
            Validate(t1, t2.Right.Right, expected: true);
            Validate(t1, TreeHelpers.CreateBinaryTree(8, new BinaryTreeNode<int>(9), null), expected: false);

            // Medium tree tests
            t1 = TreeHelpers.CreateBinaryTree(
                data: 4,
                left: TreeHelpers.CreateBinaryTree(2, 1, 10),
                right: TreeHelpers.CreateBinaryTree(6, 5, 7));
            t2 = TreeHelpers.CreateBinaryTree(2, 1, 10);
            Validate(t1, t2, expected: true);
            Validate(t1, TreeHelpers.CreateBinaryTree(5, 6, 7), expected: false);
        }

        private static void Validate(BinaryTreeNode<int> t1, BinaryTreeNode<int> t2, bool expected)
        {
            var result = Question_4_10.ContainsSubtree(t1, t2);
            Assert.AreEqual(expected, result);
        }
    }
}
