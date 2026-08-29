from collections import defaultdict

class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        
        # validate
        if not self.is_valid(s, t): return False

        # count characters
        count_s = self.count_chars(s)
        count_t = self.count_chars(t)

        # check if same
        for char in count_s:
            if (char not in count_t 
                or (count_s[char] != count_t[char])):
                    return False

        return True


    def is_valid(self, word1: str, word2: str) -> bool:
        return len(word1) == len(word2)

    def count_chars(self, string: str) -> dict():
        char_counts = {}

        for char in string:
            if char in char_counts:
                char_counts[char] += 1
            else:
                char_counts[char] = 1

        return char_counts