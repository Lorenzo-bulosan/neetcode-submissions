class KthLargest:

    def __init__(self, k: int, nums: List[int]):
        self.k = k
        self.minHeap = nums

        # convert the array to a heap
        heapq.heapify(self.minHeap)

        # Remove until only 3 left - meaning we are removing all small values and min heaps remove minimum values in O(1)
        while len(self.minHeap) > self.k:
            heapq.heappop(self.minHeap)

    def add(self, val: int) -> int:
        
        # could start empty so check it has a value and compare 
        # when its smaller than the top of the minheap then stop early as we don't want to insert it
        if len(self.minHeap) > 0 and val <= self.minHeap[0]: return self.minHeap[0]

        # we insert if its larger but pop if its has more than 3 elements ensuring only the largest ones are there
        heapq.heappush(self.minHeap, val)

        if len(self.minHeap) > self.k:
            heapq.heappop(self.minHeap)

        return self.minHeap[0]
        
