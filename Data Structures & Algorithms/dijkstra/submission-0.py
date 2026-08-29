class Solution:
    def shortestPath(self, n: int, edges: List[List[int]], src: int) -> Dict[int, int]:
        
        # Build adj list showing neighbors and time it takes
        adj = {}
        for i in range(n):
            adj[i] = []

        for source,target,time in edges:
            adj[source].append((target, time))

        min_heap = [(0,src)]
        shortest = {}
        
        # shortest path 
        while min_heap: # if fully connected graph then min

            distance, node = heapq.heappop(min_heap)
            if node in shortest:
                continue
            shortest[node] = distance

            for neighbor, distance_neighbor in adj[node]:
                if neighbor not in shortest:
                    heapq.heappush(min_heap, (distance+distance_neighbor, neighbor))

        # missing nodes - if graph not fully connected
        for i in range(n):
            if i not in shortest:
                shortest[i] = -1

        return shortest


