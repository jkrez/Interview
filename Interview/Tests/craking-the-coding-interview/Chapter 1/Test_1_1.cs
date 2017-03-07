namespace Tests.Cracking_the_Code.Chapter_1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Random.Cracking_the_Code.Chapter_1;

    [TestClass]
    public class Test_1_1
    {
        [TestMethod]
        public void Question_1_1_Solution1_ReturnsFalse()
        {
            const string s = "test";
            const bool expected = false;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersHash(s));
        }

        [TestMethod]
        public void Question_1_1_Solution2_ReturnsFalse()
        {
            const string s = "test";
            const bool expected = false;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersNoAdditionalSpace(s));
        }

        [TestMethod]
        public void Question_1_1_Solution1_ReturnsTrue()
        {
            const string s = "tea";
            const bool expected = true;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersHash(s));
        }

        [TestMethod]
        public void Question_1_1_Solution2_ReturnsTrue()
        {
            const string s = "tea";
            const bool expected = true;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersNoAdditionalSpace(s));
        }

        [TestMethod]
        public void Question_1_1_Solution1_EmptyString_ReturnsTrue()
        {
            const string s = "";
            const bool expected = true;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersHash(s));
        }

        [TestMethod]
        public void Question_1_1_Solution2_EmptyString_ReturnsTrue()
        {
            const string s = "";
            const bool expected = true;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersNoAdditionalSpace(s));
        }

        [TestMethod]
        public void Question_1_1_Solution1_NullString_ReturnsTrue()
        {
            const string s = null;
            const bool expected = true;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersHash(s));
        }

        [TestMethod]
        public void Question_1_1_Solution2_NullString_ReturnsTrue()
        { 
            const string s = null;
            const bool expected = true;

            Assert.AreEqual(expected, Question_1_1.AllUniqueCharactersNoAdditionalSpace(s));
        }
    }
}
