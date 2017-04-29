namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_4
    {

        [TestMethod]
        public void Question_4_4_BasicCases()
        {
            // One node tree
            var tree = TreeHelpers.CreateBinaryTree(1, null, null);
            Validate(true, tree);

            // Two level tree
            tree = TreeHelpers.CreateBinaryTree(1, 2, 0);
            Validate(true, tree);

            // Two node uneven tree.
            tree = TreeHelpers.CreateBinaryTree(
                1,
                TreeHelpers.CreateBinaryTree(2, new BinaryTreeNode<int>(3), null),
                null);

            Validate(false, tree);

            // Non BST very uneven.
            var temp1 = TreeHelpers.CreateBinaryTree(0, 1, 2);
            var temp2 = TreeHelpers.CreateBinaryTree(4, 5, 6);
            var temp3 = TreeHelpers.CreateBinaryTree(11, temp1, temp2);
            tree = TreeHelpers.CreateBinaryTree(8, temp3, null);
            Validate(false, tree);
        }

        [TestMethod]
        public void Question_4_4_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_4.IsBalanced((BinaryTreeNode<int>)null), typeof(ArgumentNullException));
        }

        private static void Validate<T>(bool expected, BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            var result = Question_4_4.IsBalanced(root);
            Assert.AreEqual(expected, result);
        }
    }
}
