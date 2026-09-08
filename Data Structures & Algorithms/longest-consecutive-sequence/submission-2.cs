public class Solution {

    /*
    Input: nums = [2,20,2,4,10,3,4,5]
    Output: 4 i.e [2, 3, 4, 5]
    */
    public int LongestConsecutive(int[] nums) {
        
        // use a hashset to ignore duplicates
        // check hashset to see if we've seen that number before
        // each number in the array check if we have a sequence
        // follow the sequence until diff > 1
        // keep a counter eachtime you follow the sequence and next number exists
        // keep a visited hashset too so we don't duplicate our counts

        // clean set first pass
        var cleanSet = new HashSet<int>();
        foreach(var num in nums){
            cleanSet.Add(num);
        }

        // visited set so we don't duplicate a passthrough
        var seen = new HashSet<int>();

        // check each number for a sequence
        var maxSequence = 0;
        foreach(var num in nums){
            
            // check if start of sequence i.e not have a previous, and also never seen it
            if(!cleanSet.Contains(num-1) && !seen.Contains(num)){
                maxSequence = Math.Max(maxSequence, SequenceCounter(num, seen, cleanSet));
            }
        }

        return maxSequence;
    }

    public int SequenceCounter(int num, HashSet<int> seen, HashSet<int> nodes){

        // shallow copy so this will affect the real hashset

        // add first node to seen
        if(!seen.Contains(num)){
            seen.Add(num);
        }

        // Try count the sequence
        var count = 1; // because we are checking next, but sequence start from 'num' not 'next'
        var next = num+1;
        while(nodes.Contains(next)){
            
            // count and update next num to check
            count++;
            
            // keep track of nodes we visited
            if(!seen.Contains(next)){
                seen.Add(next);
            }      

            next += 1;      
        }

        return count;
    }
}
