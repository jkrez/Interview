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

        """
        input: 0, 1
        step 1
            - input: [0, 1]
            - right = left = 0
            - right == 0, swap  
        step 2
            - input [0, 1]
            - right = 1
            - left = 1
        
        algo debugging
        step 1
        - 0, 0, 1
        - right = 0
        - left = 0
        = swap
        
        0, 0, 1
        
        """
        for right in range(len(nums)):
            if nums[right] != 0:
                nums[right], nums[left] = nums[left], nums[right]
                if nums[left] != 0:
                    left += 1

        return
