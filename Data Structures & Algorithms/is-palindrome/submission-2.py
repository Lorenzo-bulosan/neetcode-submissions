class Solution:
    def isPalindrome(self, s: str) -> bool:
        '''
        Two pointer approach
        '''

        l,r = 0, len(s)-1 # left and right pointers

        while l <= r:

            # skip if not alpha numeric
            # after moving and skipping the pointers might have crossed already so add to condition
            while l<r and not self.isAlphaNumeric(s[l]):
                l += 1
            while l<r and not self.isAlphaNumeric(s[r]):
                r -= 1

            if s[l].lower() != s[r].lower(): # remember to compare case insensitive
                return False
            
            l += 1
            r -= 1

        return True
    
    # function to check if character is alphanumeric by checking its ord value
    # ord() returns the unicode - can also do char() to convert from unicode to normal character
    def isAlphaNumeric(self, current_char) -> bool:
        return (ord('A') <= ord(current_char) <= ord('Z') or # check capitals
               ord('a') <= ord(current_char) <= ord('z') or  # check small letters
               ord('0') <= ord(current_char) <= ord('9'))    # check numbers