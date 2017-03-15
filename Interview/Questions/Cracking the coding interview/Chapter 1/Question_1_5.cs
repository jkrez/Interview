namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Reflection;
    using System.Runtime.Remoting.Metadata.W3cXsd2001;

    /// <summary>
    /// One Away: There are three types of edits that can be performed on strings:
    /// insert a character, remove a character, or replace a character. Given two
    /// strings, write a function to check if they are one edit (or zero edits) away.
    /// 
    /// Example:
    /// pale, ple -> true
    /// pales, pale -> true
    /// pale, bale -> true
    /// pale, bake -> false
    /// </summary>
    public class Question_1_5
    {
        // Time: O(n)
        // Space: O(1)
        public static bool IsOneAway(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
            {
                throw new ArgumentException("Input can't be null or empty");
            }

            if (Math.Max(s1.Length, s2.Length) - Math.Min(s1.Length, s2.Length) > 1)
            {
                return false;
            }

            var equalLength = s1.Length == s2.Length;
            var operationDone = false;
            for (int i = 0, j = 0; i < s1.Length && j < s2.Length; i++, j++)
            {
                if (i > s2.Length || j > s1.Length || s1[i] != s2[j])
                {
                    if (operationDone)
                    {
                        return false;
                    }

                    // "Replace character"
                    if (equalLength)
                    {
                        operationDone = true;
                    }
                    else
                    {
                        // Remove char from longer string or add character to shorter string
                        if (s1.Length > s2.Length)
                        {
                            i++;
                        }
                        else
                        {
                            j++;
                        }

                        operationDone = true;
                    }
                }
            }

            return true;
        }
    }
}
