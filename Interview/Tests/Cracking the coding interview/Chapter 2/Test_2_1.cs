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
            // No duplicates
            var l1 = ListHelpers.CreateLinkedList(1, 2, 3);
            var expected = ListHelpers.CloneList(l1);
            this.ValidateResult(expected, l1);

            // Several (3x) duplicates
            var l2 = ListHelpers.CreateLinkedList(1, 1, 1);
            expected = ListHelpers.CreateLinkedList(1);
            this.ValidateResult(expected, l2);

            // two sets of duplicates, one next to each other one separated
            var l3 = ListHelpers.CreateLinkedList(1, 2, 2, 1);
            expected = ListHelpers.CreateLinkedList(1, 2);
            this.ValidateResult(expected, l3);

            // 3x duplicate case split up
            var l4 = ListHelpers.CreateLinkedList(1, 2, 2, 3, 2);
            expected = ListHelpers.CreateLinkedList(1, 2, 3);
            this.ValidateResult(expected, l4);

            // Several duplicates in the list
            var l5 = ListHelpers.CreateLinkedList(1, 2, 2, 1, 3, 4, 7, 5, 6, 2, 3, 4, 5, 6);
            expected = ListHelpers.CreateLinkedList(1, 2, 3, 4, 7, 5, 6);
            this.ValidateResult(expected, l5);
        }

        [TestMethod]
        public void Question_2_1_EdgeCases()
        {
            // 1 => 1 - Only one element.
            var l1 = ListHelpers.CreateLinkedList(1);
            var expected = ListHelpers.CloneList(l1);
            this.ValidateResult(expected, l1);

            // 1, 1 => 1 - Only duplicate elements
            var l2 = ListHelpers.CreateLinkedList(1, 1);
            expected = ListHelpers.CreateLinkedList(1);
            this.ValidateResult(expected, l2);

            // 1, 2, 2 => 1, 2 - Last element duplicated
            var l3 = ListHelpers.CreateLinkedList(1, 2, 2);
            expected = ListHelpers.CreateLinkedList(1, 2);
            this.ValidateResult(expected, l3);
        }

        [TestMethod]
        public void Question_2_1_InvalidCases()
        {
            Node<int> head = null;
            TestHelpers.AssertExceptionThrown(() => Question_2_1.RemoveDuplicates(head), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_2_1.RemoveDuplicatesNoSpace(head), typeof(ArgumentNullException));
        }

        private void ValidateResult<T>(Node<T> expected, Node<T> input)
            where T : IEquatable<T>
        {
            var inputCopy = ListHelpers.CloneList(input);
            Question_2_1.RemoveDuplicates(inputCopy);
            ListHelpers.ValidateLinkedListContent(expected, inputCopy);
            Question_2_1.RemoveDuplicatesNoSpace(input);
            ListHelpers.ValidateLinkedListContent(expected, input);
        } 
    }
}
