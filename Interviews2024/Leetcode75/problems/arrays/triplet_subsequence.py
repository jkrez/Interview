from typing import List


class Solution:
    def increasingTriplet(self, nums: List[int]) -> bool:
        if len(nums) < 2:
            return False

        first: int = 2**31 - 1
        second = first

        for num in nums:
            if num <= first:
                first = num
            elif num <= second:
                second = num
            elif num > first and num > second:
                return True

        return False
