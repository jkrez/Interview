namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_2
    {
        [TestMethod]
        public void Question_1_2_Basic_ReturnsTrue()
        {
            var s1 = "abc";
            var s2 = "cba";

            Assert.AreEqual(true, Question_1_2.AreStringsPermutationsDict(s1, s2));
        }

        [TestMethod]
        public void Question_1_2_Basic_ReturnsFalse()
        {
            var s1 = "abc";
            var s2 = "cbb";

            Assert.AreEqual(false, Question_1_2.AreStringsPermutationsDict(s1, s2));

            s1 = "aa";
            s2 = "aaa";

            Assert.AreEqual(false, Question_1_2.AreStringsPermutationsDict(s1, s2));
        }

        [TestMethod]
        public void Question_1_2_BasicSize_ReturnsFalse()
        {
            var s1 = "abc";
            var s2 = "cb";

            Assert.AreEqual(false, Question_1_2.AreStringsPermutationsDict(s1, s2));
        }

        [TestMethod]
        public void Question_1_2_EdgeCases_ReturnsFalse()
        {
            var s1 = (string)null;
            var s2 = string.Empty;

            Assert.AreEqual(false, Question_1_2.AreStringsPermutationsDict(s1, s2));
        }

        [TestMethod]
        public void Question_1_2_EdgeCases_ReturnsTrue()
        {
            var s1 = (string)null;
            var s2 = (string)null;

            Assert.AreEqual(true, Question_1_2.AreStringsPermutationsDict(s1, s2));

            s1 = string.Empty;
            s2 = string.Empty;

            Assert.AreEqual(true, Question_1_2.AreStringsPermutationsDict(s1, s2));

            s1 = "a";
            s2 = "a";

            Assert.AreEqual(true, Question_1_2.AreStringsPermutationsDict(s1, s2));
        }
    }
}
