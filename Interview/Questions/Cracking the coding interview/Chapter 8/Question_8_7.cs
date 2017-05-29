namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;

    /// <summary>
    /// Permutations without Dups: Write a method to compute all permutations of a string of unique
    /// characters.
    /// </summary>
    public class Question_8_7
    {
        // Time: O(n^2 * n!)
        // Space: O(n!)
        public static List<string> PermutationsWithoutDuplicates(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            var result = new List<string>();
            result.Add(string.Empty + input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                var temp = new List<string>();
                foreach (var str in result)
                {
                    for (int j = 0; j <= str.Length; j++)
                    {
                        temp.Add(str.Substring(0,j) +
                                 input[i] +
                                 str.Substring(j));
                    }
                }

                result = temp;
            }

            return result;
        }
    }
}
