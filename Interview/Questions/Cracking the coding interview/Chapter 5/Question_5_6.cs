namespace Questions.Cracking_the_coding_interview.Chapter_5
{
    /// <summary>
    ///  Conversion: Write a function to determine the number of bits you would need to flip to convert
    /// integer A to integer B.
    /// </summary>
    public class Question_5_6
    {
        // Time: O(n) where n is number of bits
        // Space: O(1)
        public static int ConversionCount(int a, int b)
        {
            var diff = a ^ b;
            var count = 0;
            while (diff != 0)
            {
                if ((diff & 1) != 0)
                {
                    count++;
                }

                diff >>= 1;
            }

            return count;
        }
    }
}
