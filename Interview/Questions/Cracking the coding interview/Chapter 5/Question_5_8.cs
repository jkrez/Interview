namespace Questions.Cracking_the_coding_interview.Chapter_5
{
    using System;

    /// <summary>
    /// Draw Line: A monochrome screen is stored as a single array of bytes, allowing eight consecutive
    /// pixels to be stored in one byte. The screen has width w, where w is divisible by 8 (that is, no byte will
    /// be split across rows). The height of the screen, of course, can be derived from the length of the array
    /// and the width. Implement a function that draws a horizontal line from (xl, y) to (x2, y).
    /// </summary>
    public class Question_5_8
    {
        private const int byteSize = 8;

        public static void DrawScreen(byte[] screen, int width, int x1, int x2, int y)
        {
            if (screen == null)
            {
                throw new ArgumentNullException(nameof(screen));
            }

            if (width < sizeof(byte))
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if ((x1 < 0 || x2 < 0) ||
                (x1 >= width || x2 >= width) ||
                (x2 < x1))
            {
                throw new ArgumentOutOfRangeException("x1 and x2");
            }

            int start = y * width + x1;
            int end = y * width + x2;
            byte ones = 0xFF;
            int b = ones >> (x1 % byteSize);
            screen[start / byteSize] = (byte)b;
            int current = start + (byteSize - (start % byteSize));
            while (current < end)
            {
                screen[current / byteSize] = 0xFF;
                current += byteSize;
            }

            int bitsToRemove = (byteSize - 1) - (end % byteSize);
            b = -1 << bitsToRemove;
            screen[end / byteSize] &= (byte)b;
        }
    }
}
