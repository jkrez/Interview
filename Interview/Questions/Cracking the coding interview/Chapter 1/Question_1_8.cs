namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0,
    /// its entire row and column are set to O.
    /// </summary>
    public class Question_1_8
    {
        // Time: O(M x N)
        // Space: O(M x N)
        public static void PropogateZeros(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentException(nameof(matrix));
            }

            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var zeroRows = new bool[m];
            var zeroCols = new bool[n];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroRows[i] = true;
                        zeroCols[j] = true;
                    }
                }
            }

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (zeroRows[i] || zeroCols[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
    }
}
