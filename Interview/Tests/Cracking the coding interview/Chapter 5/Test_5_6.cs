namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;

    [TestClass]
    public class Test_5_6
    {
        [TestMethod]
        public void Question_5_6_BasicCases()
        {
            int expected = 2;
            int a = 29;
            int b = 15;
            Validate(expected, a, b);

            a = 0;
            expected = 4;
            Validate(expected, a, b);

            a = 1;
            expected = 3;
            Validate(expected, a, b);

            a = 3;
            expected = 2;
            Validate(expected, a, b);

            a = 4;
            expected = 3;
            Validate(expected, a, b);

            a = 16;
            expected = 5;
            Validate(expected, a, b);
        }

        private static void Validate(int expected, int a, int b)
        {
            var result = Question_5_6.ConversionCount(a, b);
            Assert.AreEqual(expected, result);
            result = Question_5_6.ConversionCount(b, a);
            Assert.AreEqual(expected, result);
        }
    }
}
