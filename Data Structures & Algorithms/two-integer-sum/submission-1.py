class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        
        seen = {}

        for i, v in enumerate(nums):
            complement = target - v

            if complement in seen:                
                return [seen.get(complement), i]

            else:
                seen[v] = i

        raise("No solution")