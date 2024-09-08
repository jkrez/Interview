from typing import List


class Solution:
    @staticmethod
    def candies(candies: List[int], extra_candies: int) -> List[bool]:
        max: int = 0
        for kid in candies:
            max = kid if kid > max else max

        result: list[bool] = [False] * len(candies)
        for i in range(len(result)):
            result[i] = True if candies[i] + extra_candies >= max else False
        return result
