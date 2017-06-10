namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using System.Collections.Generic;
    using Data_structures;

    /// <summary>
    /// Paint Fill: Implement the "paint fill" function that one might see on many image editing programs.
    /// That is, given a screen(represented by a two-dimensional array of colors), a point, and a new color,
    /// fill in the surrounding area until the color changes from the original color.
    /// </summary>
    public class Question_8_10
    {
        // Time: O(n * m) (n is row legnth, m is col length)
        // Space: O(n)
        public static void ColorFill(Point p, int[,] image, int newColor)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            int rowLength = image.GetLength(0);
            int colLength = image.GetLength(1);
            if (p.Row < 0 || p.Row >= rowLength || p.Column < 0 || p.Column >= colLength)
            {
                throw new ArgumentOutOfRangeException(nameof(p));
            }

            int oldColor = image[p.Row, p.Column];
            if (oldColor == newColor)
            {
                return;
            }

            var frontier = new Stack<Point>();
            frontier.Push(p);

            while (frontier.Count != 0)
            {
                var next = frontier.Pop();
                if (next.Row > 0 && image[next.Row - 1, next.Column] == oldColor)
                {
                    frontier.Push(new Point(next.Row - 1, next.Column));
                }

                if (next.Column + 1 < colLength && image[next.Row, next.Column + 1] == oldColor)
                {
                    frontier.Push(new Point(next.Row, next.Column + 1));
                }

                if (next.Row + 1 < rowLength && image[next.Row + 1, next.Column] == oldColor)
                {
                    frontier.Push(new Point(next.Row + 1, next.Column));
                }

                if (next.Column > 0 && image[next.Row, next.Column - 1] == oldColor)
                {
                    frontier.Push(new Point(next.Row, next.Column - 1));
                }

                image[next.Row, next.Column] = newColor;
            }
        }
    }
}
