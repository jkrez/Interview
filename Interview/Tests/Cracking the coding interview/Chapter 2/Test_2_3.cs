namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_3
    {
        [TestMethod]
        public void Question_2_3_BasicCases()
        {
            // Remove 1 middle node: 1, 2, 3 => 1, 3
            var l1 = ListHelpers.CreateLinkedList(1, 2, 3);
            var expected = ListHelpers.CreateLinkedList(1, 3);
            Question_2_3.RemoveMiddleNode(l1.Next);
            ListHelpers.ValidateLinkedListContent(expected, l1);

            // Remove 2: 1, 2, 3, 4 => 1, 4
            var l2 = ListHelpers.CreateLinkedList(1, 2, 3, 4);
            expected = ListHelpers.CreateLinkedList(1, 4);
            Question_2_3.RemoveMiddleNode(l2.Next);
            Question_2_3.RemoveMiddleNode(l2.Next);
            ListHelpers.ValidateLinkedListContent(expected, l2);

            // Remove 1 node from big list: 1, 2, 3, 4, 5, 6, 7 => 1, 2, 3, 5, 6, 7
            var l3 = ListHelpers.CreateLinkedList(1, 2, 3, 4, 5, 6, 7);
            expected = ListHelpers.CreateLinkedList(1, 2, 3, 5, 6, 7);
            Question_2_3.RemoveMiddleNode(l3.Next.Next.Next);
            ListHelpers.ValidateLinkedListContent(expected, l3);
        }

        [TestMethod]
        public void Question_2_3_InvalidCases()
        {
            // Remove end of list
            var l3 = ListHelpers.CreateLinkedList(1, 2);
            var expected = ListHelpers.CreateLinkedList(1);
            TestHelpers.AssertExceptionThrown(() => Question_2_3.RemoveMiddleNode(l3.Next), typeof(ArgumentException));

            // Pass null node.
            Node<int> head = null;
            TestHelpers.AssertExceptionThrown(() => Question_2_3.RemoveMiddleNode(head), typeof(ArgumentNullException));
        }
    }
}
