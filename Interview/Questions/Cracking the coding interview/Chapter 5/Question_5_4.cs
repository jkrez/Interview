namespace Questions.Cracking_the_coding_interview.Chapter_5
{
    using System.Diagnostics;
    using System.Dynamic;
    using Data_structures;

    /// <summary>
    /// Next Number: Given a positive integer, print the next smallest and the next largest number that
    /// have the same number of 1 bits in their binary representation.
    /// Note: No negative numbers allowed to be returned. Negative numbers means an error occured.
    /// </summary>
    public class Question_5_4
    {
        // Time: O(n) where n is number of bits
        // Space: O(1)
        public static int GetNext(int n)
        {
            int temp = n;
            int trailingZeros = 0;
            int trailingOnesAfterZero = 0;
            while (((temp & 1) == 0) && (temp != 0))
            {
                trailingZeros++;
                temp >>= 1;
            }

            while ((temp & 1) == 1)
            {
                trailingOnesAfterZero++;
                temp >>= 1;
            }

            if (trailingOnesAfterZero + trailingZeros == 0 ||
                trailingOnesAfterZero + trailingZeros == 31)
            {
                return -1;
            }

            int rightMostNonTralingZero = trailingOnesAfterZero + trailingZeros;

            // Flip rightMostNonTralingZero.
            n = BinaryHelpers.SetBit(n, rightMostNonTralingZero);

            // Clear all bits below fliped bit.
            n &= ~((1 << rightMostNonTralingZero) - 1);

            // Add back in number of ones cleared.
            n |= (1 << (trailingOnesAfterZero - 1)) - 1;

            return n;
        }

        // Time: O(n) where n is number of bits
        // Space: O(1)
        public static int GetPrevious(int n)
        {
            int temp = n;
            int trailingOnes = 0;
            int trailingZerosAfterOnes = 0;

            while ((temp & 1) == 1)
            {
                trailingOnes++;
                temp >>= 1;
            }

            while ((temp & 1) == 0 && temp != 0)
            {
                trailingZerosAfterOnes++;
                temp >>= 1;
            }

            if (trailingZerosAfterOnes == 0 ||
                trailingZerosAfterOnes + trailingOnes == 31)
            {
                return -1;
            }

            int rightMostNonTrailingOne = trailingZerosAfterOnes + trailingOnes;

            // Clear right most non trailing 1.
            n = BinaryHelpers.ClearBit(n, rightMostNonTrailingOne);

            // Set all ones below cleared bit.
            n |= (1 << rightMostNonTrailingOne) - 1;

            // Add back zeros in least significat bits.
            n &= -1 << (trailingZerosAfterOnes -1);

            return n;
        }
    }
}
