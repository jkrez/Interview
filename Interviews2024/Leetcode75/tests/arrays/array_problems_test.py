from Leetcode75.problems.arrays.array_problems import Solution


def test_max_ops_1():
    assert Solution.max_operations([1, 2, 3, 4], 5) == 2
    assert Solution.max_operations([3, 1, 3, 4, 3], 6) == 1


def test_max_ops_2():
    assert Solution.max_operations2([1, 2, 3, 4], 5) == 2
    assert Solution.max_operations2([3, 1, 3, 4, 3], 6) == 1


def test_max_avg_subarray():
    assert Solution.findMaxAverage([1, 12, -5, -6, 50, 3], 4) == 12.75
    assert Solution.findMaxAverage([5], 1) == 5.0


def test_max_vowels():
    assert Solution.maxVowels("hello", 3) == 1
    assert Solution.maxVowels("hello", 4) == 2
