class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        
        # find a way to encode an anagram to always have the same key
        # we can use a list to count the letters and make that the key maybe as a string

        anagramCounter = {}
        for word in strs:

            # encode words
            alphabetMap = [0]*26 #alphabet map
            for i in word:
                # string as number, but specifically character represented as number, if we want it to map to the alphabet ascii then ord(i)-ord('a')
                posInAlphabet = ord(i)-ord('a')
                alphabetMap[posInAlphabet] += 1
            
            # alphabetMap as key, currently still a list i.e from [0,0,1,0,3,0,...] to "001030..."
            encodedAnagram = ""
            for i in alphabetMap:
                encodedAnagram += '#'+str(i)

            # add the word to the counter if not initialise it
            if encodedAnagram not in anagramCounter:
                anagramCounter[encodedAnagram] = []
            
            anagramCounter[encodedAnagram].append(word)

        # create result list
        result = []
        for k, v in anagramCounter.items():
            result.append(v)

        return result

