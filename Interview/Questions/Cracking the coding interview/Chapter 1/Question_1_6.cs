namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// String Compression: Implement a method to perform basic string compression
    /// using the counts of repeated characters. For example, the string
    /// aabcccccaaa would become a2b1c5a3. If the "compressed" string would not become
    /// smaller than the original string, your method should return the original
    /// string. You can assume the string has only uppercase and lowercase letters (a - z).
    /// </summary>
    public class Question_1_6
    {
        public static string CompressString(string s)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < s.Length;)
            {
                var count = 1;
                for (var j = i + 1; j < s.Length && s[i] == s[j]; j++, count++)
                {
                    // intetionally empty
                }

                sb.Append("" + s[i] + count);
                i += count;
            }

            return sb.ToString().Length < s.Length ? sb.ToString() : s;
        }
    }
}
