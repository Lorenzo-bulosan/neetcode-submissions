class Solution:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        '''
        Optimized recursion by using Memoization in Top Down DP fashion
        '''
        self.cost = cost
        self.cache = {}

        def dfs(pos):

            if pos in self.cache:
                return self.cache[pos]

            # base case: reach the end of the stairs, how much does it cost to move up to the top
            if pos == len(self.cost)-1:
                return self.cost[pos]
            
            # base case: overshoot, we already reached the top
            if pos >= len(self.cost):
                return 0

            self.cache[pos] = self.cost[pos] + min(dfs(pos+1), dfs(pos+2))

            return self.cache[pos]

        return min(dfs(0), dfs(1))
