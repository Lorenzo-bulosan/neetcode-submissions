public class Solution {
    /*
    [10,2,4,6,3,100]
    [100,4]
    [2]
    [0,0,0]
    [1,2,3]

    Plan A) Nested loop - For each day, check the following days, track max
            => O(n^2), O(1)
    Plan B) 2 Pointers - one tracks the smallest, the other one the largest wrt smallest
            To move the left pointer, the right must be smaller, so we move left to where right is
            To move the right pointer it has to be larger than the smaller
    */
    public int MaxProfit(int[] prices) {
    
        int maxProfit = 0;

        // edge case: [2] only 1
        if (prices.Length == 1) return maxProfit;

        int low = 0, high = 1;
        while (low < high && high < prices.Length)
        {
            // check if high has found a lower value than low
            if (prices[high]<prices[low])
            {
                low = high;
                high = low+1;
                continue;
            }

            // low <= high
            // check the profit and track if larger than previous
            // move pointer for next iteration

            maxProfit = Math.Max(maxProfit, prices[high]-prices[low]);
            high++;
        }
        return maxProfit;
    }
}
