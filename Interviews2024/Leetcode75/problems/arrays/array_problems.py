from typing import List, Dict


class Solution:
    # You are given an integer array nums and an integer k.
    #
    # In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.
    #
    # Return the maximum number of operations you can perform on the array.
    @staticmethod
    def max_operations(nums: List[int], k: int) -> int:
        nums.sort()
        left: int = 0
        right: int = len(nums) - 1
        ops: int = 0
        while left < right:
            sum: int = nums[left] + nums[right]
            if sum == k:
                ops += 1
                left += 1
                right -= 1
            elif sum < k:
                left += 1
            else:
                right -= 1

        return ops

    @staticmethod
    def max_operations2(nums: List[int], k: int) -> int:
        num_set: Dict[int, int] = {}
        ops: int = 0
        for index, num in enumerate(nums):
            if num_set.get(num) is not None and num_set[num] != 0:
                ops += 1
                num_set[num] -= 1
            else:
                component: int = k - num
                if num_set.get(component) is not None:
                    num_set[component] += 1
                else:
                    num_set[component] = 1

        return ops

    # You are given an integer array nums consisting of n elements, and an integer k.
    #
    # Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value.
    # Any answer with a calculation error less than 10-5 will be accepted.
    @staticmethod
    def max_operations2(nums: List[int], k: int) -> int:
        average: int = 0
        if len(nums) < k:
            return 0

        for i in range(len(k)):
            average += nums[i] / k

        max_avg: int = average
        left: int = 0
        for i in range(k, len(nums)):
            # remove
            average -= nums[i - k]
