from collections import defaultdict 

class Solution:
    def hasDuplicate(self, nums: List[int]) -> bool:
         
        visited = set()
        
        for number in nums:
            if number in visited:
                return True
            
            visited.add(number)

        return False