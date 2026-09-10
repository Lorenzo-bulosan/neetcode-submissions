public class Solution {
    /*
    permutations! anagram!
    1 <= s.length <= 100,000
    0 <= k <= s.length
    s consists of only uppercase english characters.

    AAA 1
    AAABKA 2
    AABABBAKA 2

    // use frequency arrays - eng dict = 26
    we are going to build the frequency array at each iteration and check against s1

    */    
    public bool CheckInclusion(string s1, string s2) {

        // s1 cant be longer than s2 otherwise s2 can't contain it
        if (s1.Length > s2.Length) return false;
        
        var s1Array = new int[26];
        var windowCount = new int[26];

        // create fArray of s1
        foreach(char c in s1)
        {
            s1Array[c-'a'] += 1; // A = position 0, etc
        }

        // creat fArray of initial window of s2
        for(int i=0; i<s1.Length; i++)
        {
            windowCount[s2[i]-'a'] += 1;
        }

        // compare early 
        if(Matches(s1Array, windowCount)) return true;

        // fixed window sweep 
        int l = 0;
        int r = l+s1.Length;
        char charLeft, charRight;
        while(l<r && r<s2.Length){
            
            // add to freq array the new inclusion
            // remove from freq array what we are leaving behind
            charLeft = s2[l];
            windowCount[charLeft-'a'] -= 1; // removing the one left out of fixed window
            
            charRight = s2[r]; // already slid
            windowCount[charRight-'a'] += 1; // adding the new one

            // check this new window if same as s1
            if(Matches(s1Array, windowCount)) return true;

            // slide
            l++;
            r++;
        }

        return false;
    }

    public bool Matches(int[] a, int[] b){
        
        // validate length
        if(a.Length != b.Length) return false;

        // validate values given length is same
        for(int i=0; i<a.Length; i++)
        {
            if(a[i] != b[i]) return false;
        }
        return true;
    }
}
