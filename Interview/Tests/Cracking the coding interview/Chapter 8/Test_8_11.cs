namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_11
    {
        [TestMethod]
        public void Question_8_11_BasicCases()
        {
            var amount = 15;
            var denominations = new List<int> { 25, 10, 5, 1};
            Validate(6, amount, denominations);

            amount = 100;
            Validate(242, amount, denominations);
        }

        private void Validate(int expected, int amount, List<int> denominations)
        {
            var cache = new Dictionary<Tuple<int, int>, int>();
            var result = Question_8_11.MakeChangeDynamic(amount, denominations, 0, cache);
            Assert.AreEqual(expected, result);
        }
    }
}
