class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        
        l, r = 0, 1
        profit = 0

        while r < len(prices):
            
            # when not profitable adjust
            if prices[r] < prices[l]:
                l = r

            # check if new profit is bigger than old profit
            profit = max(profit, prices[r]-prices[l])

            r += 1
        
        return profit