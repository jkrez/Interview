namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_12
    {
        [TestMethod]
        public void Question_4_12_BasicCases()
        {
            // Empty tree.
            BinaryTreeNode<int> tree = null;
            Validate(0, tree, 2);
            Validate(0, tree, 0);

            // Single Node tree tests.
            tree = TreeHelpers.CreateBinaryTree(0, null, null);
            Validate(0, tree, 1);
            Validate(1, tree, 0);

            // Small tree;
            tree = TreeHelpers.CreateBinaryTree(1, 0, 2);
            Validate(2, tree, 1);
            Validate(1, tree, 0);
            Validate(1, tree, 2);
            Validate(1, tree, 3);
            Validate(0, tree, 4);
            Validate(0, tree, -1);

            // Awkward lopsided tree.
            //   0
            //    \
            //     1
            //      \
            //       2
            //        ...
            tree = TreeHelpers.CreateBinaryTreeFromArray(0, 1, 2, 3, 4, 5);
            Validate(2, tree, 1);
            Validate(2, tree, 5);
            Validate(2, tree, 15);
            Validate(3, tree, 3);
            Validate(1, tree, 4);
            Validate(0, tree, 8);

            // Bigger tree
            //                3
            //              /   \
            //             1     5
            //            / \   / \
            //           2   0 4   6
            tree = TreeHelpers.CreateBinaryTreeFromArray<int>(3, 1, 0, 2, 5, 4, 6);
            Validate(1, tree, 5);
            Validate(2, tree, 6);
            Validate(1, tree, 12);
            Validate(3, tree, 4);
            Validate(1, tree, 14);
            Validate(2, tree, 1);
            Validate(1, tree, 2);
        }

        private static void Validate(int expectedPathCount, BinaryTreeNode<int> root, int target)
        {
            var result = Question_4_12.SumPaths(root, target);
            Assert.AreEqual(expectedPathCount, result);
        }
    }
}
