using System.Runtime.Versioning;

namespace Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Random.Code;

    [TestClass]
    public class AtLeastOneDuplicateTests
    {

        public delegate int ReturnDuplicate(List<int> list);

        [TestMethod]
        public void O1Space_Returns1()
        {
            BasicTests(AtLeastOneDuplicate.ReturnDuplicateO1Space);
        }

        private static void BasicTests(ReturnDuplicate fn)
        {
            Assert.AreEqual(1, fn(new List<int> {1, 1, 2, 2, 3}));
            Assert.AreEqual(1, fn(new List<int> { 1, 4, 2, 1, 3 })); 
            Assert.AreEqual(4, fn(new List<int> { 4, 4, 2, 1, 3 }));
            Assert.AreEqual(3, fn(new List<int> { 3, 4, 2, 1, 3 }));
            Assert.AreEqual(2, fn(new List<int> { 1, 4, 2, 2, 3 }));
            Assert.AreEqual(3, fn(new List<int> { 1, 4, 3, 1, 3 }));
            Assert.AreEqual(1, fn(new List<int> { 1, 2, 3, 1 }));
            Assert.AreEqual(1, fn(new List<int> { 1, 2, 2, 1 }));
            Assert.AreEqual(2, fn(new List<int> { 1, 2, 3, 2 }));
            Assert.AreEqual(1, fn(new List<int> { 1, 3, 3, 1 }));
        }
    }
}
