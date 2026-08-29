class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        
        # find frequency of all nums
        numberFrequency = {}
        for num in nums:
            
            if num not in numberFrequency:
                numberFrequency[num] = 0 # init at 0
            
            numberFrequency[num] += 1
            
        # create a bucketsort list 
        # each i represents the frequency, so max frequency means is a list of only 1 number e.g [3,3,3,3,3,3,3]
        # that would be seven 3s, so the bucket list would look like [0,0,0,0,0,0,0,3] and careful its len 8 as 0,1,2,3,4,5,6,7 - to be able to use 7 
        freqList = []
        for i in range(len(nums)+1): # 0 position means 0 things appear there, unused in this case but still needed
            freqList.append([])
            
        # put the number in the list in the position of its frequency
        for number in numberFrequency: # value/key where k is the number and value is frequency
            frequency = numberFrequency[number]
            freqList[frequency].append(number)

        # iterate backwards to get the top k frequent numbers
        result = []
        for i in range(len(freqList)-1, 0, -1): # careful as in range(a:b:steps), a is inclusive, b is not inclusive

            # take only first k numbers
            if len(result) == k: 
                break
        
            # put in results list if not empty list at that position
            if len(freqList[i]):
                for j in freqList[i]:
                    result.append(j)

        return result