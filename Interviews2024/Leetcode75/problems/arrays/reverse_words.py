from typing import List


class Solution:
    @staticmethod
    def reverseWords(s: str) -> str:
        # two ways to do this:
        # 1. make a copy of the string and iterate w/ begin & end pointers
        # 2. strtoken the string on white space and reverse the list

        # option 1
        # words = s.split()[::-1] # reverse by making a copy
        words: List[str] = s.split()
        words.reverse()  # does reverse in place
        result = ""
        for idx, word in enumerate(words):
            result += word
            if idx + 1 < len(words):
                result += " "

        return result
        # option 2
        # language where you can reverse in place
        """
                while (begin_idx < end_idx):
            # find the next work consuming any number of whitespace chars
        """
