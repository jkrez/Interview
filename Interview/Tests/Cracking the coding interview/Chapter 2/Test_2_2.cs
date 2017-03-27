namespace Tests.Cracking_the_coding_interview.Chapter_2
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_2;
    using Questions.Data_structures;

    public class Test_2_2
    {
        [TestClass]
        public class Test_2_1
        {
            [TestMethod]
            public void Question_2_2_BasicCases()
            {
                // Cover all case for K for a list of length 6.
                const int NumberElements = 6;

                var list = ListHelpers.CreateLinkedList(Enumerable.Range(0, NumberElements).Reverse().ToArray());

                for (var i = 0; i < NumberElements; i++)
                {
                    var listCopy = ListHelpers.CloneList(list);
                    var result = Question_2_2.ReturnKthToLast(listCopy, i);
                    Assert.AreEqual(i, result);
                }
            }

            [TestMethod]
            public void Question_2_2_EdgeCases()
            {
                // 1 => 1 - Only one element.
                var l1 = ListHelpers.CreateLinkedList(1);
                Assert.AreEqual(1, Question_2_2.ReturnKthToLast(l1, 0));
            }

            [TestMethod]
            public void Question_2_2_InvalidCases()
            {
                Node<int> invalidHead = null;
                var head = ListHelpers.CreateLinkedList(1);
                TestHelpers.AssertExceptionThrown(
                    () => Question_2_2.ReturnKthToLast(invalidHead, 0),
                    typeof(ArgumentNullException));

                TestHelpers.AssertExceptionThrown(
                    () => Question_2_2.ReturnKthToLast(head, -1),
                    typeof(ArgumentOutOfRangeException));

                TestHelpers.AssertExceptionThrown(
                    () => Question_2_2.ReturnKthToLast(head, 1),
                    typeof(ArgumentOutOfRangeException));
            }

            private void ValidateResult<T>(Node<T> expected, Node<T> input, int k)
                where T : IEquatable<T>
            {
                var inputCopy = ListHelpers.CloneList(input);
                var inputCopy2 = ListHelpers.CloneList(input);
                Assert.AreEqual(expected, Question_2_2.ReturnKthToLast(inputCopy, k));
            }
        }
    }
}
