namespace Tests.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_8;

    [TestClass]
    public class Test_8_6
    {
        [TestMethod]
        public void Question_8_6_BasicCases()
        {
            for (int stackHeight = 1; stackHeight < 10; stackHeight++)
            {
                var src = CreateStack(stackHeight);
                var dest = CreateStack(0);
                var temp = CreateStack(0);
                Validate(src, dest, temp);
            }
        }

        private static void Validate(Stack<int> src, Stack<int> dest, Stack<int> temp)
        {
            var size = src.Count;
            Question_8_6.MoveTower(src, dest, temp);
            Assert.AreEqual(0, src.Count);
            Assert.AreEqual(0, temp.Count);
            Assert.AreEqual(size, dest.Count);
            var destCopy = new Stack<int>(dest);
            var last = -1;
            while (destCopy.Count != 0)
            {
                var next = destCopy.Pop();
                Assert.IsTrue(last < next);
            }
        }

        private static Stack<int> CreateStack(int size)
        {
            var s = new Stack<int>();
            for (int i = 0; i < size; i++)
            {
                s.Push(size - i);
            }

            return s;
        }
    }
}
