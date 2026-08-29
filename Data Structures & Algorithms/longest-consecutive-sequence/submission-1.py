
class Solution:
    '''
    We don't care about duplicates so put in a set
    The set also allows checking in O(1)

    The strat is to check each number in the set and try form a sequence
    To know if the number is the start of a sequence we check previous if exist and its fast as O(1) set lookup

    | Current Number | Is num - 1 in the set? | Decision             | Sequence Found | Length |
    | -------------- | ---------------------- | -------------------- | -------------- | ------ |
    | 10             | 9? → No                | Start of a sequence  | 10 → 11 → 12   | 3      |
    | 5              | 4? → Yes               | Not the start → Skip | -              | -      |
    | 12             | 11? → Yes              | Not the start → Skip | -              | -      |
    | 3              | 2? → No                | Start of a sequence  | 3 → 4          | 2      |
    | 11             | 10? → Yes              | Not the start → Skip | -              | -      |
    | 4              | 3? → Yes               | Not the start → Skip | -              | -      |
    | 55             | 54? → No               | Start of a sequence  | 55             | 1      |    
    '''
    def longestConsecutive(self, nums: List[int]) -> int:
        
        if len(nums) == 0: return 0

        # create set to remove dups and for O(1) lookups
        cleanList = set(nums)

        # check each number in the set and try form a sequence
        longest = 1 # track longest
        for n in cleanList:

            # check if start of a sequence by looking up if a previous exist
            if n-1 not in cleanList:
                
                # start counting local sequence - always 1 atleast, so reset to 1
                localLength = 1

                # keep looking at next number if exists
                nextNumber = n+1
                while nextNumber in cleanList:
                    localLength += 1

                    # check next number
                    nextNumber += 1

                # finished counting so compare with global longest sequence
                longest = max(longest, localLength)
            
            # skip otherwise if number is not the start of a sequence
        
        return longest