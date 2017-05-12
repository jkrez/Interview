namespace Questions.Cracking_the_coding_interview.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using Data_structures;

    public class Question_4_12
    {
        public static int SumPaths(BinaryTreeNode<int> node, int target)
        {
            var sums = new Dictionary<Tuple<int, int>, int>();
            return SumPathsHelper(node, target, 0, sums);
        }

        private static int SumPathsHelper(
            BinaryTreeNode<int> node,
            int target,
            int level,
            Dictionary<Tuple<int, int>, int> sums)
        {
            if (node == null)
            {
                return 0;
            }

            var numberOfPaths = 0;
            if (node.Data == target)
            {
                numberOfPaths++;
            }

            sums[new Tuple<int, int>(level, level)] = node.Data;
            for (int i = 0; i < level; i++)
            {
                sums[new Tuple<int, int>(i, level)] = sums[new Tuple<int, int>(i, level - 1)] + node.Data;
                if (sums[new Tuple<int, int>(i, level)] == target)
                {
                    numberOfPaths++;
                }
            }

            numberOfPaths += SumPathsHelper(node.Left, target, level + 1, sums);
            numberOfPaths += SumPathsHelper(node.Right, target, level + 1, sums);
            return numberOfPaths;
        }
    }
}
