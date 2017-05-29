namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System.CodeDom;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_7
    {
        [TestMethod]
        public void Question_8_7_BasicCases()
        {
            var s = "";
            Validate(s);
            s = "a";
            Validate(s);
            s = "abc";
            Validate(s);
            s = "aa";
            Validate(s);
            s = "aaaa";
            Validate(s);
            s = "aaabababaaabbbbb";
            Validate(s);
            s = "abcabcabc";
            Validate(s);
            s = "abcdabcdbababadcc";
            Validate(s);
            s = "abcd";
            Validate(s);
            s = "abcdef";
            Validate(s);
        }

        private void Validate(string input)
        {
            var permutations = new HashSet<string>();
            var result = Question_8_7.PermutationsWithoutDuplicates(input);
            var unique = RemoveDuplicates(input);
            var expectedCount = CountPerm(unique.Length);
            Assert.AreEqual(expectedCount, result.Count);
            foreach (var perm in result)
            {
                Assert.IsFalse(permutations.Contains(perm));
                permutations.Add(perm);
            }
        }

        private static string RemoveDuplicates(string s)
        {
            var result = "";
            var seen = new HashSet<char>();
            foreach (var c in s)
            {
                if (seen.Contains(c))
                {
                    continue;
                }

                seen.Add(c);
                result += c;
            }

            return result;
        }

        private static int CountPerm(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return CountPerm(n - 1) * n;
        }
    }
}
