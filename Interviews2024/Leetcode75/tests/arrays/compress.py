from Leetcode75.problems.arrays.compress import Solution


def test_case_1():
    input = list("caass")
    sln = Solution.compress(input)
    assert input == list("ca2s2")
    assert sln == 5


def test_case_2():
    input = list("a")
    sln = Solution.compress(input)
    assert input == list("a")
    assert sln == 1


def test_case_3():
    input = list("aaaaaa")
    sln = Solution.compress(input)
    assert input == list("a6")
    assert sln == 2


def test_case_4():
    input = ["a", "a", "a", "b", "b", "a", "a"]
    sln = Solution.compress(input)
    assert input == list("a3b2a2")
    assert sln == 6
