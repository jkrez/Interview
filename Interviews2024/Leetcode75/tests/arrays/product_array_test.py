from Leetcode75.problems.arrays.product_array import Solution

sln = Solution()


def test_basic():
    assert sln.productExceptSelf([1, 2, 3]) == [6, 3, 2]


def test_basic_0():
    assert sln.productExceptSelf([0, 1, 2]) == [2, 0, 0]
