from typing import List


class Solution:
    def reverseVowels(self, s: str) -> str:
        vowels: List[str] = ["a", "e", "i", "o", "u"]
        s_list = list(s)
        startIdx: int = 0
        endIdx: int = len(s) - 1

        while startIdx < endIdx:
            # advance to first vowle
            while not s_list[startIdx].lower() in vowels and startIdx < endIdx:
                startIdx += 1
            while not s_list[endIdx].lower() in vowels and startIdx < endIdx:
                endIdx -= 1

                # found a vowle, swap it!
            if startIdx < endIdx:
                s_list[startIdx], s_list[endIdx] = s_list[endIdx], s_list[startIdx]
                startIdx += 1
                endIdx -= 1

        return "".join(s_list)
