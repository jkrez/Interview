namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_7
    {
        [TestMethod]
        public void Question_1_7_Basic()
        {
            // 2x2 matrix rotation
            //
            // 1 2  => 3 1
            // 3 4     4 2
            var image = MatrixHelpers.CreateTwoDimensionalMatrix(2, 2, '1', '2', '3', '4');
            var expected = MatrixHelpers.CreateTwoDimensionalMatrix(2, 2, '3', '1', '4', '2');

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "2x2");

            // 3x3 matrix rotation
            //
            // 1 2 3 => 7 4 1
            // 4 5 6    8 5 2
            // 7 8 9    9 6 3
            image = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, '1', '2', '3', '4', '5', '6', '7', '8');
            expected = MatrixHelpers.CreateTwoDimensionalMatrix(3, 3, '7', '4', '1', '8', '5', '2', '9', '6', '3');

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "3x3");

            image = new char[,] { { 'a', 'e', 'i', 'm' }, {'b','f','j','n'}, {'c','g','k','o'}, {'d','h','l','p'} };
            expected = new char[,] { { 'm', 'n', 'o', 'p' }, { 'i', 'j', 'k', 'l' }, { 'e','f','g','h'} , {'a','b','c','d'} };
            // 4x4 matrix rotation
            //
            // a b c d    m i e a
            // e f g h => n j f b
            // i j k l    o k g c
            // m n o p    p l h d
            image = MatrixHelpers.CreateTwoDimensionalMatrix(4, 4, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p');
            expected = MatrixHelpers.CreateTwoDimensionalMatrix(4, 4, 'm', 'i', 'e', 'a', 'n', 'j', 'f', 'b', 'o', 'k', 'g', 'c', 'p', 'l', 'h', 'd');

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "4x4");
        }

        [TestMethod]
        public void Question_1_7_EdgeCases()
        {
            var image = MatrixHelpers.CreateTwoDimensionalMatrix(1, 1, 'a');
            var expected = MatrixHelpers.CreateTwoDimensionalMatrix(1, 1, 'a');

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "1x1");
        }

        [TestMethod]
        public void Question_1_7_InavlidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_7.Rotate(null), typeof(ArgumentException));
        }
    }
}
