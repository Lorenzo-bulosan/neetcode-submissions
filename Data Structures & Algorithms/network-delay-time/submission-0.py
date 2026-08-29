class Solution:
    def networkDelayTime(self, times: List[List[int]], n: int, k: int) -> int:
        '''
        Run Dijkstra's algo starting from k to find shortest path from k to all n
        Return largest of the smallest calculated path as that's the minimum for at least all
        '''

        # Build adj list showing neighbors and time it takes
        adj = collections.defaultdict(list)
        for source,target,distance in times:
            adj[source].append((target, distance))

        # shortest path
        shortest = set()
        min_heap = [(0,k)] #distance, source
        time = 0
        while min_heap:
            distance, node = heapq.heappop(min_heap)
            
            if node in shortest:
                continue
            else:
                shortest.add(node)
                time = distance

            # check its neighbors
            for neighbor, distance_neighbor in adj[node]:
                if neighbor not in shortest:
                    new_distance = distance + distance_neighbor
                    heapq.heappush(min_heap, (new_distance, neighbor))

        if len(shortest) != n:
            return -1
        
        return time
