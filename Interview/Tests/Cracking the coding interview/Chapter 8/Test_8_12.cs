namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_12
    {
        [TestMethod]
        public void Question_8_12_BasicCases()
        {
            var boardSize = 8;
            var expected = 92;
            var result = Question_8_12.PlaceQueensWays(boardSize, 0, new bool[boardSize, boardSize], new bool[boardSize],
                new bool[boardSize*2], new bool[boardSize*2]);

            Assert.AreEqual(expected, result);
        }
    }
}
