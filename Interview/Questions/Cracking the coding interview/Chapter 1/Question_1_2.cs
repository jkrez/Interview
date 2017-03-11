namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    /// <summary>
    /// Implement a function void reverse(char* str) in C or C++
    /// which reverses a nullterminated string.
    /// </summary>
    public class Question_1_2
    {

        public static string Reverse(string s)
        {
            if (s == null)
            {
                return null;
            }

            var array = s.ToCharArray();

            for (int i = 0, j = array.Length - 1; i < j; i++, j--)
            {
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            return new string(array);
        }
    }
}
