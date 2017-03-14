namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_4
    {

        [TestMethod]
        public void Test_1_4_FastSolution_Basic()
        {
            this.ValidateResult("abc", false);
            this.ValidateResult("abc def", false);
            this.ValidateResult("abc abc", true);
            this.ValidateResult("abca bc", true);
        }

        [TestMethod]
        public void Test_1_4_FastSolution_EdgeCases()
        {
            this.ValidateResult("a", true);
            this.ValidateResult("a ", true);
            this.ValidateResult("", false);
            this.ValidateResult(" ", false);
        }

        private void ValidateResult(string s, bool expected)
        {
            Assert.AreEqual(expected, Question_1_4.IsPalindromePermutation(s));
        }
    }
}
