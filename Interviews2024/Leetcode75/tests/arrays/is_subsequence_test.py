from Leetcode75.problems.arrays.is_subsequence import Solution


def test_case_1():
    assert Solution.is_subsequence("ABCABC", "ABC") == False
    assert Solution.is_subsequence("ABC", "ABC") == True
    assert Solution.is_subsequence("ABC", "ABCABC") == True
    assert Solution.is_subsequence("A", "A") == True
    assert Solution.is_subsequence("", "A") == True
    assert Solution.is_subsequence("A", "") == False
