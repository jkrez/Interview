namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_4
    { 
        [TestMethod]
        public void Question_8_4_BasicCases()
        {
            var set = new List<int>();
            var expected = new List<List<int>>()
            {
                new List<int>()
            };

            Validate(expected, set);
            set = new List<int>() { 1, 2, 3 };
            expected = new List<List<int>>()
            {
                new List<int>(),
                new List<int>() { 1 },
                new List<int>() { 2 },
                new List<int>() { 3 },
                new List<int>() { 1, 2 },
                new List<int>() { 1, 3 },
                new List<int>() { 2, 3 },
                new List<int>() { 1, 2, 3 },
            };

            Validate(expected, set);
        }

        [TestMethod]
        public void Question_8_4_InvalidCases()
        {
            var set = new List<int>(Enumerable.Range(0, 33));
            TestHelpers.AssertExceptionThrown(() => Question_8_4.Powerset(set).ToList(), typeof(ArgumentOutOfRangeException));
        }

        private static void Validate(List<List<int>> expected, List<int> set)
        {
            var result = Question_8_4.Powerset(set).ToList();
            Assert.AreEqual(expected.Count, result.Count);
            foreach (var subset in expected)
            {
               result.Remove(result.Find(s => s.SequenceEqual(subset)));
            }

            Assert.AreEqual(0, result.Count);
        }
    }
}
