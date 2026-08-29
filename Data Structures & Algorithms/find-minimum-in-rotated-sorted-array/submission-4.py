class Solution:
    def findMin(self, nums: List[int]) -> int:
        '''
            If rotated then there are two subarrays that are definitely ordered
            We need to find the split that give the two subarrays and also this coincides with the smallest as is rotated so would be Max then smallest

            We could binary search to find the split because from rightmost, leftmost and middle
            Two of them are ordered i.e [4,5,0,1,2,3] => L=4, M=1, R=3. So 1-3 are ordered, so not there as we are looking for split, must be on the left sub array instead
            Check L=4, M=5, R=0, so 4-5 are ordered must be on the other side
            0 Is the middle and the last element so this is our result
        '''

        left_idx, right_idx = 0, len(nums)-1
        mid_idx = 0

        res = nums[0]

        while left_idx <= right_idx:

            # if the start and last are in order then we take the start and compare to prev min
            if nums[left_idx] < nums[right_idx]:
                res = min(res, nums[left_idx])
                break

            mid_idx = (right_idx+left_idx)//2
            res = min(res, nums[mid_idx])

            if nums[left_idx] <= nums[mid_idx]:
                left_idx = mid_idx + 1                
            else:                
                right_idx = mid_idx
        
        return res
