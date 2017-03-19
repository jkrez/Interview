namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// String Rotation: Assume you have a method isSubstring which checks
    /// if one word is a substring of another. Given two strings, 51 and 52,
    /// write code to check if 52 is a rotation of 51 using only one call to
    /// isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").
    ///
    /// Assume string.Contains is the call to isSubstring()
    /// </summary>
    public class Question_1_9
    {
        // Time: max of O(n) and O(isSubstring) - in this case O(n^2)
        // Spcae: O(n)
        public static bool IsRotation(string baseString, string rotation)
        {
            if (baseString == null || rotation == null)
            {
                throw new ArgumentNullException(@"Input string cannot be null.");
            }

            if (rotation.Length != baseString.Length)
            {
                return false;
            }

            var doubleBase = baseString + baseString;
            return Question_1_9.IsSubstring(doubleBase, rotation);
        }

        /// <summary>
        /// Potential IsSubstring implementation.
        /// Time: O(m * n)
        /// Space: O(1)
        /// </summary>
        internal static bool IsSubstring(string baseString, string searchString)
        {
            if (baseString == null || searchString == null)
            {
                throw new ArgumentNullException("Arguments cannot be null");
            }

            // The empty string should always be found
            if (searchString.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < baseString.Length; i++)
            {
                int j;
                for (j = 0; j < searchString.Length && i + j < baseString.Length; j++)
                {
                    if (baseString[i + j] != searchString[j])
                    {
                        break;
                    }
                }

                if (j == searchString.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
