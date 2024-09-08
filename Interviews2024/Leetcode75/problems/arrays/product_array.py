from typing import List


class Solution:
    def productExceptSelf_Oh_one_space(self, nums: List[int]) -> List[int]:
        # lprod: List[int] = [1] * (len(nums))
        # rprod: List[int] = [1] * (len(nums))
        # for idx in range(1, len(nums), 1):
        #     lprod[idx] = lprod[idx - 1] * nums[idx - 1]

        # range() fn takes: (start (inclusive), stop (exclusive), step)
        # for idx in range(len(nums) - 2, -1, -1):
        #     rprod[idx] = rprod[idx + 1] * nums[idx + 1]
        #
        # res: List[int] = [0] * len(nums)
        # for idx in range(len(nums)):
        #     res[idx] = lprod[idx] * rprod[idx]

        # less space
        res: List[int] = [1] * len(nums)
        for idx in range(1, len(nums)):
            res[idx] = res[idx - 1] * nums[idx - 1]

        r_product: int = 1
        for idx in reversed(range(len(nums))):
            res[idx] = res[idx] * r_product
            r_product *= nums[idx]

        return res

    def productExceptSelf(self, nums: List[int]) -> List[int]:
        lprod: List[int] = [1] * (len(nums))
        rprod: List[int] = [1] * (len(nums))
        for idx in range(1, len(nums), 1):
            lprod[idx] = lprod[idx - 1] * nums[idx - 1]

        # range() fn takes: (start (inclusive), stop (exclusive), step)

        for idx in range(len(nums) - 2, -1, -1):
            rprod[idx] = rprod[idx + 1] * nums[idx + 1]

        res: List[int] = [0] * len(nums)
        for idx in range(len(nums)):
            res[idx] = lprod[idx] * rprod[idx]

        return res
