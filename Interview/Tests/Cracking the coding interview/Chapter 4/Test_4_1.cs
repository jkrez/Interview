namespace Tests.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_4;
    using Questions.Data_structures;

    [TestClass]
    public class Test_4_1
    {
        [TestMethod]
        public void Question_4_1_BasicCases()
        {
            var node1 = new GraphNode<int>(0);
            var node2 = new GraphNode<int>(0);
            this.Validate(node1, node2, true, true);

            node2 = new GraphNode<int>(2);
            this.Validate(node1, node2, false, false);

            var root1 = GraphHelpers.CreateGraph(0, 1, 2, 3);
            var root2 = GraphHelpers.CreateGraph(4, 5, 6, 7);
            var root3 = GraphHelpers.CreateGraph(8, root1, root2);
            this.Validate(root1, root2, false, false);
            this.Validate(root1, root3, false, true);

            var root4 = GraphHelpers.CreateGraph(9, root1, root3);
            this.Validate(root4, root3, true, true);
            this.Validate(root1, root4, false, true);
            this.Validate(root1, root3, false, true);
            this.Validate(root3, root1, true, true);
            this.Validate(root2, root1, false, false);
        }

        [TestMethod]
        public void Question_4_1_InvalidCases()
        {
            var tree = new GraphNode<int>(0, null);

            TestHelpers.AssertExceptionThrown(() => { Question_4_1.AreConnectedBFS(null, tree); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question_4_1.AreConnectedBFS(tree, null); }, typeof(ArgumentNullException));
        }

        private void Validate<T>(GraphNode<T> node1, GraphNode<T> node2, bool expected, bool expectedBiDirectional)
            where T : IEquatable<T>
        {
            var result = Question_4_1.AreConnectedBFS(node1, node2);
            Assert.AreEqual(expected, result, "Result did not equal expected.");
            result = Question_4_1.AreConnectedBiDirectionalBFS(node1, node2);
            Assert.AreEqual(expectedBiDirectional, result, "BiDirectional result was not expected.");
        }
    }
}
