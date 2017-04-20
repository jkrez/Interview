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
            this.Validate(node1, node2, true);

            node2 = new GraphNode<int>(2);
            this.Validate(node1, node2, false);

            var root1 = GraphHelpers.CreateGraph(0, 1, 2, 3);
            var root2 = GraphHelpers.CreateGraph(4, 5, 6, 7);
            var root3 = GraphHelpers.CreateGraph(8, root1, root2);
            this.Validate(root1, root2, false);
            this.Validate(root1, root3, false);

            var root4 = GraphHelpers.CreateGraph(9, root1, root3);
            this.Validate(root4, root3, true);
            this.Validate(root1, root4, false);
        }

        private void Validate<T>(GraphNode<T> node1, GraphNode<T> node2, bool expected)
            where T : IEquatable<T>
        {
            var result = Question_4_1.AreConnectedBFS(node1, node2);
            Assert.AreEqual(expected, result, "Result did not equal expected.");
        }
    }
}
