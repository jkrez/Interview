namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_9
    {
        [TestMethod]
        public void Question_8_9_BasicCases()
        {
            for (int i = 0; i < 10; i++)
            {
                Validate(i);
            }
        }

        private static void Validate(int n)
        {
            var result = Question_8_9.GetParenthesis(n);
            var set = new HashSet<string>();
            foreach (var str in result)
            {
                set.Add(str);
            }

            Assert.AreEqual(set.Count, result.Count);
        }
    }
}
