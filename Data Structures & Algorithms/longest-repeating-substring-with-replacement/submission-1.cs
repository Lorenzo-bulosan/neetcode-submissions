public class Solution {

    /*
    K=0
    "A" at least 1
    "AAA"K1
    "AAB"K1
    "AAABA"K1  

    "XYYX"K2
    "ABC"K1

    "AAABABB"
    "AAABKABC"K2    

    Idea is to keep track of most frequent - current length => the difference has to be less than k
    Because we can only use k times to make it the same as the most frequent character

    when to update? 
    the difference is larger than k, we need to shrink the window, remove from seen

    So just add, keep track of maxCount, if difference is larger than allowed swaps then
    remove left from seen move left forward

    we remove until the difference is covered by k

    exit, and track length as now this is a valid string with swaps, and check size

    */
    public int CharacterReplacement(string s, int k) {
        
        var charCount = new Dictionary<char, int>();

        int l = 0;
        int r = 0;
        int mostFreq = 0;
        int windowLength = 0;
        int longestSubstring = 0;
        while(l<=r && r<s.Length){

            // add r and count
            charCount[s[r]] = charCount.GetValueOrDefault(s[r],0)+1;

            // keep track of max - we increment this char and see if larger than previous high
            mostFreq = Math.Max(mostFreq, charCount[s[r]]);

            // find out how many swaps are needed
            // we only care about most freq vs window size - difference is what we need to swap
            r++;
            windowLength = r-l;
            while((windowLength-mostFreq) > k) // number of swaps more than allowed k
            {
                // remove from left
                charCount[s[l]]--;
                l++;

                // update info
                windowLength = r-l;
            }

            // from here on mean, theres enough swap i.e valid length to track
            longestSubstring = Math.Max(longestSubstring, windowLength);
        }

        return longestSubstring;
    }
}
