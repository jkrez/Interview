namespace Tests
{
    using System;

    class MatrixHelpers
    {
        // Creates a two dimensional matrix from a one dimensional input
        // Example input:
        // m = 3, n = 3, list = 1 2 3 4 5 6 7 8 9
        // Example output:
        // 1 2 3
        // 4 5 6
        // 7 8 9
        public static T[,] CreateTwoDimensionalMatrix<T>(int m, int n, params T[] list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var result = new T[m, n];
            var counter = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = list[counter++];
                }
            }

            return result;
        }
    }
}
