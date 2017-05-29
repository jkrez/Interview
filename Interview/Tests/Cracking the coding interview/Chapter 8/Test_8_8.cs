namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_8
    {
        [TestMethod]
        public void Question_8_8_BasicCases()
        {
            var s = "";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "a";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "abc";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "aa";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "aaaa";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "aaabababaaabbbbb";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "abcabcabc";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "abcdabcdbababadcc";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "abcd";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
            s = "abcdef";
            Test_8_7.Validate(s, Question_8_8.PermutationWithDuplicates);
        }
    }
}
