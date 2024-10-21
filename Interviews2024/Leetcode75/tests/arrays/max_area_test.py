from typing import List

from Leetcode75.problems.arrays.max_area import Solution


def test_case_1():
    assert Solution.max_area([1, 1]) == 0


def test_case_2():
    assert Solution.max_area([1, 8, 6, 2, 5, 4, 8, 3, 7]) == 49
