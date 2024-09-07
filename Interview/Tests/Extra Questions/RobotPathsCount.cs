namespace Tests.Extra_Questions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Qualtrics;

    [TestClass]
    public class RobotPathsCount
    {
        [TestMethod]
        public void Extra_RobotCountPaths()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    Validate(i,j);
                }
            }
        }

        private static void Validate(int m, int n)
        {
            var expected = Factorial(m - 1 + n - 1) / (Factorial(m - 1) * Factorial(n - 1));
            var actual = RobotProblem.CountPaths(m, n);
            Assert.AreEqual(expected, actual);
        }

        private static Int64 Factorial(int n)
        {
            if (n == 1 || n == 0)
                return 1;

            return Factorial(n - 1) * n;
        }
    } 
}
