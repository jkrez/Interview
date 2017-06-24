using System.Collections.Generic;

namespace Questions.Cracking_the_coding_interview.Chapter_8
{
    using System;
    using System.Collections;

    /// <summary>
    /// Coins: Given an innnite number of quarters (25 cents), dimes (10 cents), nickels (5 cents),
    /// and pennies(1 cent), write code to calculate the number of ways of representing n cents.
    /// </summary>
    public class Question_8_11
    {
        /// <summary>
        /// Note: Cache must be amount * denominations in size.
        /// Space: O(amount * denominations)
        /// Complexity: O()
        /// </summary>
        public static int MakeChangeDynamic(int amount, List<int> denominations, int next, Dictionary<Tuple<int,int>, int> cache)
        {
            if (cache.ContainsKey(new Tuple<int, int>(amount, next)) &&
                cache[new Tuple<int, int>(amount, next)] > 0)
            {
                return cache[new Tuple<int, int>(amount, next)];
            }

            if (amount == 0)
            {
                return 1;
            }

            if (next >= denominations.Count)
            {
                return 0;
            }

            int ways = 0;
            for (int i = 0; i * denominations[next] <= amount; i++)
            {
                ways += MakeChangeDynamic(
                    amount - (i * denominations[next]),
                    denominations,
                    next + 1,
                    cache);
            }

            cache[new Tuple<int, int>(amount, next)] = ways;
            return ways;
        }

        public static int MakeChange(int amount, List<int> denoms)
        {
            var ways = 1;
            foreach (var d in denoms)
            {
                if (d != 1)
                {
                    ways += (int) amount / d;
                }
            }

            return ways;
        }
    }
}
