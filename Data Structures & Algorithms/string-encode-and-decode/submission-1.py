class Solution:

    def encode(self, strs: List[str]) -> str:
        
        # Edge cases
        if len(strs) == 0: return ""
        
        # output
        encoded_string = ""

        # get count of each word
        count_words = {}
        for word in strs:
            count_words[word] = len(word)

        # prefix each with length and delimeter
        for word in strs:
            encoded_string += (str(count_words[word])+'#'+ word) # IRL use config or self.delimiter instead

        print(encoded_string)
        return encoded_string

    def decode(self, s: str) -> List[str]:

        encoded_str = s

        # output
        decoded_list = []
        
        # Edge cases
        if encoded_str == "": return decoded_list
        
        i = 0
        prev_word_end = 0
        
        while i<= len(encoded_str)-1:          
            
            current_char = encoded_str[i]

            if(current_char == '#'):
                word_len = int(encoded_str[prev_word_end:i]) # word length is from end of last word to # - is not always just i-1 as the word can be len 13 or 100
                word_start, word_end = i+1, i+word_len
                decoded_word = encoded_str[word_start:word_end+1]
                decoded_list.append(decoded_word)

                # update iterator
                i = word_end+1
                prev_word_end = i
                continue

            i += 1        
        return decoded_list