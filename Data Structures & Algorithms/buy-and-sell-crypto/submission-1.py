class Solution:

    '''
    You are given an integer array prices where prices[i] is the price of NeetCoin on the ith day.
    You may choose a single day to buy one NeetCoin and choose a different day in the future to sell it.
    Return the maximum profit you can achieve. You may choose to not make any transactions, in which case the profit would be 0.

    Input: prices = [10,1,6,5,6,7,1]
    Output: 6    
    '''
    def maxProfit(self, prices: List[int]) -> int:

        if len(prices) == 0: return 0
        if len(prices) == 1: return 0
        if len(prices) == 2: return 0 if prices[0]>prices[1] else prices[1]-prices[0]

        start = 0
        end = 1
        profitMax = 0

        while start < len(prices) and end < len(prices) and start<=end:

            # calculate current profit
            profit = prices[end]-prices[start]

            # track max
            if profit > profitMax:
                profitMax = profit

            # expand window and check again
            if prices[end] >= prices[start]:
                end += 1
                continue
            
            # if end price is lower than start then slide window to start at end
            # dont shrink like start+1 because end is always biggerEquals than start, so moving start +1 means that still larger than end so no point.
            start = end
            
        return profitMax

            