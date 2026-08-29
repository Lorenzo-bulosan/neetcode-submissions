
# Bottom up
class Solution:
    def climbStairs(self, n: int) -> int:

        if n == 1: return 1

        num_steps = n
        combinations = 0
        left, right = 1, 1

        tmp = 0
        for step in range(num_steps-1): 
            combinations =  left + right
            
            # update  left, right - needs temp var
            tmp = left
            left = combinations
            right = tmp

        return combinations

    
# [8,5,3,2,1,1]

