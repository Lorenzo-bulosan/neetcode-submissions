class Solution:
    '''
    Problem:
    You are given an integer array heights where heights[i] represents the height of the ith bar
    You may choose any two bars to form a container. Return the maximum amount of water a container can store.
    
    Input: height = [1,7,2,5,4,7,3,6]
    Output: 36    

    length always > 2 and heights are not negative
    '''
    def maxArea(self, heights: List[int]) -> int:
        
        # sliding window outside to inside and calculate area
        # keep only max area
        # move the lower of the heights

        left = 0
        right = len(heights)-1 # inclusive when used in while loop, unlike for i in range(a,b) where 'b' is non-inclusive but 'a' is
        maxArea = 0 # as heights can't be negative and width is 2 min, [0,0] is the min

        while left<right:
        
            area = (right-left)*(min(heights[left],heights[right])) # index 7-1 * the which ever is smallest of the two heights, as water scapes

            # check current area and update max if larger
            if area > maxArea:
                maxArea = area

            # check next pairs
            if heights[left] < heights[right]: # if the smallest is the left, then check next as it might be taller
                left += 1
            else:                              # if the right is smaller then check previous as might be taller, if both same doesn't matter move either
                right -= 1

        return maxArea
            

