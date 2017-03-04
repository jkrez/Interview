namespace Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Random.Code;

    [TestClass]
    public class AtLeastOneDuplicateTests
    {
        [TestMethod]
        public void O1Space_Returns1()
        {
            const int expected = 1;
            var actual = AtLeastOneDuplicate.ReturnDuplicateO1Space(new List<int> { 1, 1, 2, 2, 3 }); 
            Assert.AreEqual(expected, actual);
        }
    }
}
