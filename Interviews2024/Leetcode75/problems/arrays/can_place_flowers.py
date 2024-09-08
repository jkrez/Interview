from typing import List


class Solution:
    @staticmethod
    def canPlaceFlowers(self, flowerbed: List[int], n: int) -> bool:
        if n == 0:
            return True

        max: int = 0
        nextFlower: int = 0
        prevFlower: int = 0
        start: bool = True
        for i in range(len(flowerbed)):
            # check for overflow
            start: bool = True if i == 0 else False
            end: bool = True if i + 1 == len(flowerbed) else False
            if not end:
                nextFlower = flowerbed[i + 1]
            else:
                nextFlower = 0

            if not start:
                prevFlower = flowerbed[i - 1]

            # place flower if we can
            if flowerbed[i] != 1 and not nextFlower and not prevFlower:
                flowerbed[i] = 1
                max += 1
                if n <= max:
                    return True

        return False
