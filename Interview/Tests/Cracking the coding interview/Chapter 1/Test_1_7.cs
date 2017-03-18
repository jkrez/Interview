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
            var image = new char [,] { {'1', '4'},
                                       {'2', '3'} };

            var expected = new char[,] { {'4', '3'},
                                         {'1', '2'} };

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "2x2");

            image = new char[,] { {'1', '4', '7'}, {'2', '5', '8'}, {'3', '6', '9'} };
            expected = new char[,] { { '7', '8', '9' }, { '4', '5', '6' }, { '1', '2', '3' } };

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "3x3");

            image = new char[,] { { 'a', 'e', 'i', 'm' }, {'b','f','j','n'}, {'c','g','k','o'}, {'d','h','l','p'} };
            expected = new char[,] { { 'm', 'n', 'o', 'p' }, { 'i', 'j', 'k', 'l' }, { 'e','f','g','h'} , {'a','b','c','d'} };

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(expected, image, "4x4");
        }

        [TestMethod]
        public void Question_1_7_EdgeCases()
        {
            var image = new char[1, 1];
            image[0, 0] = 'a';

            Question_1_7.Rotate(image);
            TestHelpers.AssertMatricesEqual(image, image, "1x1");
        }

        [TestMethod]
        public void Question_1_7_InavlidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_1_7.Rotate(null), typeof(ArgumentException));
        }
    }
}
