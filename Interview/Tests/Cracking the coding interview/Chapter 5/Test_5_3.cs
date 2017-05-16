namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;
    using Questions.Data_structures;

    [TestClass]
    public class Test_5_3
    {
        [TestMethod]
        public void Question_5_3_BasicCases()
        {
            var n = BinaryHelpers.IntFromBinary("010101010101");
            var expected = 3;
            Validate(expected, n);

            n = BinaryHelpers.IntFromBinary("000000000");
            expected = 1;
            Validate(expected, n);

            n = BinaryHelpers.IntFromBinary("110110110111011");
            expected = 6;
            Validate(expected, n);

            n = BinaryHelpers.IntFromBinary("11011011011001111001111");
            expected = 5;
            Validate(expected, n);

            n = BinaryHelpers.IntFromBinary("1010100110101011");
            expected = 4;
            Validate(expected, n);

        }

        public void Validate(int expected, int n)
        {
            var result = Question_5_3.FlipBit(n);
            Assert.AreEqual(expected, result);
        }
    }
}
