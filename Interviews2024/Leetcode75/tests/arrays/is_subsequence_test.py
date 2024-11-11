from Leetcode75.problems.arrays.is_subsequence import Solution


def test_case_1():
    assert Solution.is_subsequence("ABCABC", "ABC") == False
    assert Solution.is_subsequence("ABC", "ABC")
    assert Solution.is_subsequence("ABC", "ABCABC")
    assert Solution.is_subsequence("A", "A")
    assert Solution.is_subsequence("", "A")
    assert Solution.is_subsequence("A", "") == False
