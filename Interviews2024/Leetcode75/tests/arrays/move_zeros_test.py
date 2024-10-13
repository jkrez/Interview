from typing import List

from Leetcode75.problems.arrays.move_zeros import Solution


def test_case_1():
    array: List[int] = [1, 2, 3]
    Solution.moveZeros(array)
    assert array == array

    array: List[int] = []
    Solution.moveZeros(array)
    assert array == array

    array: List[int] = [1]
    Solution.moveZeros(array)
    assert array == array

    array: List[int] = [0]
    Solution.moveZeros(array)
    assert array == array


def test_case_2():
    array: List[int] = [0, 1]
    Solution.moveZeros(array)
    assert array == [1, 0]


def test_case_3():
    array: List[int] = [0, 1, 0, 1]
    Solution.moveZeros(array)
    assert array == [1, 1, 0, 0]


def test_case_4():
    array: List[int] = [0, 1, 0, 3, 12]
    Solution.moveZeros(array)
    assert array == [1, 3, 12, 0, 0]
