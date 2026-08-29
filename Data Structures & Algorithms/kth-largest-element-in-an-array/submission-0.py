class Solution:
    def findKthLargest(self, nums: List[int], k: int) -> int:
        
        # convert to max heap
        min_heap = []
        heapq.heapify(min_heap)

        for num in nums:
            heapq.heappush(min_heap, num)

            if len(min_heap) > k:
                heapq.heappop(min_heap)
            
        return heapq.heappop(min_heap)

