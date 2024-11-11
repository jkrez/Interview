from Leetcode75.problems.arrays.array_problems import Solution


def test_max_ops_1():
    assert Solution.max_operations([1, 2, 3, 4], 5) == 2
    assert Solution.max_operations([3, 1, 3, 4, 3], 6) == 1


def test_max_ops_2():
    assert Solution.max_operations2([1, 2, 3, 4], 5) == 2
    assert Solution.max_operations2([3, 1, 3, 4, 3], 6) == 1
