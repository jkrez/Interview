from Leetcode75.problems.arrays.gcd_string import Solution


def test_case_1():
    assert Solution.gcd_of_strings("ABCABC", "ABC") == "ABC"


def test_case_2():
    assert Solution.gcd_of_strings("LEET", "CODE") == ""


def test_case_3():
    assert Solution.gcd_of_strings("ABABAB", "ABAB") == "AB"
