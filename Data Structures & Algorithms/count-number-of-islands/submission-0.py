class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        
        self.grid = grid
        self.visited = set()
        islands = 0

        def valid_node(i, j) -> bool:
            # could be one long condition - but for line readability
            if 0 <= i <= len(self.grid)-1 and 0 <= j <= len(self.grid[0])-1:
                if self.grid[i][j] == "1":
                    if not (i,j) in self.visited:
                        return True
            return False

        def dfs(i, j):
            
            q = deque()
            q.append((i,j))

            while q:

                x, y = q.pop()
                self.visited.add((x,y))

                possible_neighbors = [[0,1],[0,-1],[1,0],[-1,0]]
                for nx, ny in possible_neighbors:                    
                    if valid_node(x+nx, y+ny):
                        q.append((x+nx, y+ny))
                

        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if valid_node(i, j):
                    dfs(i, j)
                    islands += 1
        
        return islands
