namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;
    using Questions.Data_structures;

    [TestClass]
    public class Test_5_1
    {
        [TestMethod]
        public void Question_5_1_BasicCases()
        {
            int n = BinaryHelpers.IntFromBinary("11111111");
            int m = BinaryHelpers.IntFromBinary("101");
            int i = 2;
            int j = 4;
            int expected = BinaryHelpers.IntFromBinary("11110111");

            Validate(expected, n, m, i, j);

            i = 0;
            j = 2;
            expected = BinaryHelpers.IntFromBinary("11111101");
            Validate(expected, n, m, i, j);

            n = BinaryHelpers.IntFromBinary("10101010");
            m = BinaryHelpers.IntFromBinary("1000");
            j = 3;
            expected = BinaryHelpers.IntFromBinary("10101000");
            Validate(expected, n, m, i, j);

            i = 4;
            j = 7;
            expected = BinaryHelpers.IntFromBinary("10001010");
            Validate(expected, n, m, i, j);
        }

        private static  void Validate(int expected, int n, int m, int i, int j)
        {
            var result = Question_5_1.InsertBits(n, m, i, j);
            Assert.AreEqual(expected, result);
        }
    }
}
