namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;

    /// <summary>
    /// Parens: Implement an algorithm to print all valid (e.g., properly opened and closed) combinations
    /// of n pairs of parentheses.
    /// EXAMPLE
    ///   Input: 3
    /// Output: ((())), (()()), (())(), ()(()), ()()()
    /// </summary>
    public class Question_8_9
    {
        public static List<string> GetParenthesis(int n)
        {
            char[] s = new char[n * 2];
            var list = new List<string>();
            AddParens(list, n, n, s, 0);
            return list;
        }

        private static void AddParens(List<string> list, int left, int right, char[] str, int index)
        {
            if (left < 0 || right < left)
            {
                return;
            }

            if (left == 0 && right == 0)
            {
                list.Add(new string(str));
            }
            else
            {
                str[index] = '(';
                AddParens(list, left - 1, right, str, index + 1);

                str[index] = ')';
                AddParens(list, left, right - 1, str, index + 1);
            }
        }
    }
}
