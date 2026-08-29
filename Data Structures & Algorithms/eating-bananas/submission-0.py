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

# [1,4,3,2], 9h
# if k is 1/h => 9 bananas
# min(k)
# 10/4 = 2.5

# Sum(A) / h = max(k)
# k = 3, 2, 1
# condition = k*len(A)<=h and k*h >= Sum(A)
#   able to? k*h >= Sum(A)
#   within time? k*len(A) <= h
# 
