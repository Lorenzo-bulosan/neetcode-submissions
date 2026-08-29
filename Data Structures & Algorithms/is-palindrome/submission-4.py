from collections import deque 
class Solution:
    def isPalindrome(self, s: str) -> bool:
        
        # edgecase, only 1
        if len(s)==1: return True

        # use double ended queue for a fast O(1) pop stack from either side
        doubleEndedQueue = deque()
        for c in s:
            doubleEndedQueue.append(c)
        
        # compare start and end, so at least needs 2
        # edgecase of palindrome is odd len words, but because we are removing from stack then if its odd there will only be 1 left
        while len(doubleEndedQueue) > 1:
            
            # as specified we ignore if not alphanumeric, and also it should be case insensitive
            # therefore keep popping until meeting the conditions
            while doubleEndedQueue and not doubleEndedQueue[0].isalnum(): # check start - order matters, check if not empty first before checking
                doubleEndedQueue.popleft()
            while doubleEndedQueue and not doubleEndedQueue[-1].isalnum(): # check end
                doubleEndedQueue.pop()

            # We may have removed everything, or only one character remains 
            if len(doubleEndedQueue)==0 or len(doubleEndedQueue)==1: return True                

            # now that the start and end are clean we pop to check
            startChar = doubleEndedQueue.popleft()
            endChar = doubleEndedQueue.pop()                     

            if startChar.lower() != endChar.lower():
                return False

        return True


