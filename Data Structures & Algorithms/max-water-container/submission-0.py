class Solution:

    def maxArea(self, heights: List[int]) -> int:
        '''
            [1,7,2,5,4,7,3,6], len-1 = 7
            ^       ^
            max_vol = 7 -> 36* -> 15 -> 28

            start at end
            initialize a max
                get volume: check the smallest and multiply by length
                compare with max and keep largest
                move smallest +1 if right -1 if left and update the length
            repeat 3rd-5th steps

            [1,1,1,1,1,1,1]

            no negative heights
        '''
        # initialize max
        volume, max_vol = 0, 0

        if len(heights) == 0: return max_vol

        left, right = 0, len(heights)-1
        width = len(heights)-1

        while left < right:

            # get area and update
            if heights[left] < heights[right]:
                volume = heights[left]*width
                left += 1
            else:
                volume = heights[right]*width
                right -= 1

            max_vol = max(volume, max_vol)
            width -= 1

        return max_vol
            


            