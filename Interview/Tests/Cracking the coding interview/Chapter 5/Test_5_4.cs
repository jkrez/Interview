namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;

    [TestClass]
    public class Test_5_4
    {
        [TestMethod]
        public void Question_5_4_BasicCases()
        {
            int n = 1;
            int expectedNext = 2;
            int expectedPrev = -1;
            Validate(expectedNext, expectedPrev, n);

            n = 2;
            expectedNext = 4;
            expectedPrev = 1;
            Validate(expectedNext, expectedPrev, n);

            n = 3;
            expectedNext = 5;
            expectedPrev = -1;
            Validate(expectedNext, expectedPrev, n);

            n = 4;
            expectedNext = 8;
            expectedPrev = 2;
            Validate(expectedNext, expectedPrev, n);

            n = 5;
            expectedNext = 6;
            expectedPrev = 3;
            Validate(expectedNext, expectedPrev, n);

            n = 6;
            expectedNext = 9;
            expectedPrev = 5;
            Validate(expectedNext, expectedPrev, n);
        }

        private static void Validate(int expectedNext, int expectedPrev, int n)
        {
            var result = Question_5_4.GetNext(n);
            Assert.AreEqual(expectedNext, result);
            result = Question_5_4.GetPrevious(n);
            Assert.AreEqual(expectedPrev, result);
        }
    }
}
