"""
Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.
"""

from typing import List


class Solution:
    @staticmethod
    def moveZeros(nums: List[int]) -> None:
        """
        approach - create a picket of zeros & bubble them back
        [0,2,5,0,1,0]
        Setup:
        - 1 pointer at end
        - 1 pointer at beginning
        - advance end pointer forward until no zeros
        Setps:
        - While end ptr is not < beg ptr
            - if zero,
        """

        if len(nums) <= 0:
            return

        left: int = 0
        right: int = 0

        for right in range (len(nums)):
            if nums[right] != 0 and:
                nums[right], nums[left] = nums[left], nums[right]
                left += 1

        return
