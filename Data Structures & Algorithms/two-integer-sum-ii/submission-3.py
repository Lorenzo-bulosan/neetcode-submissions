class Solution:
    '''
    [1,2,3,6,7,8,10], target=13

    slide window start and end, 1,10
    if target is bigger then increase left, if not right
    this works because one we are assured 1 correct answer pair so has to be
    this works because its sorted

    Input: numbers = [1,2,3,4], target = 5
    Output: [2,3] - positions as 1-index array
    '''
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        
        left = 0
        right = len(numbers)-1

        while left < right:

            currentSum = numbers[left] + numbers[right]
            if currentSum > target:
                right -= 1
            elif currentSum < target:
                left += 1
            else:
                # solution found
                break

        return [left+1, right+1]