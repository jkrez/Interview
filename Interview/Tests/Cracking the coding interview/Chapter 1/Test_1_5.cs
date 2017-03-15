namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_5
    {
        [TestMethod]
        public void Question_1_5_Basic()
        {
            Assert.AreEqual(true, Question_1_5.IsOneAway("pale", "ple"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("pales", "pales"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("pale", "bale"));
            Assert.AreEqual(false, Question_1_5.IsOneAway("pale", "bake"));
            Assert.AreEqual(false, Question_1_5.IsOneAway("pale", "ples"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("pale", "pal"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("pale", "ale"));
        }

        [TestMethod]
        public void Question_1_5_EdgeCase()
        {
            Assert.AreEqual(true, Question_1_5.IsOneAway("p", "pp"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("pp", "p"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("p", "p"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("p", "a"));
            Assert.AreEqual(true, Question_1_5.IsOneAway("ab", "c"));
        }

        [TestMethod]
        public void Question_1_5_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_5.IsOneAway("", "s"), typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => Question_1_5.IsOneAway(null, "s"), typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => Question_1_5.IsOneAway(null, null), typeof(ArgumentException));
            TestHelpers.AssertExceptionThrown(() => Question_1_5.IsOneAway("\t", "s"), typeof(ArgumentException));
        }
    }
}
