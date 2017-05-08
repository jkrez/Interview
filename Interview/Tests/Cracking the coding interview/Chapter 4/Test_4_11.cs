namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_11
    {
        [TestMethod]
        public void Question_4_11_BasicCases()
        {
            // Single Node tree tests.
            var tree = TreeHelpers.CreateBinaryTree(0, null, null);
            Validate(tree);

            // Small tree;
            tree = TreeHelpers.CreateBinaryTree(1, 0, 2);
            Validate(tree);

            // Awkward tree.
            tree = TreeHelpers.CreateBinaryTreeFromArray(0, 1, 2, 3, 4, 5);
            Validate(tree);

            // Bigger tree
            tree = TreeHelpers.CreateBinaryTreeFromArray<int>(3, 1, 0, 2, 5, 4, 6);
            Validate(tree);

        }

        private static void Validate(BinaryTreeNode<int> root)
        {
            for (int i = 0; i < root.NodeCount; i++)
            {
                var nthNode = Question_4_11.GetNthNode(root, i);
                Assert.AreEqual(i, nthNode.Data);
            }
        }
    }
}
