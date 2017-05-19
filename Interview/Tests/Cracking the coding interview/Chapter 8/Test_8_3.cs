namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_3
    {
        [TestMethod]
        public void Question_8_3_BasicCases()
        {
            int [] array = new int[0];
            Validate(-1, array);

            array = new int[1] { 0 };
            Validate(0, array);

            array = new int[1] { 1 };
            Validate(-1, array);

            array = new int[5] { 2, 2, 2, 2, 2 };
            Validate(2, array);

            array = new int[5] { 2, 2, 1, 2, 2 };
            Validate(-1, array);

            array = new int[8] { 2, 2, 2, 2, 6, 6, 6, 6 };
            Validate(2, array);

            array = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Validate(-1, array);

            array = new int[8] { 1, 2, 3, 4, 5, 5, 7, 8 };
            Validate(5, array);
        }

        private static void Validate(int expected, int[] array)
        {
            var result = Question_8_3.GetMagicIndex(array);
            Assert.AreEqual(expected, result);
        }
    }
}
