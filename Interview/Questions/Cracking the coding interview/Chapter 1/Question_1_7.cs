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
        // Time: O(n)
        // Spcae: O(1)
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
                // Matrix quadrants:
                // 1 2
                // 4 3
                var edgeLength = imageLength - (2 * x) - 1;
                for (var i = 0; i < edgeLength; i++)
                {
                    var row1 = x;
                    var col1 = x + i;
                    var row2 = x + i;
                    var col2 = imageLength - 1 - x;
                    var row3 = imageLength - 1 - x;
                    var col3 = imageLength - 1 - x - i;
                    var row4 = imageLength - 1 - x - i;
                    var col4 = x;

                    var orig = image[row1, col1];
                    image[row1, col1] = image[row4, col4];
                    image[row4, col4] = image[row3, col3];
                    image[row3, col3] = image[row2, col2];
                    image[row2, col2] = orig;
                }
            }

            return image;
        }
    }
}

 
