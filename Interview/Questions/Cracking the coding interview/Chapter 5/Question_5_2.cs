namespace Questions.Cracking_the_coding_interview.Chapter_5
{
    using System;
    using System.Text;

    /// <summary>
    /// Binary to String: Given a real number between 8 and 1 (e.g., 0.72) that is passed in as a double,
    /// print the binary representation.If the number cannot be represented accurately in binary with at
    /// most 32 characters, print "ERROR:' 
    /// </summary>
    public class Question_5_2
    {
        public static string BinaryDecimalToString(double number)
        {
            if (number >= 1 || number < 0)
            {
                throw new ArgumentException(nameof(number));
            }

            var sb = new StringBuilder();
            sb.Append(".");
            while (number > 0)
            {
                if (sb.Length > 32)
                {
                    throw new InvalidOperationException("Number is too long.");
                }

                var next = number * 2; // Shift over bits
                if (next >= 1)
                {
                    sb.Append("1");
                    number = next - 1;
                }
                else
                {
                    sb.Append("0");
                    number = next;
                }
            }

            return sb.ToString();
        }
    }
}
