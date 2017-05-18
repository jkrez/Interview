namespace Tests.Cracking_the_coding_interview
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview;

    [TestClass]
    public class Test_8_1
    {
        [TestMethod]
        public void Question_8_1_BasicCases()
        {
            Validate(1, 0);
            Validate(2, 1);
            Validate(4, 2);
            Validate(7, 3);
            Validate(13, 4);
            Validate(24, 5);

        }

        [TestMethod]
        public void Question_8_1_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_8_1.NumberOfWays(-1), typeof(ArgumentOutOfRangeException));
        }

        private static void Validate(int expected, int numberOfSteps)
        {
            var result = Question_8_1.NumberOfWays(numberOfSteps);
            Assert.AreEqual(expected, result);
        }
    }
}
