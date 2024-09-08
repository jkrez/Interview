from Leetcode75.problems.arrays.reverse_words import Solution


def test_basic():
    assert Solution.reverseWords("hello world") == "world hello"


def test_basic2():
    assert Solution.reverseWords("  hello world  ") == "world hello"


def test_basic3():
    assert Solution.reverseWords("a good   example") == "example good a"
