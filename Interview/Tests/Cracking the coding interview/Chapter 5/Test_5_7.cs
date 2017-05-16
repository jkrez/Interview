namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;

    [TestClass]
    public class Test_5_7
    {
        [TestMethod]
        public void Question_5_7_BasicCases()
        {
            var n = 1;
            var expected = 2;
            Validate(expected, n);

            n = 2;
            expected = 1;
            Validate(expected, n);

            n = 3;
            expected = 3;
            Validate(expected, n);

            n = 4;
            expected = 8;
            Validate(expected, n);

            n = 5;
            expected = 10;
            Validate(expected, n);

        }

        private void Validate(int expected, int n)
        {
            var result = Question_5_7.SwapBits(n);
            Assert.AreEqual(expected, result);
        }
    }
}
