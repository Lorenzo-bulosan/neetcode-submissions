class Solution:
    def networkDelayTime(self, times: List[List[int]], n: int, k: int) -> int:
        
        # Build adj list showing neighbors and time it takes
        adj = collections.defaultdict(list)
        for source,target,distance in times:
            adj[source].append((target, distance))

        # shortest path
        shortest = set()
        min_heap = []
        heapq.heapify(min_heap)
        heapq.heappush(min_heap, (0,k)) # distance and source node
        time = 0

        while min_heap:

            # get shortest distance node
            distance, node = heapq.heappop(min_heap)

            # ignore if already seen this node
            if node in shortest:
                continue
            
            # if not seen before then mark as shortest
            shortest.add(node)
            time = distance

            # add its neighbours to the min heap
            for nei, dist in adj[node]:
                
                # check that the neibour is not a node we have seen before
                if not nei in shortest:
                     heapq.heappush(min_heap, (dist+time, nei)) # cumul distance to next node
        
        # if visited set does not match lenght of all nodes then some nodes are unreachable
        if len(shortest) != n:
            return -1
        
        return time


            