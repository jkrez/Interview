namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using System.Collections.Generic;

    public class Question_8_4
    {
        public static IEnumerable<List<int>> Powerset(List<int> set)
        {
            if (set.Count > Constants.BitsInInt)
            {
                throw new ArgumentOutOfRangeException(nameof(set));
            }

            for (uint i = 0; i < (1 << set.Count); i++)
            {
                yield return GetIthSubset(i, set);
            }
        }

        private static List<int> GetIthSubset(uint i, List<int> set)
        {
            var subset = new List<int>();
            var index = 0;
            for (uint j = i; j > 0; j >>= 1)
            {
                if ((j & 1) == 1)
                {
                    subset.Add(set[index]);
                }

                index++;
            }

            return subset;
        }
    }
}
