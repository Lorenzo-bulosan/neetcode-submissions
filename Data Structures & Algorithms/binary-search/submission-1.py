class Solution:
    def search(self, nums: List[int], target: int) -> int:
        
        if len(nums) == 0: return -1

        if len(nums) == 1: return 0 if nums[0] == target else -1

        left, right = 0, len(nums)-1
        mid = 0
        
        while left <= right:

            # get mid and check
            mid = (left+right)//2

            if nums[mid] == target: return mid

            if target > nums[mid]:
                left = mid+1
            
            elif target < nums[mid]:
                right = mid-1

        return -1
