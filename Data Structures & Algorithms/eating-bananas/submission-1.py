class Solution:
    def minEatingSpeed(self, piles: List[int], h: int) -> int:
        
        max_k = max(piles)
        l, r = 1, max_k-1
        min_k = max_k

        while l <= r:

            k = (l+r)//2

            # total time spent eating
            time_spent = 0
            for p in piles:
                time_spent += math.ceil(p/k) 

            if time_spent <= h:
                min_k = k
                r = k-1
            else:
                l = k+1

        return min_k

