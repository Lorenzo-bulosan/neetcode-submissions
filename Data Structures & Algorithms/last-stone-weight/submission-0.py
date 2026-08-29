class Solution:
    def lastStoneWeight(self, stones: List[int]) -> int:
        '''
        Insert into a max heap
        In python only min heap so negate values inserting them and negate them back when you pop
        Pop the two biggest ones, and calculate and insert back if theres a remainder
        Continue until only one is left in max heap
        '''

        # Guard against empty stones
        if len(stones) == 0: return 0

        # Insert into max heap
        max_heap = []
        heapq.heapify(max_heap)
        for stone in stones:
            heapq.heappush(max_heap, (-1)*stone)

        # Continue clashing them until 1 or none remains
        heaviest, heaviest2 = 0, 0
        resulting_stone = 0
        while len(max_heap) > 1:
            heaviest = -heapq.heappop(max_heap)
            heaviest2 = -heapq.heappop(max_heap)

            # after clash nothing remains nothing to insert
            # also exit if you clash the last 2 and they're the same then we exit with othing so don't forget to handle on the return
            if heaviest == heaviest2:
                continue

            # clash the stones and insert the remainder
            resulting_stone = heaviest-heaviest2
            heapq.heappush(max_heap, (-1)*resulting_stone)

        return -heapq.heappop(max_heap) if len(max_heap) == 1 else 0

