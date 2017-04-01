namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_4
    {
        [TestMethod]
        public void Question_2_4_BasicCases()
        {
            // List already partitioned.
            var l1 = ListHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(l1, 2, 1, 2, 3);

            // List already partitioned.
            var l2 = ListHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(l2, 1, 1, 2, 3);

            // List needs to be partitioned.
            var l3 = ListHelpers.CreateLinkedList(5, 4, 3, 2, 1);
            ValidateResult(l3, 3, 2, 1, 3, 5, 4);
        }

        [TestMethod]
        public void Question_2_4_EdgeCases()
        {
            // One node list, no change
            var l1 = ListHelpers.CreateLinkedList(1);
            ValidateResult(l1, 0, 1);
            ValidateResult(l1, 1, 1);
            ValidateResult(l1, 2, 1);

            // List with all the same values
            var l2 = ListHelpers.CreateLinkedList(2, 2, 2, 2, 2, 2);
            ValidateResult(l2, 2, 2, 2, 2, 2, 2, 2);
        }

        [TestMethod]
        public void Question_2_4_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_2_4.PartitionList(null, 1), typeof(ArgumentNullException));
        }

        private static void ValidateResult<T>(Node<T> list, T partition, params T[] expected)
            where T : IEquatable<T>, IComparable<T>
        {
            Question_2_4.PartitionList(list, partition);
            ListHelpers.ValidateLinkedListContent(list, expected);
        }
    }
}
