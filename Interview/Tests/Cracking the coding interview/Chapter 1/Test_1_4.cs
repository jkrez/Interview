namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_4
    {

        [TestMethod]
        public void Question_1_4_FastSolution_Basic()
        {
            this.ValidateResult("abc", false);
            this.ValidateResult("abc def", false);
            this.ValidateResult("abc abc", true);
            this.ValidateResult("abca bc", true);
            this.ValidateResult("aba", true);
            this.ValidateResult("aabb", true);
            this.ValidateResult("aaabbbb", true);
            this.ValidateResult("aaabbb", false);
        }

        [TestMethod]
        public void Question_1_4_FastSolution_EdgeCases()
        {
            this.ValidateResult("a", true);
            this.ValidateResult("a ", true);
            this.ValidateResult("", true);
            this.ValidateResult(" ", true);
        }

        [TestMethod]
        public void Question_1_4_FastSolution_InvalidInput()
        {
            TestHelpers.AssertExceptionThrown(() => this.ValidateResult("!", false), typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => this.ValidateResult("\t", false), typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => this.ValidateResult(null, false), typeof(ArgumentException));
        }

        private void ValidateResult(string s, bool expected)
        {
            Assert.AreEqual(
                expected, 
                Question_1_4.IsPalindromePermutationFast(s),
                $"IsPalindromePermutationFast failed with {s}");

            Assert.AreEqual(
                expected, 
                Question_1_4.IsPalinromePermutationMinSpace(s),
                $"IsPalinromePermutationMinSpace failed with {s}");
        }
    }
}
