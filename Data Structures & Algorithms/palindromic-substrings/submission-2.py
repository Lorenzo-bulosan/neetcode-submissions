class Solution:
    def countSubstrings(self, s: str) -> int:
        '''
        Notes: Packaging previous solution in a function
        '''
        def count_palindromes(str_to_check: str, left: int, right: int) -> int:

            l = left
            r = right

            while l >= 0 and r < len(s) and s[l] == s[r]:
                self.count += 1
                l -= 1
                r += 1

            return count

        self.count = 0

        for i in range(len(s)):
            count_palindromes(s, i, i)
            count_palindromes(s, i, i+1)
            
        return self.count