namespace Tests.Extra
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Extra;

    [TestClass]
    public class Test_AtLeastOneDuplicate
    {

        public delegate int ReturnDuplicate(List<int> list);

        [TestMethod]
        public void Extra_CheckDuplicatesO1Space_Basic()
        {
            BasicTests(AtLeastOneDuplicate.ReturnDuplicateO1Space);
        }

        [TestMethod]
        public void Extra_CheckDuplicatesFast_Basic()
        {
            BasicTests(AtLeastOneDuplicate.ReturnDuplicateFast);
        }

        [TestMethod]
        public void Extra_CheckDuplicatesO1Space_EdgeCases()
        {
            BasicTests(AtLeastOneDuplicate.ReturnDuplicateO1Space);
        }

        [TestMethod]
        public void Extra_CheckDuplicatesFast_EdgeCases()
        {
            BasicTests(AtLeastOneDuplicate.ReturnDuplicateFast);
        }

        private static void BasicTests(ReturnDuplicate fn)
        {
            Assert.AreEqual(1, fn(new List<int> { 1, 1, 2, 2, 3 }));
            Assert.AreEqual(1, fn(new List<int> { 1, 4, 2, 1, 3 }));
            Assert.AreEqual(4, fn(new List<int> { 4, 4, 2, 1, 3 }));
            Assert.AreEqual(3, fn(new List<int> { 3, 4, 2, 1, 3 }));
            Assert.AreEqual(2, fn(new List<int> { 1, 4, 2, 2, 3 }));
            Assert.AreEqual(1, fn(new List<int> { 1, 2, 3, 1 }));
            Assert.AreEqual(2, fn(new List<int> { 1, 2, 3, 2 }));
        }

        private static void EdgeCases(ReturnDuplicate fn)
        {
            Assert.AreEqual(1, fn(new List<int> { 1, 1 }));
            Assert.AreEqual(1, fn(new List<int> { 1, 1, 2 }));
            Assert.AreEqual(1, fn(new List<int> { 2, 1, 2 }));
        }
    }
}
