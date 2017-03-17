namespace Questions.Cracking_the_coding_interview.Chapter_1
{
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
            // Start from edge of the matrix and move until the center
            for (var x = 0; x < image.Length / 2; x++)
            {
                var edgeLength = image.Length - x - 1;
                for (var i = x; i < x + edgeLength; i++)
                {
                    var x1 = i + x;
                    var y1 = x;
                    var x2 = image.Length - x;
                    var y2 = x1;
                    var x3 = image.Length - x - i;
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

        private static void Swap(char[,] matrix, int c1X, int c1Y, int c2X, int c2Y)
        {
            var temp = matrix[c1X, c1Y];
            matrix[c1X, c1Y] = matrix[c2X, c2Y];
            matrix[c2X, c2Y] = temp;
        }
    }
}

 
