namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Tetst_4_3
    {
        [TestMethod]
        public void Question_4_3_BasicCases()
        {
            // One node tree
            var tree = TreeHelpers.CreateBinaryTree(1, null, null);
            var expected = new List<List<int>>()
            {
                ListHelpers.CreateList(1)
            };

            Validate(expected, tree);

            // Two level tree
            tree = TreeHelpers.CreateBinaryTree(1, 2, 0);
            expected = new List<List<int>>()
            {
                ListHelpers.CreateList(1),
                ListHelpers.CreateList(2, 0)
            };

            Validate(expected, tree);

            // Two level tree
            var temp1 = TreeHelpers.CreateBinaryTree(0, 1, 2);
            var temp2 = TreeHelpers.CreateBinaryTree(4, 5, 6);
            var temp3 = TreeHelpers.CreateBinaryTree(11, temp1, temp2);
            var temp4 = TreeHelpers.CreateBinaryTree(8, temp3, null);
            expected = new List<List<int>>()
            {
                ListHelpers.CreateList(8),
                ListHelpers.CreateList(11),
                ListHelpers.CreateList(0, 4),
                ListHelpers.CreateList(1, 2, 5, 6),
            };

            Validate(expected, temp4);
        }

        [TestMethod]
        public void Question_4_3_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_4_3.CreateDepthList((BinaryTreeNode<int>)null), typeof(ArgumentNullException) );
        }

        private static void Validate<T>(List<List<int>> expected, BinaryTreeNode<T> tree)
            where T : IEquatable<T>
        {
            var actual1 = Question_4_3.CreateDepthList(tree);
            AssertListHelper(expected, actual1);
            var actual2 = Question_4_3.CreateDepthListIterative(tree);
            AssertListHelper(expected, actual2);
        }

        private static void AssertListHelper<T>(List<List<int>> expected, List<List<BinaryTreeNode<T>>> actual)
            where T : IEquatable<T>
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Count, actual[i].Count);
                for (int j = 0; j < expected[i].Count; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j].Data);
                }
            }
        }
    }
}
