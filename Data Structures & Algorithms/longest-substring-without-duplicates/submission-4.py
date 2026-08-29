class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        
        l, r = 0, 1
        unique = set()
        longest_unique = 0

        for r in range(len(s)):

            while s[r] in unique:
                unique.remove(s[l])
                l += 1                
        
            unique.add(s[r])
            longest_unique = max(longest_unique, r-l+1)

        return longest_unique

