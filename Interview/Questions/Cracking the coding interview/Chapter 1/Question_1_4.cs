namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words. 
    /// Ex
    /// Input: Tact Coa 
    /// Output: True (permutations: "taco cat". "atco cta". etc.) 
    /// 
    /// Open ended parts to the question:
    /// - are spaces assumed to not move?
    /// </summary>
    public class Question_1_4
    {
        public static bool IsPalindromePermutation(string s)
        {
            // Ignore strigs that aren't contian numbers, tabs, etc. 

            Regex r = new Regex("^[a-zA-Z ]*$");
            if (!r.IsMatch(s))
            {
                throw new ArgumentException(nameof(s));
            }

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

            // Ignore empty strings or whitespace only strings
            var letterCount = spaceCount - s.Length;
            if (letterCount == 0)
            {
                return false;
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
    }
}
