class Solution:
    @staticmethod
    def gcd_of_strings(str1: str, str2: str) -> str:
        longest_len: int = len(str1)
        longest = str1
        shorter_len: int = len(str2)
        shorter = str2
        if longest_len < shorter_len:
            longest_len, shorter_len = shorter_len, longest_len
            longest, shorter = shorter, longest

        # find the largest possible common divisor length
        longest_common_divisor_len: int = 0
        while (
            longest_common_divisor_len < shorter_len
            and longest[longest_common_divisor_len]
            == shorter[longest_common_divisor_len]
        ):
            longest_common_divisor_len += 1

            # Check if we found common divisor.
        if longest_common_divisor_len == 0:
            return ""

        # Try each substring one at a time
        while longest_common_divisor_len > 0:
            if (
                longest_len % longest_common_divisor_len != 0
                or shorter_len % longest_common_divisor_len != 0
            ):
                longest_common_divisor_len -= 1
                continue

            i: int = 0
            while (
                i < longest_len
                and shorter[i % longest_common_divisor_len] == longest[i]
                and shorter[i % longest_common_divisor_len] == shorter[i % shorter_len]
            ):
                i += 1

            # check if we got to the end of the longer string
            if i == longest_len:
                return shorter[0:longest_common_divisor_len]

            # didn't make it to the end
            longest_common_divisor_len -= 1

        return ""
