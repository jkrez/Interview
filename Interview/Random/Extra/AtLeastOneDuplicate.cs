namespace Random.Extra
{
    using System.Collections.Generic;

    public static class AtLeastOneDuplicate
    {
        // O(n log (n)) tsime, O(1) space solution
        public static int ReturnDuplicateO1Space(List<int> list)
        {
            return ReturnDuplicateHelper(list, 1, list.Count);
        }

        public static int ReturnDuplicateFast(List<int> list)
        {
            return ReturnDuplicateHelperFast(list);
        }

        private static int ReturnDuplicateHelperFast(List<int> list)
        {

            HashSet<int> seen = new HashSet<int>();

            foreach (var x in list)
            {
                if (seen.Contains(x))
                {
                    return x;
                }

                seen.Add(x);
            }

            return -1;
        }

        private static int ReturnDuplicateHelper(List<int> list, int startRange, int endRange)
        {
            var n = list.Count - 1;
            var rangeSize = endRange - startRange;
            if (rangeSize <= 1)
            {
                var result = startRange;
                return result;
            }

            var count = 0;
            var middleValue = (endRange + startRange) / 2;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < middleValue &&
                    list[i] >= startRange &&
                    list[i] < endRange)
                {
                    count++;
                }
            }

            if (count > (rangeSize / 2))
            {
                return ReturnDuplicateHelper(list, startRange, middleValue);
            }

            return ReturnDuplicateHelper(list, middleValue, endRange);
        }
    }
}
