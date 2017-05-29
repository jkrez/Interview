namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Permutations without Dups: Write a method to compute all permutations of a string of unique
    /// characters.
    /// </summary>
    public class Question_8_7
    {
        // Time: O(n^2 * n!)
        // Space: O(n^2 * n!)
        public static List<string> PermutationsWithoutDuplicates(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            var set = new HashSet<char>();
            foreach (var c in input)
            {
                set.Add(c);
            }

            var result = new List<string>();
            var list = set.ToList();
            result.Add(string.Empty + list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                var temp = new List<string>();
                foreach (var str in result)
                {
                    for (int j = 0; j <= str.Length; j++)
                    {
                        temp.Add(str.Substring(0,j) +
                                 list[i] +
                                 str.Substring(j));
                    }
                }

                result = temp;
            }

            return result;
        }
    }
}
