# Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
#
# A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of
# the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of
# "abcde" while "aec" is not).
from operator import truediv


class Solution:
    @staticmethod
    def is_subsequence(s: str, t: str) -> bool:
        t_idx: int = 0
        s_idx: int = 0
        while s_idx < len(s) and t_idx < len(t):
            if t[t_idx] == s[s_idx]:
                # match!
                s_idx += 1
            t_idx += 1

        return s_idx == len(s)
