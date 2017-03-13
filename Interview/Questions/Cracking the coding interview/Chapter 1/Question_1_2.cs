namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Given two strings, write a method to decide if one is a permutation of the other. 
    /// </summary>
    public class Question_1_2
    {

        // Time: O(n log n)
        // Space: O(1)
        public static bool AreStringsPermutationsSort(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                return s1 == s2;
            }

            var order1 = string.Concat(s1.OrderBy(c => c));
            var order2 = string.Concat(s1.OrderBy(c => c));

            return order1.Equals(order2);
        }

        // Time: O(n)
        // Space: O(n)
        public static bool AreStringsPermutationsDict(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                return s1 == s2;
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var c in s1)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach (var c in s2)
            {
                int value;
                if (dict.TryGetValue(c, out value))
                {
                    value--;
                    if (value < 0)
                    {
                        return false;
                    }

                    dict[c] = value;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
