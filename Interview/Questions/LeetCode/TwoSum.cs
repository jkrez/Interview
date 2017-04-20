namespace Questions.LeetCode
{
    using System.Linq;

    /// <summary>
    /// Given an array of integers, return indices of the two numbers
    /// such that they add up to a specific target. You may assume that
    /// each input would have exactly one solution, and you may not use
    /// the same element twice.
    /// </summary>
    public class TwoSum
    {
        public static int[] FindTwoSum(int[] nums, int target)
        {
            var list = nums.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] + list[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[0];
        }
    }
}
