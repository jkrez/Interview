namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
    /// A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a 
    /// rearrangement of letters. The palindrome does not need to be limited to just dictionary words. 
    /// Ex:
    /// Input: Tact Coa 
    /// Output: True (permutations: "taco cat". "atco cta". etc.)
    ///
    /// Assume the empty string is a palindrome.
    /// </summary>
    public class Question_1_4
    {
        // Time: O(n)
        // Space: O(n)
        public static bool IsPalindromePermutationFast(string s)
        {
            ValidateInput(s);

            // hash every letter
            var letters = new Dictionary<char, int>();
            var spaceCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == ' ')
                {
                    spaceCount++;
                }
                else
                {
                    if (letters.ContainsKey(c))
                    {
                        letters[c]++;
                    }
                    else
                    {
                        letters.Add(c, 1);
                    }
                }
            }

            // Iterate over dictonary to see if there is a palindrom possible
            // Palindromes are only possible if there is an odd number of characters
            // and a single unpaired character or there is no unpaired character and
            // an even number of letters.

            var hasOdd = false;
            foreach (var kvp in letters)
            {
                if (kvp.Value % 2 != 0)
                {
                    if (!hasOdd)
                    {
                        hasOdd = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void ValidateInput(string s)
        {
            if (s == null)
            {
                throw new ArgumentException(nameof(s));
            }

            // Ignore strigs that don't contian letters or the space char.
            // Assume that this is O(N) runtime.
            Regex r = new Regex("^[a-zA-Z ]*$");
            if (!r.IsMatch(s))
            {
                throw new ArgumentException(nameof(s));
            }
        }

        // Time: O(n log(n))
        // Space: O(1)
        public static bool IsPalinromePermutationMinSpace(string s)
        {
            ValidateInput(s);

            var array = s.ToCharArray();
            Array.Sort(array);
            var hasOdd = false;
            for (var i = 0; i < array.Length; i++)
            {
                var currentChar = array[i];
                if (currentChar == ' ')
                {
                    continue;
                }

                var count = 1;
                for (var j = i + 1; 
                    (j < array.Length) && (currentChar == array[j]);
                    j++, count++)
                {
                    // Intentionally Empty
                }

                if (count % 2 != 0)
                {
                    if (hasOdd)
                    {
                        return false;
                    }

                    hasOdd = true;
                }

                i += count - 1;
            }

            return true;
        }
    }
}
