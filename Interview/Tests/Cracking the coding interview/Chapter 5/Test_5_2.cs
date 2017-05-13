namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;

    [TestClass]
    public class Test_5_2
    {
        [TestMethod]
        public void Question_5_2_BasicCases()
        {
            double number = 0.625;
            string expected = ".101";
            Validate(expected, number);

            number = 0.375;
            expected = ".011";
            Validate(expected, number);

            number = 0.5;
            expected = ".1";
            Validate(expected, number);
        }

        private static void Validate(string expected, double number)
        {
            var result = Question_5_2.BinaryDecimalToString(number);
            Assert.AreEqual(expected, result);
        }
    }
}
