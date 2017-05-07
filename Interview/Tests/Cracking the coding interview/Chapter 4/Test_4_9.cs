namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_9
    {
        [TestMethod]
        public void Question_4_9_BasicCases()
        {
            // Null tree
            var tree = (BinaryTreeNode<int>)null;
            var expected = new List<List<int>>();
            Validate(tree, expected);

            // Single Node tree tests.
            tree = TreeHelpers.CreateBinaryTree(1, null, null);
            expected = new List<List<int>>()
            {
                new List<int>() { 1 }
            };

            Validate(tree, expected);

            // Small tree tests.
            tree = TreeHelpers.CreateBinaryTree(1, new BinaryTreeNode<int>(0), null);
            expected = new List<List<int>>()
            {
                new List<int>() { 1, 0}
            };

            Validate(tree, expected);

            // Small tree tests.
            tree = TreeHelpers.CreateBinaryTree(1, 0, 2);
            expected = new List<List<int>>()
            {
                new List<int>() { 1, 0, 2 },
                new List<int>() { 1, 2, 0 }
            };

            Validate(tree, expected);

            // Unbalanced tree
            // Small tree tests.
            tree = TreeHelpers.CreateBinaryTree(1, new BinaryTreeNode<int>(0), TreeHelpers.CreateBinaryTree(4, 2, 5));
            expected = new List<List<int>>()
            {
                new List<int>() { 1, 0, 4, 2, 5 },
                new List<int>() { 1, 0, 4, 5, 2 },
                new List<int>() { 1, 4, 2, 5, 0 },
                new List<int>() { 1, 4, 5, 2, 0 }
            };

            Validate(tree, expected);

            // Medium tree tests
            tree = TreeHelpers.CreateBinaryTree(
                data: 4,
                left: TreeHelpers.CreateBinaryTree(2, 1, 10),
                right: TreeHelpers.CreateBinaryTree(6, 5, 7));
            expected = new List<List<int>>()
            {
                new List<int>() { 4, 2, 1, 10, 6, 5, 7 },
                new List<int>() { 4, 2, 10, 1, 6, 5, 7 },
                new List<int>() { 4, 2, 1, 10, 6, 7, 5 },
                new List<int>() { 4, 2, 10, 1, 6, 7, 5 },
                new List<int>() { 4, 6, 5, 7, 2, 1, 10 },
                new List<int>() { 4, 6, 7, 5, 2, 1, 10 },
                new List<int>() { 4, 6, 5, 7, 2, 10, 1 },
                new List<int>() { 4, 6, 7, 5, 2, 10, 1 }
            };

            Validate(tree, expected);
        }

        private static void Validate(BinaryTreeNode<int> root, List<List<int>> expected)
        {
            var result = Question_4_9.PossibleArrays(root);
            if (expected == null)
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(expected.Count, result.Count);
                foreach (var sequence in result)
                {
                    if (expected.FindLast(l => l.SequenceEqual(sequence)) != null)
                    {
                        expected.Remove(expected.FindLast(l => l.SequenceEqual(sequence)));
                    }
                }

                Assert.AreEqual(expected.Count, 0);
            }
        }
    }
}
