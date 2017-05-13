namespace Tests.Data_structure_helpers
{
    using System;

    public class BinaryHelpers
    {
        public static int IntFromBinary(string s)
        {
            return Convert.ToInt32(s, 2);
        }
    }
}
