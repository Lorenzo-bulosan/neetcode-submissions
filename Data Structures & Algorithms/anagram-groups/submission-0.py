class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        
        # --- counting patterns -------
        # 1) loop through once O(m)
        # 2) create hashmaps with the key as the count of letters O(n) where n is avg lenght of string
        # 3) upsert any same key with appending to list the original string
        # 4) append all groups in a list and return
        # ---

        # represents a string into a count of its letters
        # i.e "abbccce" = [1,2,3,0,1] and same way [cbccbaec] is [1,2,3,0,1]
        def getPattern(string_):
            result = [0]*26
            
            for c in string_:
                key = ord(c)-ord('a')
                result[key] += 1
                
            return result
        
        # O(m*n) where n is avg lengh of s in strs
        # if s in str belongs to same pattern e.g "abbccce" = [1,2,3,0,1] then add to list using that key as other x, will also be in that key
        groupOfPatterns = defaultdict(list)
        for s in strs:
            key = getPattern(s)    
            key = tuple(key) # Tuple can be accepted as a key
            groupOfPatterns[key].append(s)
        
        # collate all groups and return
        result = []
        for l in groupOfPatterns.values():
            result.append(l)
            
        return result

