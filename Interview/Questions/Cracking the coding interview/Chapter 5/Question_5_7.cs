namespace Questions.Cracking_the_coding_interview.Chapter_5
{
    /// <summary>
    /// Pairwise Swap: Write a program to swap odd and even bits in an integer with as few instructions as
    /// possible(e.g., bit 0 and bit 1 are swapped, bit 2 and bit 3 are swapped, and so on). 
    /// </summary>
    public class Question_5_7
    {
        private const int oddMask = 0x55555555;
        private const int evenMask = oddMask << 1;

        public static int SwapBits(int n)
        {
            return ((n & evenMask) >> 1) | ((n & oddMask) << 1);
        }
    }
}
