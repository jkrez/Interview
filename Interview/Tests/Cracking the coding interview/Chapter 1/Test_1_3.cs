namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_3
    {
        [TestMethod]
        public void Question_1_3_InvalidInput()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_3.EscapeString(null), typeof(ArgumentException));
        }

        [TestMethod]
        public void Question_1_3_BasicTests()
        {
            // No spaces
            this.ValidateResult("abc", "abc");

            // Some spaces
            this.ValidateResult("a%20b%20c", "a b c");
        }

        [TestMethod]
        public void Question_1_3_EdgeCases()
        {
            // Empty string
            this.ValidateResult("", "");

            // Since space
            this.ValidateResult("%20", " ");
        }

        [TestMethod]
        public void Question_1_3_InPlace_BasicTests()
        {
            this.ValidateResultInPlace("%20abc"," abc  ");
            this.ValidateResultInPlace("%20","   ", 1);
            this.ValidateResultInPlace("a%20%20b","a  b    ");
        }

        [TestMethod]
        public void Question_1_3_InPlace_EdgeCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_3.EscapeStringInplace(null, 0), typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => Question_1_3.EscapeStringInplace("  ".ToCharArray(), -1), typeof(ArgumentException));

            this.ValidateResultInPlace("","");
        }


        private void ValidateResult(string expected, string input)
        {
            Assert.AreEqual(expected, Question_1_3.EscapeString(input));
        }

        private void ValidateResultInPlace(string expected, string input, int? inputLength= null)
        {

            var length = inputLength ?? input.TrimEnd(' ').Length;
            var charArray = input.ToCharArray();
            Question_1_3.EscapeStringInplace(charArray, length);
            Assert.AreEqual(expected, string.Concat(charArray));
        }
    }
}
