class Solution:
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        
        i, j = 0, len(numbers)-1 # left right pointers
        cur_sum = 0 # current sum of left/right pointer values
        while i<=j:
            
            cur_sum = numbers[i]+numbers[j]

            if  cur_sum == target:
                return [i+1,j+1]
            elif cur_sum > target:
                j -= 1
            else:
                i += 1

        return []