namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;
    using Questions.Data_structures;

    [TestClass]
    public class Test_8_10
    {
        [TestMethod]
        public void Question_8_10_BasicCases()
        {
            // Fill with same color
            var image = new int[10, 10];
            var expectedImage = (int[,])image.Clone();
            var point = new Point(5,5);
            var color = image[point.Row, point.Column];
            Question_8_10.ColorFill(point, image, color);
            TestHelpers.AssertMatricesEqual(expectedImage, image);

            image = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            expectedImage = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2);
            point = new Point(1,1);
            Question_8_10.ColorFill(point, image, 2);
            TestHelpers.AssertMatricesEqual(expectedImage, image);

            image = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            expectedImage = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2);
            point = new Point(0, 0);
            Question_8_10.ColorFill(point, image, 2);
            TestHelpers.AssertMatricesEqual(expectedImage, image);

            image = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 2, 2, 2, 3, 4, 5);
            expectedImage = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 6, 6, 6, 3, 4, 5);
            point = new Point(1, 1);
            Question_8_10.ColorFill(point, image, 6);
            TestHelpers.AssertMatricesEqual(expectedImage, image);

            image = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 2, 2, 2, 3, 4, 5);
            expectedImage = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, 1, 1, 1, 2, 2, 2, 3, 6, 5);
            point = new Point(2, 1);
            Question_8_10.ColorFill(point, image, 6);
            TestHelpers.AssertMatricesEqual(expectedImage, image);
        }

        [TestMethod]
        public void Question_8_10_InavlidCases()
        {
            var p = new Point(0,-1);
            var i = new int[1, 1];
            TestHelpers.AssertExceptionThrown(() => Question_8_10.ColorFill(p, i, 1), typeof(ArgumentOutOfRangeException));
            TestHelpers.AssertExceptionThrown(() => Question_8_10.ColorFill(p, null, 1), typeof(ArgumentNullException));
        }
    }
}
