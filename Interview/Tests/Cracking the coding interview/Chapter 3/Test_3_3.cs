namespace Tests.Cracking_the_coding_interview.Chapter_3
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_3;

    [TestClass]
    public class Test_3_3
    {
        [TestMethod]
        public void Question_3_3_BasicCases()
        {
            var item1 = 1;
            var item2 = 2;
            var item3 = 3;
            var item4 = 0;
            var item5 = -1;

            var stackSet = new SetOfStacks<int>();
            stackSet.Push(item1);
            stackSet.Push(item2);
            stackSet.Push(item3);
            stackSet.Push(item4);
            stackSet.Push(item5);
            var pop1 = stackSet.Pop();
            var pop2 = stackSet.Pop();
            var pop3 = stackSet.Pop();
            var pop4 = stackSet.Pop();
            var pop5 = stackSet.Pop();

            Assert.AreEqual(pop1, item5);
            Assert.AreEqual(pop2, item4);
            Assert.AreEqual(pop3, item3);
            Assert.AreEqual(pop4, item2);
            Assert.AreEqual(pop5, item1);
        }
    }
}
