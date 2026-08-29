from collections import defaultdict

class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        '''
            Use Dictionary is obvious choice
            Notes: 
                Pass validation means s and t same length meaning doesn't matter which to for loop
                Careful when comparing character counts as one of the dictionaries might not have that character
        '''
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
        char_counts = dict()

        for char in string:
            if char not in char_counts:
                char_counts[char] = 0
                
            char_counts[char] += 1

        return char_counts