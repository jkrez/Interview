namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_5
    {
        [TestMethod]
        public void Question_4_5_BasicCases()
        {
            // One node tree
            var tree = TreeHelpers.CreateBinaryTree(1, null, null);
            Validate(true, tree);

            // Invalid two node tree
            tree = TreeHelpers.CreateBinaryTree(1, new BinaryTreeNode<int>(2), null);
            Validate(false, tree);

            // Valid two node tree
            tree = TreeHelpers.CreateBinaryTree(1, null, new BinaryTreeNode<int>(2));
            Validate(true, tree);

            // Valid three node tree
            tree = TreeHelpers.CreateBinaryTree(1, 0, 2);
            Validate(true, tree);

            // Larger invalid tree
            tree = TreeHelpers.CreateBinaryTree(
                1,
                TreeHelpers.CreateBinaryTree(0, -1, 2),
                new BinaryTreeNode<int>(3));

            Validate(false, tree);

            // Larger valid tree
            tree = TreeHelpers.CreateBinaryTree(
                1,
                TreeHelpers.CreateBinaryTree(-1, -2, 0),
                new BinaryTreeNode<int>(3));

            Validate(true, tree);

            // Even larger invalid tree.
            var temp1 = TreeHelpers.CreateBinaryTree(1, 0, 2);
            var temp2 = TreeHelpers.CreateBinaryTree(5, 4, 6);
            var temp3 = TreeHelpers.CreateBinaryTree(7, temp1, temp2);
            tree = TreeHelpers.CreateBinaryTree(8, temp3, null);
            Validate(false, tree);

            // Even larger valid tree.
            temp1 = TreeHelpers.CreateBinaryTree(1, 0, 2);
            temp2 = TreeHelpers.CreateBinaryTree(6, 5, 7);
            temp3 = TreeHelpers.CreateBinaryTree(4, temp1, temp2);
            tree = TreeHelpers.CreateBinaryTree(8, temp3, null);
            Validate(true, tree);
        }

        [TestMethod]
        public void Question_4_5_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_5.IsBST((BinaryTreeNode<int>) null), typeof(ArgumentNullException));
        }

        private static void Validate(bool expected, BinaryTreeNode<int> root)
        {
            var result = Question_4_5.IsBST(root);
            Assert.AreEqual(expected, result);
        }
    }
}
