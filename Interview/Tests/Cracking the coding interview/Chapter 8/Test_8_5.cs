namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_5
    {
        [TestMethod]
        public void Question_8_5_BasicCases()
        {
            foreach (var a in Enumerable.Range(0, 50))
            {
                foreach (var b in Enumerable.Range(0, 50))
                {
                    Validate(a, b);
                }
            }
        }

        private static void Validate(int a, int b)
        {
            var expected = a * b;
            var result = Question_8_5.RecursiveMultiply(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}
