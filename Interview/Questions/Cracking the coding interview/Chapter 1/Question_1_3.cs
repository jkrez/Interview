namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Xml.Schema;

    /// <summary>
    /// URLify: Write a method to replace all spaces in a string with '%20: You may assume that the string has sufficient space at the end to hold the additional characters, and that you are given the "true" length of the string. (Note: If implementing in Java, please use a character array so that you can perform this operation in place.) 
    /// EXAMPLE:
    ///     Input: "Mr John Smith "J 13 
    ///     Output: "Mr%20John%20Smith" 
    /// </summary>
    public class Question_1_3
    {

        // Time: O(n)
        // Space: O(n)
        public static string EscapeString(string s)
        {
            if (s == null)
            {
                throw new ArgumentException();
            }

            string ret = string.Empty;
            foreach (var c in s)
            {
                if (c == ' ')
                {
                    ret = string.Concat(ret, "%20");
                }
                else
                {
                    ret = string.Concat(ret, c);
                }
            }

            return ret;
        }

        public static void EscapeStringInplace(char[] inputString, int length)
        {
            if (inputString == null || length < 0)
            {
                throw new ArgumentException();
            }

            int spaceCount = 0;
            for (int i = 0; i < length; i++)
            {
                if (inputString[i] == ' ')
                {
                    spaceCount++;
                }
            }

            // Calculate new string length
            int newLength = length + (spaceCount * 2);

            for (int i = newLength - 1, j = length - 1; i >= 0; i--, j--)
            {
                if (inputString[j] == ' ')
                {
                    inputString[i-2] = '%';
                    inputString[i-1] = '2';
                    inputString[i] = '0';
                    i -= 2;
                }
                else
                {
                    inputString[i] = inputString[j];
                }
            }
        }
    }
}
