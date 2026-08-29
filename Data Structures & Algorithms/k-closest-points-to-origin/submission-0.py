class Solution:
    def kClosest(self, points: List[List[int]], k: int) -> List[List[int]]:
        '''
        Distance between two points (sqrt((x1 - x2)^2 + (y1 - y2)^2))

        We can use a meanheap. Calculate distance to 0 for each point, and add to the mean hea
        '''
        min_heap = []
        dist = 0
        # instert all with distance
        for x1, y1 in points:
            dist = (x1 ** 2) + (y1 ** 2)
            min_heap.append([dist, x1, y1])
        
        # heapify i.e convert the list into min_heap
        heapq.heapify(min_heap)
        
        # pop k times
        res = []
        x, y = 0, 0
        for i in range(k):
            dist, x, y = heapq.heappop(min_heap)
            res.append([x,y])
            
        return res