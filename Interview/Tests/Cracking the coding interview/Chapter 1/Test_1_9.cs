namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_9
    {
        [TestMethod]
        public void Question_1_9_BasicCases()
        {
            var baseString = "abc";
            var rotatedString = "bca";
            Assert.AreEqual(true, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "aaabbb";
            rotatedString = "bbbaa";
            Assert.AreEqual(false, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "aaabbb";
            rotatedString = "bbbaaa";
            Assert.AreEqual(true, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "aaabbb";
            rotatedString = "bbbaaab";
            Assert.AreEqual(false, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "ab";
            rotatedString = "ba";
            Assert.AreEqual(true, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "ab";
            rotatedString = "bb";
            Assert.AreEqual(false, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "aaaaaa";
            rotatedString = "aaaaa";
            Assert.AreEqual(false, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "aaaaa";
            rotatedString = "aaaaa";
            Assert.AreEqual(true, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = "aaaaa";
            rotatedString = "aaaa";
            Assert.AreEqual(false, Question_1_9.IsRotation(baseString, rotatedString));
        }

        [TestMethod]
        public void Question_1_9_EdgeCases()
        {
            var baseString = "b";
            var rotatedString = "b";
            Assert.AreEqual(true, Question_1_9.IsRotation(baseString, rotatedString));

            baseString = string.Empty;
            rotatedString = string.Empty;
            Assert.AreEqual(true, Question_1_9.IsRotation(baseString, rotatedString));
        }

        [TestMethod]
        public void Question_1_9_InvaidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_9.IsRotation(null, string.Empty), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_1_9.IsRotation(string.Empty, null), typeof(ArgumentNullException));
        }
    }
}
