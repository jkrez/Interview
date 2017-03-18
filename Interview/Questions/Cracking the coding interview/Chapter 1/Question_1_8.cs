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
                throw new ArgumentNullException(nameof(matrix));
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

        // Time: O(M x N)
        // Space: O(1)
        public static void PropogateZerosInPlace(int[,] matrix)
        {
            // Find if there's a zero in the first row/column
            // Use the first row/column to store the values instead of the additional arrays created above
            // Zero the matrix where needed
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);

            bool zeroInFirstRow = false;

            for (int i = 0; i < colLength; i++)
            {
                zeroInFirstRow |= matrix[0, i] == 0;
            }

            bool zeroInFirstCol = false;

            for (int i = 0; i < rowLength; i++)
            {
                zeroInFirstCol |= matrix[i, 0] == 0;
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            for (int i = 1; i < rowLength; i++)
            {
                for (int j = 1; j < colLength; j++)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            if (zeroInFirstRow)
            {
                for (int i = 0; i < colLength; i++)
                {
                    matrix[0, i] = 0;
                }
            }

            if (zeroInFirstCol)
            {
                for (int i = 0; i < rowLength; i++)
                {
                    matrix[i, 0] = 0;
                }
            }
        }
    }
}
