namespace Tests.Cracking_the_coding_interview.Chapter_5
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.Cracking_the_coding_interview.Chapter_5;

    [TestClass]
    public class Test_5_8
    {
        [TestMethod]
        public void Question_5_8_BasicCases()
        {
            // One bit line tests.
            var height = 8;
            var width = 24;
            var screen = new byte[width/8 * height];
            screen[2 * width/8] = 0x18;
            Validate(screen, width, 3, 4, 2);

            screen = new byte[width / 8 * height];
            screen[(2 * width / 8) + 1] = 0xC0;
            Validate(screen, width, 8, 9, 2);

            screen = new byte[width / 8 * height];
            screen[(7 * width / 8) + 2] = 0x01;
            Validate(screen, width, 23, 23, 7);

            // Multi bit line tests
            screen = new byte[width / 8 * height];
            screen[(7 * width / 8) + 2] = 0xFF;
            Validate(screen, width, 16, 23, 7);

            screen = new byte[width / 8 * height];
            screen[(7 * width / 8)] = 0xFF;
            Validate(screen, width, 0, 7, 7);

            screen = new byte[width / 8 * height];
            screen[0] = 0xFF;
            screen[1] = 0xFF;
            screen[2] = 0xFF;
            Validate(screen, width, 0, 23, 0);

            screen = new byte[width / 8 * height];
            screen[0] = 0xFF;
            screen[1] = 0xF0;
            Validate(screen, width, 0, 11, 0);
        }

        [TestMethod]
        public void Question_5_8_InvalidCases()
        {
            TestHelpers.AssertExceptionThrown(() => Question_5_8.DrawScreen(null, 8, 1, 2, 3), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question_5_8.DrawScreen(new byte[100], 1, 1, 2, 3), typeof(ArgumentOutOfRangeException));
            TestHelpers.AssertExceptionThrown(() => Question_5_8.DrawScreen(new byte[100], 8, -1, 2, 3), typeof(ArgumentOutOfRangeException));
            TestHelpers.AssertExceptionThrown(() => Question_5_8.DrawScreen(new byte[100], 8, 1000, 2, 3), typeof(ArgumentOutOfRangeException));
        }

        private void Validate(byte[] expected, int width, int x1, int x2, int y)
        {
            byte[] screen = new byte[expected.Length];
            Question_5_8.DrawScreen(screen, width, x1, x2, y);
            CollectionAssert.AreEqual(expected, screen);
        }
    }
}
