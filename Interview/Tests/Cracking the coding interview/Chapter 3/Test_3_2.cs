namespace Tests.Cracking_the_coding_interview.Chapter_3
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_3;

    [TestClass]
    public class Test_3_2
    {
        [TestMethod]
        public void Question_3_2_BasicCases()
        {
            var item1 = 1;
            var item2 = 2;
            var item3 = 3;
            var item4 = 0;
            var item5 = -1;

            var ms1 = new MinStack<int>();
            ms1.Push(item1);
            var min1 = ms1.GetMinimum();
            ms1.Push(item2);
            var min2 = ms1.GetMinimum();
            ms1.Push(item3);
            var min3 = ms1.GetMinimum();
            ms1.Push(item4);
            var min4 = ms1.GetMinimum();
            ms1.Push(item5);
            var min5 = ms1.GetMinimum();
            var pop1 = ms1.Pop();
            var min6 = ms1.GetMinimum();
            var pop2 = ms1.Pop();
            var min7 = ms1.GetMinimum();
            var pop3 = ms1.Pop();
            var min8 = ms1.GetMinimum();
            var pop4 = ms1.Pop();
            var min9 = ms1.GetMinimum();
            var pop5 = ms1.Pop();

            Assert.AreEqual(pop1, item5);
            Assert.AreEqual(pop2, item4);
            Assert.AreEqual(pop3, item3);
            Assert.AreEqual(pop4, item2);
            Assert.AreEqual(pop5, item1);

            Assert.AreEqual(1, min1);
            Assert.AreEqual(1, min2);
            Assert.AreEqual(1, min3);
            Assert.AreEqual(0, min4);
            Assert.AreEqual(-1, min5);
            Assert.AreEqual(0, min6);
            Assert.AreEqual(1, min7);
            Assert.AreEqual(1, min8);
            Assert.AreEqual(1, min9);
        }

        [TestMethod]
        public void Question_3_2_InvalidCases()
        {
            var ms1 = new MinStack<int>();

            TestHelpers.AssertExceptionThrown(() => { ms1.Pop(); }, typeof(InvalidOperationException));
            TestHelpers.AssertExceptionThrown(() => { ms1.GetMinimum(); }, typeof(InvalidOperationException));

            for (int i = 100; i > 0; i--)
            {
                ms1.Push(i);
            }

            TestHelpers.AssertExceptionThrown(() => { ms1.Push(1); }, typeof(InvalidOperationException));
        }
    }
}
