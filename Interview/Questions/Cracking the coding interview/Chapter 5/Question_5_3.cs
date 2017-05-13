namespace Questions.Cracking_the_coding_interview.Chapter_5
{
    using System;

    public class Question_5_3
    {
        public static int FlipBit(int n)
        {
            if (n == -1)
            {
                return Convert.ToString(-1, 2).Length;
            }

            var currentSequenceLength = 0;
            var previousSequenceLength = 0;
            var maxSequenceLength = 1;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    currentSequenceLength++;
                }
                else
                {
                    if ((currentSequenceLength + previousSequenceLength + 1) > maxSequenceLength)
                    {
                        maxSequenceLength = currentSequenceLength + previousSequenceLength + 1;
                    }

                    previousSequenceLength = currentSequenceLength;
                    currentSequenceLength = 0;
                }

                n >>= 1;
            }

            return maxSequenceLength;
        }
    }
}
