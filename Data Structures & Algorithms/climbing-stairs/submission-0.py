
# class Node:

    # def __init__(self, val)
    #     self.val = val
    #     self.left = None
    #     self.right = None

class Solution:
    def climbStairs(self, n: int) -> int:

        self.target = n
        
        def dfs(val):

            if val == self.target:
                return 1
            if val == self.target+1:
                return 0

            return dfs(val+1) + dfs(val+2) 

        return dfs(0)