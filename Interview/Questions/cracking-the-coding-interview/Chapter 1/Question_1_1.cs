namespace Questions.Cracking_the_Code.Chapter_1
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implement an algorithm to determine if a string has all unique
    /// characters. What if you cannot use additional data structures?
    /// </summary>
    public class Question_1_1
    {

        // Time: O(1)
        // Space: O(N)
        public static bool AllUniqueCharactersHash(string s)
        {
            if (s == null)
            {
                return true;
            }

            HashSet<char> characterSet = new HashSet<char>();
            foreach (var character in s)
            {
                if (characterSet.Contains(character))
                {
                    return false;
                }

                characterSet.Add(character);
            }

            return true;
        }

        // Time: (n log(n))
        // Space: O(1)
        public static bool AllUniqueCharactersNoAdditionalSpace(string s)
        {
            if (s == null)
            {
                return true;
            }

            var array = s.ToCharArray();

            // Array.Sort sorts an array in-place.
            Array.Sort(array);
            var orderedString = string.Concat(array);
            for (int i = 1; i < s.Length; i++)
            {
                if (orderedString[i - 1] == orderedString[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
