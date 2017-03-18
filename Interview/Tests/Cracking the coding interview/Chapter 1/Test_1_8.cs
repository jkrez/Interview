namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Linq;
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
            this.ValidateResult(expected, matrix);

            // Zero in the middle
            // 1 1 1
            // 1 1 1
            // 1 1 1
            var matrix2 = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            var expected2 = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            this.ValidateResult(expected2, matrix2);

            // Zero in the middle
            // 0 1 1 1
            // 1 1 1 1
            // 1 1 1 1
            var matrix3 = MatrixHelpers.CreateTwoDimensionalMatrix(3, 4, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            var expected3 = MatrixHelpers.CreateTwoDimensionalMatrix(3, 4, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1);
            this.ValidateResult(expected3, matrix3);
        }

        [TestMethod]
        public void Question_1_8_EdgeCases()
        {
            // Zero in the middle
            // 0
            var matrix = MatrixHelpers.CreateTwoDimensionalMatrix(1, 1, 0);
            var expected = MatrixHelpers.CreateTwoDimensionalMatrix(1, 1, 0);
            this.ValidateResult(expected, matrix);
        }

        [TestMethod]
        public void Question_1_8_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_8.PropogateZeros(null), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_1_8.PropogateZerosInPlace(null), typeof(ArgumentNullException));
        }

        private void ValidateResult(int[,] expected, int[,] input)
        {
            var inputCopy = MatrixHelpers.CreateTwoDimensionalMatrix(input.GetLength(0), input.GetLength(1), input.Cast<int>().ToArray());
            Question_1_8.PropogateZeros(input);
            TestHelpers.AssertMatricesEqual(expected, input);
            Question_1_8.PropogateZerosInPlace(inputCopy);
            TestHelpers.AssertMatricesEqual(expected, inputCopy);

        }
    }
}
