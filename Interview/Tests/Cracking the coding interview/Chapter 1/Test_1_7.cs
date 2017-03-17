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
            var image = new char [,] { {'1'}, {'2'} };
            Question_1_7.Rotate(image);
        }
    }
}
