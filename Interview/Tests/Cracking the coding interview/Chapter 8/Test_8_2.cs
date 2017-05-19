namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_2
    {
        [TestMethod]
        public void Question_8_2_BasicCases()
        {
            // Small maze tests
            var maze = new bool[1, 1]
            {
                { true }
            };
            Validate(true, maze);

            maze = new bool[1, 1]
            {
                { false }
            };
            Validate(false, maze);

            // Large maze validation.
            maze = new bool[10, 10]
            {
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
            };
            Validate(true, maze);

            maze = new bool[10, 10]
            {
                { true, true, false, true, true, true, true, true, true, true },
                { true, false, true, true, true, true, true, true, true, true },
                { false, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true, true, true, true },
            };
            Validate(false, maze);
        }

        private static void Validate(bool path, bool[,] maze)
        {
            var result = Question_8_2.GetPath(maze);
            Assert.AreEqual(path, result != null);
    }


    }
}
