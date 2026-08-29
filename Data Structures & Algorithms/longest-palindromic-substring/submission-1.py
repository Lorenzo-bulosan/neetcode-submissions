class Solution:
    def longestPalindrome(self, s: str) -> str:
        
        max_pal_left_pos = 0
        max_pal_right_pos = 0
        max_pal_length = 0
        window_length = 0
        
        # check each letter and expand outwards
        for i in range(len(s)):

            # odd case: both pointers start same position
            l = i
            r = i
            while l >= 0 and r < len(s) and s[l] == s[r]: # both pointers same letter

                    # check current window length and update max accordingly
                    window_length = r-l+1
                    if window_length > max_pal_length:
                        max_pal_length = window_length

                        # keep track of palindrome pos to later return the substring
                        max_pal_left_pos = l 
                        max_pal_right_pos = l+max_pal_length

                    # update pointers outwards
                    l -= 1
                    r += 1
                    
            # even case: both pointers start adjacent to each other
            l = i
            r = i+1
            while l >= 0 and r < len(s) and s[l] == s[r]: # both pointers same letter

                    # check current window length and update max accordingly
                    window_length = r-l+1
                    if window_length > max_pal_length:
                        max_pal_length = window_length
                        
                        # keep track of palindrome pos to later return the substring
                        max_pal_left_pos = l 
                        max_pal_right_pos = l+max_pal_length
                    
                    # update pointers outwards
                    l -= 1
                    r += 1

        return s[max_pal_left_pos:max_pal_right_pos]
