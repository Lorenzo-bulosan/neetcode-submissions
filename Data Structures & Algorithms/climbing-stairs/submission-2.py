
# Memoization
class Solution:
    def climbStairs(self, n: int) -> int:

        self.target = n
        self.visited = {}

        def dfs(val):

            if val in self.visited:
                return self.visited[val]

            if val == self.target:
                return 1
            if val == self.target+1:
                return 0

            self.visited[val] = dfs(val+1) + dfs(val+2)

            return self.visited[val]

        return dfs(0)