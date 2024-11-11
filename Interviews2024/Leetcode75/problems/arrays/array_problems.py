from typing import List, Dict


class Solution:
    # You are given an integer array nums and an integer k.
    #
    # In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.
    #
    # Return the maximum number of operations you can perform on the array.
    @staticmethod
    def max_operations(nums: List[int], k: int) -> int:
        nums.sort()
        left: int = 0
        right: int = len(nums) - 1
        ops: int = 0
        while left < right:
            sum: int = nums[left] + nums[right]
            if sum == k:
                ops += 1
                left += 1
                right -= 1
            elif sum < k:
                left += 1
            else:
                right -= 1

        return ops

    #
    # Using a dict instead.
    #
    @staticmethod
    def max_operations2(nums: List[int], k: int) -> int:
        num_set: Dict[int, int] = {}
        ops: int = 0
        for index, num in enumerate(nums):
            if num_set.get(num) is not None and num_set[num] != 0:
                ops += 1
                num_set[num] -= 1
            else:
                component: int = k - num
                if num_set.get(component) is not None:
                    num_set[component] += 1
                else:
                    num_set[component] = 1

        return ops

    # You are given an integer array nums consisting of n elements, and an integer k.
    #
    # Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value.
    # Any answer with a calculation error less than 10-5 will be accepted.
    #
    # Brainstorm:
    # - Brute force: Iterate the array looking for a sequence with the max average.
    @staticmethod
    def findMaxAverage(nums: List[int], k: int) -> float:
        sum: int = 0
        if len(nums) < k:
            return 0

        for i in range(k):
            sum += nums[i]

        max_sum: int = sum
        left: int = 0
        for i in range(k, len(nums)):
            # remove
            sum -= nums[i - k]
            sum += nums[i]
            max_sum = max(max_sum, sum)

        return max_sum / k

    """
    Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

    Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.
    """

    @staticmethod
    def maxVowels(s: str, k: int) -> int:
        sum: int = 0
        max_sum: int = 0
        vowels: frozenset[str] = frozenset({"a", "e", "i", "o", "u"})
        if k > len(s):
            return 0
        for i in range(k):
            if s[i].lower() in vowels:
                sum += 1

        max_sum = sum
        for i in range(k, len(s)):
            if s[i - k].lower() in vowels:
                sum -= 1

            if s[i].lower() in vowels:
                sum += 1

            max_sum = max(max_sum, sum)

        return max_sum

    """
    Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
    
    Brainstorm: 
    - sliding window approach, start at begining of the array and expand until you hit max 0's then move through the 
        array expanding / contracting with at most k zeros. 
        
        
    Examples:
    - k = 1 array = 1001, answer: 2
    - k = 1 array = 101, answer: 3
    - k = 1 array = 000, answer: 1
    
    - k = 0 array = 010, answer: 1

    
    """

    @staticmethod
    def maxLongestOnes(nums: List[int], k: int) -> int:
        answer: int = 0
        left: int = 0
        right: int = 0

        zero_count: int = 0
        while right < len(nums):
            # expand right
            while right < len(nums) and (zero_count < k or nums[right] != 0):
                if nums[right] == 0:
                    zero_count += 1
                right += 1

            # capture max length
            answer = max(answer, right - left)

            # contract left. If k = 0, we need to move left over until we hit a zero.
            if k == 0:
                right += 1
                left = right
            else:
                while zero_count >= k:
                    if nums[left] == 0:
                        zero_count -= 1
                    left += 1

        return answer

    @staticmethod
    def longestOnes2(self, nums: List[int], k: int) -> int:
        left: int = 0
        right: int = 0
        for right in range(len(nums)):
            # If we included a zero in the window we reduce the value of k.
            # Since k is the maximum zeros allowed in a window.
            k -= 1 - nums[right]
            # A negative k denotes we have consumed all allowed flips and window has
            # more than allowed zeros, thus increment left pointer by 1 to keep the window size same.
            if k < 0:
                # If the left element to be thrown out is zero we increase k.
                k += 1 - nums[left]
                left += 1
        return right - left + 1
