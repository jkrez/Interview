namespace Tests.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_3;

    [TestClass]
    public class Test_3_5
    {
        [TestMethod]
        public void Question_3_5_BasicCases()
        {
            var s1 = new Stack<int>();
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);
            s1.Push(4);
            s1.Push(5);
            Validate(s1);

            var s2 = new Stack<int>();
            s2.Push(4);
            s2.Push(3);
            s2.Push(5);
            s2.Push(4);
            s2.Push(3);
            s2.Push(5);
            s2.Push(4);
            s2.Push(4);
            Validate(s2);

            var s3 = new Stack<int>();
            s3.Push(1);
            Validate(s3);

            var s4 = new Stack<int>();
            s4.Push(2);
            s4.Push(1);
            s4.Push(3);
            Validate(s4);

            Validate(new Stack<int>());
        }

        [TestMethod]
        public void Question_3_5_InvalidCases()
        {
            Stack<int> s = null;
            TestHelpers.AssertExceptionThrown(() => Question_3_5.SortStack(s), typeof(ArgumentNullException));
        }

        private static void Validate<T>(Stack<T> stack)
            where T : IComparable<T>
        {
            var cloneStack = new Stack<T>(stack);
            Question_3_5.SortStack(cloneStack);
            ValidateOrder(cloneStack);
        }

        private static void ValidateOrder<T>(Stack<T> s)
            where T : IComparable<T>
        {
            while (s.Count != 0)
            {
                var next = s.Pop();
                if (s.Count != 0)
                {
                    Assert.IsTrue(s.Peek().CompareTo(next) >= 0);
                }
            }
        }
    }
}
