public class Solution {
    /*
    "abc" 
    "aaa" 
    "abcab"    
    "abcbb" 
    "abcccba"     
    "cccab" =>  c
    "axxa"  
    "" = 0
    */
    public int LengthOfLongestSubstring(string s) {

        int longest = 0;

        // edge case string.Empty
        if(s.Length == 0) return longest;

        var seen = new HashSet<char>();
        
        // start both at 0
        int l=0, r=0; // left, right pointers
        
        while(l<=r && r<s.Length)
        {
            // if we dont have a duplicate then add to seen and go next
            // track substring length
            if(!seen.Contains(s[r])){
                seen.Add(s[r]);
                r++;
                longest = Math.Max(longest, r-l);
                continue;
            }

            // if its duplicate we need to remove from left until r is not duplicated in substring
            // also remove from seen
            // continue next iteration
            seen.Remove(s[l]);
            l++;
        }

        return longest;
    }
}
