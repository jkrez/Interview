namespace Tests.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_3;

    [TestClass]
    public class Test_3_4
    {
        [TestMethod]
        public void Question_3_4_BasicCases()
        {
            var item1 = 1;
            var item2 = 2;
            var item3 = 3;
            var item4 = 0;
            var item5 = -1;

            var qs = new QueueFromStacks<int>();
            qs.Push(item1);
            qs.Push(item2);
            qs.Push(item3);
            qs.Push(item4);
            qs.Push(item5);
            var pop1 = qs.Pop();
            var pop2 = qs.Pop();
            var pop3 = qs.Pop();
            var pop4 = qs.Pop();
            var pop5 = qs.Pop();

            Assert.AreEqual(pop1, item1);
            Assert.AreEqual(pop2, item2);
            Assert.AreEqual(pop3, item3);
            Assert.AreEqual(pop4, item4);
            Assert.AreEqual(pop5, item5);
        }

        [TestMethod]
        public void Question_3_4_InvalidCases()
        {
            var stack = new QueueFromStacks<int>();

            TestHelpers.AssertExceptionThrown(() => { stack.Pop(); }, typeof(InvalidOperationException));
        }
    }
}
