class Solution:
    def islandsAndTreasure(self, grid: List[List[int]]) -> None:
        
        q = deque()
        visited = set()

        def is_valid(r, c):

            if 0 <= r <= len(grid)-1 and 0 <= c <= len(grid[0])-1:
                if (r,c) not in visited:
                    if not grid[r][c] == -1:
                        return True
            return False

        # find location of treasures 
        for r in range(len(grid)):
            for c in range(len(grid[0])):
                if grid[r][c] == 0:
                    q .append((r,c))
                    visited.add((r,c))
        
        distance = 0
        possible_neighbors = [[0,1],[0,-1],[1,0],[-1,0]] # right, left, up, down
        while q :

            for i in range(len(q)):
                x, y = q.popleft() # queue
                grid[x][y] = distance

                # add possible neighbors
                for nx, ny in possible_neighbors:
                    if is_valid(x+nx, y+ny):
                        q.append((x+nx, y+ny))
                        visited.add((x+nx, y+ny))
            distance += 1