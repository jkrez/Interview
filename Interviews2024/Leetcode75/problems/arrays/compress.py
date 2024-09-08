from typing import List

"""
Given an array of characters chars, compress it using the following algorithm:

Begin with an empty string s. For each group of consecutive repeating characters in chars:

If the group's length is 1, append the character to s.
Otherwise, append the character followed by the group's length.
The compressed string s should not be returned separately, but instead, be stored in the input character array chars. Note that group lengths that are 10 or longer will be split into multiple characters in chars.

After you are done modifying the input array, return the new length of the array.

You must write an algorithm that uses only constant extra space.

"""


class Solution:
    @staticmethod
    def compress(chars: List[str]) -> int:
        write_idx: int = 0
        read_idx: int = write_idx
        chars_len = len(chars)
        while read_idx < len(chars):
            start_read_idx: int = read_idx
            start_char: str = chars[read_idx]
            while read_idx < chars_len and start_char == chars[read_idx]:
                read_idx += 1

            total = read_idx - start_read_idx
            # advance write idx to the next character to read since we're done reading and either
            # reading the next char or writing a compactified version
            chars[write_idx] = start_char
            write_idx += 1
            if total <= 1:
                continue

            total_str: str = str(total)
            for char in total_str:
                chars[write_idx] = char
                write_idx += 1

        # remove trailing chars
        while write_idx < chars_len:
            chars.pop()
            write_idx += 1

        return len(chars)
