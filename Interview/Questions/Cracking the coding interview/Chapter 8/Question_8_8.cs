namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Permutations with Dups: Write a method to compute all permutations of a string whose characters
    /// are not necessarily unique.The list of permutations should not have duplicates.
    /// </summary>
    public class Question_8_8
    {
        // Time: O(n^2 * n!)
        // space: O(n!)
        public static List<string> PermutationWithDuplicates(string input)
        {
            var set = new HashSet<char>();
            foreach (var c in input)
            {
                set.Add(c);
            }

            var list = set.ToList();
            var str = new string(list.ToArray());
            return Question_8_7.PermutationsWithoutDuplicates(str);
        }

    }
}
