class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        
        if len(s) == 0 : return 0

        l, r = 0, 0
        res = 0
        count_chars = {}

        while r < len(s):
            
            if s[r] in count_chars:
                count_chars[s[r]] += 1
            else:
                count_chars[s[r]] = 1

            # check most popular in dictionary
            most_popular_char =  self.get_most_popular_char(count_chars) # b

            # How many in the widow are not the popular chars
            non_popular_char_count = res - count_chars[most_popular_char] # 3 - 2 = 1

            # Check if allowed to do that many
            if non_popular_char_count >= k:         
                count_chars[s[l]] -= 1
                l += 1

            res = max(res, r-l+1)  
            r += 1 

        return res


    def get_most_popular_char(self, count_char:{}) -> str:
        return max(count_char, key=count_char.get)
            