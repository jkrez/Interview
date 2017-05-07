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
        // We can use the master's theorem to derive the complexity of this recursive algorithm
        // from the generic form:
        //      T(n) = a T(n/b) + f(n) where a exists in natural numbers, 1 < b exists in real numbers.
        //
        // The recurrent relation from this problem takes the form:
        //      T(n) = 2 T(n/2) + 2n
        //
        // This statisfies case 2 of the master's theorem which states:
        //      f(n) = BigTheta(n^c * log^k(n)) where c = log b (a)
        //
        // In our case:
        //      a = 2, b = 2, c = 1, f(n) = 2n
        //      f(n) = BigTheta(n^c log^k(n)) where c = 1, k = 0
        //
        // Case 2 condition, log b (a) = c, is satisfied. Substituting in:
        //      log b (a) = log 2 (2) = 1
        //
        // Thus follows from the master's theorem that the relation T(n) must be bound by:
        //      TT(n) = BigTheta(n^(log b (a) * log^(k+1)(n))
        //            = BigTheta(n^(log 2 (2)) * log^(0 + 1)(n))
        //            = BigTheta(n^1 * log(n)
        //            = BigTheta(n log (n))
        //
        // Time: O(n(log(n))
        // Space: O(n^2)
        // Unfortunately .net does not support O(1) linked list concatenation.
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
