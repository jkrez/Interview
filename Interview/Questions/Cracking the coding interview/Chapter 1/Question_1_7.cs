namespace Questions.Cracking_the_coding_interview.Chapter_1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Rotate Matrix: Given an image represented by an NxN matrix,
    /// where each pixel in the image is 4 bytes, write a method to
    /// rotate the image by 90 degrees. (an you do this in place?
    /// </summary>
    public class Question_1_7
    {
        public static char[,] Rotate(char[,] image)
        {
            if (image == null)
            {
                throw new ArgumentException(nameof(image));
            }

            // Start from edge of the matrix and move until the center
            var imageLength = image.GetLength(0);
            for (var x = 0; x < imageLength / 2; x++)
            {
                var edgeLength = imageLength - (2 * x) - 1;
                for (var i = 0; i < edgeLength; i++)
                {
                    var x1 = x + i;
                    var y1 = x;
                    var x2 = imageLength - 1 - x;
                    var y2 = x1;
                    var x3 = imageLength - 1 - x - i;
                    var y3 = x2;
                    var x4 = x;
                    var y4 = x3;
                    FourWaySwap(image, x1, y1, x2, y2, x3, y3, x4, y4);
                }
            }

            return image;
        }

        private static void FourWaySwap(char[,] matrix, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            Swap(matrix, x1, y1, x2, y2);
            Swap(matrix, x3, y3, x4, y4);
            Swap(matrix, x3, y3, x1, y1);
        }

        private static void Swap(char[,] matrix, int x1, int y1, int x2, int y2)
        {
            var temp = matrix[x1, y1];
            matrix[x1, y1] = matrix[x2, y2];
            matrix[x2, y2] = temp;
        }
    }
}

 
