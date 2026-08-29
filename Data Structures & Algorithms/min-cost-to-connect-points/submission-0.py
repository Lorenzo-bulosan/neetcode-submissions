class Solution:
    def minCostConnectPoints(self, points: List[List[int]]) -> int:
        '''
        Prims algo to find Minimum spaning tree on a undirected acyclic weighted graph
        '''

        # build adj list
        adj=collections.defaultdict(list)

        for i in range(len(points)):
            xi, yi = points[i]
            for j in range(i+1, len(points)):
                xj, yj = points[j]
                # undirected graph
                man_dist = abs(xi-xj)+abs(yi-yj)                
                adj[i].append([man_dist, j]) # dist i-j
                adj[j].append([man_dist, i]) # dist j-i

        # prims algo
        min_heap = [(0,0)] # dist, point
        visited = set()
        res = 0
        while min_heap:

            # get current point and add to visited
            distance, point = heapq.heappop(min_heap)

            if point in visited:
                continue
            else:
                visited.add(point)
            
            res += distance

            # check all other not visited points 
            for distance_x, point_x in adj[point]:
                if point_x not in visited:
                    # add to heap if unvisited
                    heapq.heappush(min_heap, [distance_x, point_x])
        
        return res
