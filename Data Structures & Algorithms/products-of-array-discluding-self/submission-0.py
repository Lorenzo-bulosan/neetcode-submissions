class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        '''
        [1,2,4,6]
        [48,24,12,8]

        i=1, 24 = 1*4*6*2 = 48/2
        So just divide by the ith number


        '''

        # edge case: empty or one
        if len(nums) == 0: return []
        if len(nums) == 1: return [nums[i]]

        # edge case: two or more 0s means the products are always 0
            # why? because if the current is 0, the we multiply the rest, but the rest has a zero too, hence its always 0
        zeroCount = 0
        for n in nums:
            if n == 0:
                zeroCount+=1

        if zeroCount > 1: 
            return [0]*len(nums)

        # find the total product
        totalProduct = 1
        for n in nums:
            totalProduct = totalProduct*n

        result = []
        for n in nums:

            # only 1 zero left as we handle 2 or more above
            # we calculate manually the single instance of array having 1 zero, and calcualte the product wihtout it and append it for this case only
            if n == 0: 
                totalProductWithoutZero = 1
                for n in nums:
                    if n == 0:
                        continue
                    totalProductWithoutZero *= n
                result.append(int(totalProductWithoutZero))
                continue

            # no zeros left, meaning just divide
            else:
                removedSelf = totalProduct/n # what if not int

            result.append(int(removedSelf))

        return result
        