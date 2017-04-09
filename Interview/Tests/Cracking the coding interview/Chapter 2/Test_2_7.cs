namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_7
    {
        [TestMethod]
        public void Question_2_7_BasicCases()
        {
            var l1 = ListHelpers.CreateLinkedList(1, 2);
            var l2 = ListHelpers.CreateLinkedList(3, 4);
            var intersection = ListHelpers.CreateLinkedList(5, 6);
            AddIntersection(l1, l2, intersection);
            Validate(intersection, l1, l2);

            l1 = ListHelpers.CreateLinkedList(1);
            l2 = ListHelpers.CreateLinkedList(2);
            intersection = ListHelpers.CreateLinkedList(3);
            AddIntersection(l1, l2, intersection);
            Validate(intersection, l1, l2);

            l1 = ListHelpers.CreateLinkedList(1, 2, 3, 4);
            l2 = ListHelpers.CreateLinkedList(2);
            intersection = ListHelpers.CreateLinkedList(5);
            AddIntersection(l1, l2, intersection);
            Validate(intersection, l1, l2);

            l1 = ListHelpers.CreateLinkedList(1, 2, 3, 4);
            l2 = ListHelpers.CreateLinkedList(2, 2, 2, 2);
            intersection = ListHelpers.CreateLinkedList(5, 4, 3, 2, 3);
            AddIntersection(l1, l2, intersection);
            Validate(intersection, l1, l2);

            intersection = ListHelpers.CreateLinkedList(4);
            Validate(intersection, intersection, intersection);

        }

        [TestMethod]
        public void Question_2_7_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_2_7.FindIntersection(null, new Node<int>(1)),
                typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_2_7.FindIntersection(new Node<int>(1), null),
                typeof(ArgumentNullException));
        }

        private static void Validate<T>(Node<T> expected, Node<T> l1, Node<T> l2)
            where T : IEquatable<T>
        {
            Assert.IsTrue(ReferenceEquals(Question_2_7.FindIntersection(l1, l2), expected));
        }

        private static void AddIntersection<T>(Node<T> l1, Node<T> l2, Node<T> intersection)
            where T : IEquatable<T>
        {
            while (l1.Next != null)
            {
                l1 = l1.Next;
            }

            while (l2.Next != null)
            {
                l2 = l2.Next;
            }

            l1.Next = intersection;
            l2.Next = intersection;
        }
    }
}
