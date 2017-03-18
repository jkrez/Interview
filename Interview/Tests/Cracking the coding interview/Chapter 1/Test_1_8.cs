namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Win32.SafeHandles;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_8
    {
        [TestMethod]
        public void Question_1_8_Basic()
        {
            // Zero in the middle
            // 1 1 1
            // 1 0 1
            // 1 1 1
            var matrix = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 1, 0, 1, 1, 1, 1);
            var expected = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 0, 1, 0, 0, 0, 1, 0, 1);
            Question_1_8.PropogateZeros(matrix);
            TestHelpers.AssertMatricesEqual(expected, matrix);
        }
    }
}
