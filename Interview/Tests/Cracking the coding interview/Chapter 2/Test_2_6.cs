namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_6
    {
        [TestMethod]
        public void Question_2_6_BasicCases()
        {
            var l1 = ListHelpers.CreateLinkedList(1, 2, 1);
            var l2 = ListHelpers.CreateLinkedList(1, 2, 2, 2, 2, 2);
            var l3 = ListHelpers.CreateLinkedList(1, 1, 1, 1, 1);
            var l4 = ListHelpers.CreateLinkedList(1, 2, 3, 4, 5);
            var l5 = ListHelpers.CreateLinkedList(1, 2, 2, 2, 2, 2, 1);

            Validate(true, l1);
            Validate(false, l2);
            Validate(true, l3);
            Validate(false, l4);
            Validate(true, l5);
        }

        [TestMethod]
        public void Question_2_6_EdgeCases()
        {
            var l1 = ListHelpers.CreateLinkedList(1);
            var l2 = ListHelpers.CreateLinkedList(2, 2);
            var l3 = ListHelpers.CreateLinkedList(1, 2);

            Validate(true, l1);
            Validate(true, l2);
            Validate(false, l3);
        }

        [TestMethod]
        public void Question_2_6_InvalidCases()
        {
            Node<int> nullHead = null;
            TestHelpers.AssertExceptionThrown(() => Question_2_6.IsPalindrome(nullHead), typeof(ArgumentNullException));
        }

        private static void Validate<T>(bool expected, Node<T> head)
            where T : IEquatable<T>
        {
            var result = Question_2_6.IsPalindrome(head);
            Assert.AreEqual(expected, result);

            result = Question_2_6.IsPalindromeRecursive(head);
            Assert.AreEqual(expected, result);
        }
    }
}
