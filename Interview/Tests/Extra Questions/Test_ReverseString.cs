﻿namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_ReverseString
    {
        [TestMethod]
        public void Extra_ReverseString_Basic()
        {
            var s1 = "abc";
            var s2 = "abcd";
            var s3 = "this is a really long string";

            Assert.AreEqual(new string(s1.Reverse().ToArray()), ReverseString.Reverse(s1));
            Assert.AreEqual(new string(s2.Reverse().ToArray()), ReverseString.Reverse(s2));
            Assert.AreEqual(new string(s3.Reverse().ToArray()), ReverseString.Reverse(s3));
        }

        [TestMethod]
        public void Extra_ReverseString_EdgeCases()
        {
            var s1 = string.Empty;
            var s2 = (string) null;
            var s3 = "a";

            Assert.AreEqual(new string(s1.Reverse().ToArray()), ReverseString.Reverse(s1));
            Assert.AreEqual(null, ReverseString.Reverse(s2));
            Assert.AreEqual(new string(s3.Reverse().ToArray()), ReverseString.Reverse(s3));
        }
    }
}
