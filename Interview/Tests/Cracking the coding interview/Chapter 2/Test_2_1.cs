namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_1
    {
        [TestMethod]
        public void Question_2_1_BasicCases()
        {
            // 1, 2, 3 => 1, 2, 3
            var l1 = ListHelpers.CreateLinkedList(1, 2, 3);
            var expected = ListHelpers.CloneList(l1);
            Question_2_1.RemoveDuplicates(l1);
            this.ValidateResult(expected, l1);

            // 1, 1, 1, => 1
            var l2 = ListHelpers.CreateLinkedList(1, 1, 1);
            expected = ListHelpers.CreateLinkedList(1);
            Question_2_1.RemoveDuplicates(l2);
            this.ValidateResult(expected, l2);

            // 1, 2, 2, 1 => 1, 2
            var l3 = ListHelpers.CreateLinkedList(1, 2, 2, 1);
            expected = ListHelpers.CreateLinkedList(1, 2);
            Question_2_1.RemoveDuplicates(l3);
            this.ValidateResult(expected, l3);
        }

        [TestMethod]
        public void Question_2_1_EdgeCases()
        {
            // 1 => 1
            var l1 = ListHelpers.CreateLinkedList(1);
            var expected = ListHelpers.CloneList(l1);
            Question_2_1.RemoveDuplicates(l1);
            this.ValidateResult(expected, l1);

            // 1 => 1
            var l2 = ListHelpers.CreateLinkedList(1, 1);
            expected = ListHelpers.CreateLinkedList(1);
            Question_2_1.RemoveDuplicates(l2);
            this.ValidateResult(expected, l2);

        }

        [TestMethod]
        public void Question_2_1_InvalidCases()
        {
            Node<int> head = null;
            TestHelpers.AssertExceptionThrown(() => Question_2_1.RemoveDuplicates(head), typeof(ArgumentNullException));
        }

        private void ValidateResult<T>(Node<T> expected, Node<T> actual)
            where T : IEquatable<T>
        {
            ListHelpers.ValidateLinkedListContent(expected, actual);
        } 
    }
}
