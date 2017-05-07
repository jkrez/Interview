namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using Questions.Data_structures;

    /// <summary>
    ///  BST Sequences: A binary search tree was created by traversing through an array from left to right
    ///  and inserting each element.Given a binary search tree with distinct elements, print all possible
    ///  arrays that could have led to this tree.
    ///
    /// Assume well formed binary tree without cycles.
    /// </summary>
    public class Question_4_9
    {

        // Time: O(?)
        // Space: O(n^2)
        public static List<List<T>> PossibleArrays<T>(BinaryTreeNode<T> node)
            where T : IEquatable<T>
        {
            if (node == null)
            {
                return new List<List<T>>();
            }

            var possibleLeft = PossibleArrays(node.Left);
            var possibleRight = PossibleArrays(node.Right);

            if (possibleLeft.Count == 0 && possibleRight.Count == 0)
            {
                return new List<List<T>>()
                {
                    new List<T>() { node.Data }
                };
            }
            else if (possibleLeft.Count == 0 || possibleRight.Count == 0)
            {
                var possibilities = possibleLeft.Count == 0 ? possibleRight : possibleLeft;
                var result = new List<List<T>>();
                foreach (var sequence in possibilities)
                {
                    var newPossibleArray = new List<T>() { node.Data };
                    newPossibleArray.AddRange(sequence);
                    result.Add(newPossibleArray);
                }

                return result;
            }
            else
            {
                var result = new List<List<T>>();
                foreach (var leftPossibility in possibleLeft)
                {
                    foreach (var rightPossbility in possibleRight)
                    {
                        var newPossibleArray = new List<T>() { node.Data };
                        newPossibleArray.AddRange(leftPossibility);
                        newPossibleArray.AddRange(rightPossbility);
                        result.Add(newPossibleArray);

                        // Since list.add is adding references create new
                        // list for second possiblity
                        newPossibleArray = new List<T>() { node.Data };
                        newPossibleArray.AddRange(rightPossbility);
                        newPossibleArray.AddRange(leftPossibility);
                        result.Add(newPossibleArray);
                    }
                }

                return result;
            }
        }
    }
}
