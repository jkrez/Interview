namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Eight Queens: Write an algorithm to print all ways of arranging eight queens on an 8x8 chess board
    ///  so that none of them share the same row, column, or diagonal.In this case, "diagonal" means all
    /// diagonals, not just the two that bisect the board.
    ///
    /// I've adapted this problem to just count the number of ways instead of validate board positions
    /// </summary>
    public class Question_8_12
    {
        /// <summary>
        /// Space: O(n*n) where n is board dimensions
        /// Time: O(n^n)8*8 + 8*7 + ... 8*2 + 8*1 combinations are considered with this solution.
        ///
        /// Additional optimizations could be made to consider only 8! boards.
        /// </summary>
        public static int PlaceQueensWays(int numberOfQueens, int curentColumn, bool[,] board, bool[] rows, bool[] leftDiag,
            bool[] rightDiag)
        {
            if (numberOfQueens == 0)
            {
                return 1;
            }

            var ways = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (!rows[i] &&
                    !leftDiag[i + 7 - curentColumn] &&
                    !rightDiag[i + curentColumn])
                {

                    SetQueen( /* placement */ true, i, curentColumn, board, rows, leftDiag, rightDiag);
                    ways += PlaceQueensWays(numberOfQueens - 1, curentColumn + 1, board, rows, leftDiag, rightDiag);
                    SetQueen( /* placement */ false, i, curentColumn, board, rows, leftDiag, rightDiag);
                }
            }

            return ways;
        }

        private static void SetQueen(bool placement, int row, int col, bool [,] board, bool[] rows, bool[] leftDiag, bool[] rightDiag)
        {
            board[row, col] = placement;
            rows[row] = placement;
            leftDiag[row + 7 - col] = placement;
            rightDiag[row + col] = placement;
        }
    }
}
