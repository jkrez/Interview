namespace Questions.Qualtrics
{
    /// <summary>
    /// The problem is to count all the possible paths from top left to bottom right of a M x N
    ///  matrix with the constraints that from each cell you can either move only to right or down
    /// </summary>
    public class RobotProblem
    {
        public static int CountPaths(int m, int n)
        {
            var count = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                count[i, 0] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                count[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    count[i, j] = count[i - 1, j] + count[i, j - 1];
                }
            }

            return count[m-1, n-1];
        }
    }
}
