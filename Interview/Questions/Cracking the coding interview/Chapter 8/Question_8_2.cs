using Questions.Data_structures;

namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System.Collections.Generic;

    /// <summary>
    /// Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
    /// The robot can only move in two directions, right and down, but certain cells are "off limits" such that
    /// the robot cannot step on them.Design an algorithm to find a path for the robot from the top left to
    /// the bottom right.
    /// </summary>
    public class Question_8_2
    {
        // Time: O (rows * columns)
        // Space: O (rows * columns)
        // Improvement: Use A* with heuristic of row,col manhattan distance from destination.
        public static List<Point> GetPath(bool [,] maze)
        {
            if (maze == null || maze.GetLength(0) == 0)
            {
                return null;
            }

            var path = new List<Point>();
            var failedPoints = new HashSet<Point>();
            if (GetPath(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, path, failedPoints))
            {
                return path;
            }

            return null;
        }

        private static bool GetPath(bool[,] maze, int row, int column, List<Point> path, HashSet<Point> failedPoints)
        {
            if (row < 0 || column < 0 || !maze[row, column] || failedPoints.Contains(new Point(row, column)))
            {
                return false;
            }

            var isDestination = row == 0 && column == 0;

            if (isDestination ||
                GetPath(maze, row - 1, column, path, failedPoints) ||
                GetPath(maze, row, column - 1, path, failedPoints))
            {
                path.Add(new Point(row, column));
                return true;
            }

            failedPoints.Add(new Point(row, column));
            return false;

        }
    }
}
