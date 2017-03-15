namespace Tests.Cracking_the_coding_interview.Chapter_1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_1;

    [TestClass]
    public class Test_1_6
    {
        [TestMethod]
        public void Test_1_6_Basic()
        {
            Assert.AreEqual("abbb", Question_1_6.CompressString("abbb"));
            Assert.AreEqual("a1b4", Question_1_6.CompressString("abbbb"));
            Assert.AreEqual("a1b4c1d3", Question_1_6.CompressString("abbbbcddd"));
            Assert.AreEqual("abbbbcdd", Question_1_6.CompressString("abbbbcdd"));
        }
    }
}
