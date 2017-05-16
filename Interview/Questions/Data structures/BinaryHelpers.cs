namespace Questions.Data_structures
{
    using System;

    public class BinaryHelpers
    {
        public static int IntFromBinary(string s)
        {
            return Convert.ToInt32(s, 2);
        }

        public static int SetBit(int n, int index)
        {
            int mask = 1 << index;
            n |= mask;
            return n;
        }

        public static int ClearBit(int n, int index)
        {
            int mask = ~(1 << index);
            n &= mask;
            return n;
        }
    }
}
