namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    [TestClass]
    public class Test_2_8
    {
        [TestMethod]
        public void Question_2_8_BasicCases()
        {
            var list = ListHelpers.CreateLinkedList(1, 2, 3);
            var loopStart = AddLoop(list, 4, 5, 6);
            Validate(loopStart, list);

            list = ListHelpers.CreateLinkedList(1);
            loopStart = AddLoop(list, 4, 5, 6);
            Validate(loopStart, list);

            list = ListHelpers.CreateLinkedList(1);
            loopStart = AddLoop(list, 4);
            Validate(loopStart, list);

            loopStart = AddLoop(null, 5);
            Validate(loopStart, loopStart);

        }

        [TestMethod]
        public void Question_2_8_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_2_8.BeginningOfCycle<int>(null), typeof(ArgumentNullException));
        }

        private static void Validate<T>(Node<T> expected, Node<T> list)
            where T : IEquatable<T>
        {
            Assert.AreEqual(expected, Question_2_8.BeginningOfCycle(list));
        }

        private static Node<T> AddLoop<T>(Node<T> head, params T[] loop)
         where T : IEquatable<T>
        {
            while (head?.Next != null)
            {
                head = head.Next;
            }

            var loopStart = ListHelpers.CreateLinkedList(loop);
            var loopEnd = loopStart;

            while (loopEnd.Next != null)
            {
                loopEnd = loopEnd.Next;
            }

            if (head != null)
            {
                head.Next = loopStart;
            }

            loopEnd.Next = loopStart;

            return loopStart;
        }
    }
}
