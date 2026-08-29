class Solution:
    def search(self, nums: List[int], target: int) -> int:
        
        if len(nums) == 0: return -1

        if len(nums) == 1: 
            if nums[0] == target:
                return 0
            return -1

        l, r = 0, len(nums) - 1

        while l <= r:
            
            # get mid and check target
            mid_i = (r+l)//2

            if nums[mid_i] == target: return mid_i

            if nums[mid_i] < target:
                l = mid_i+1
            else:
                r = mid_i-1

        return -1