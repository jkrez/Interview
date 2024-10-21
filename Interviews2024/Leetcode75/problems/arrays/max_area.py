# You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
#
# Find two lines that together with the x-axis form a container, such that the container contains the most water.
#
# Return the maximum amount of water a container can store.
#
# Notice that you may not slant the container.
from typing import List


class Solution:
    @staticmethod
    def max_area(height: List[int]) -> int:
        left: int = 0
        right: int = len(height) - 1
        area_max: int = 0
        while left < right:
            lowest = min(height[left], height[right])
            dist = right - left
            area = dist * lowest
            if area > area_max:
                area_max = area
            if height[left] < height[right]:
                left += 1
            else:
                right -= 1

        return area_max
