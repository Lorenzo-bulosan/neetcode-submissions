class Solution:
    def maxAreaOfIsland(self, grid: List[List[int]]) -> int:
        
        self.grid = grid
        self.visited = set()
        max_island = 0

        def is_valid(i, j):

            if 0 <= i <= len(grid)-1 and 0 <= j <= len(grid[0])-1: # not out of bounds
                if not (i,j) in self.visited: # not visited
                    if self.grid[i][j] == 1: # not water/0
                        return True

            return False

        def dfs(i, j):

            q = deque()
            q.append((i,j))
            count = 0

            while q:
            
                x, y = q.pop()
                self.visited.add((x, y))
                count += 1

                possible_neighbors = [[0,1],[0,-1],[1,0],[-1,0]]
                for nx, ny in possible_neighbors:
                    if is_valid(x+nx, y+ny):
                        q.append((x+nx, y+ny))
                        self.visited.add((x+nx, y+ny))

            return count

        area = 0
        for i in range(len(self.grid)):
            for j in range(len(self.grid[0])):        
                if is_valid(i,j):
                    area = dfs(i, j)                    
                    max_island = max(area, max_island)
                    print([area, max_island])

        return max_island

# [v,v,0,0,0]
# [v,v,0,0,0]
# [0,0,0,1,1]
# [0,0,0,1,1]

# 1, 2, 3, 4