public class Solution {
    /*
        Always have len 3 min.
        
        Plan A) Sort it nlogn
        a+b+c = 0
        a = -b-c
        for each a
            Use 2 pointer approach left right to get b and c where a = -b-c

        nlogn + n^2 => O(n^2) time - O(1) Space

        Plan B) 2Pointer with Hashset
        nlogn - sort
        n - put on hashset
        n - to find 2 items that add up
        
        still n^2 and uses more space
    */    
    public List<List<int>> ThreeSum(int[] nums) {
        
        // init
        var result = new List<List<int>>();

        // sort the array
        Array.Sort(nums);

        // for each a find the 2 numbers that satisfy a+b+c=0
        int b ,c;
        for(int a=0; a<nums.Count(); a++){

            // compare current a with previous a to see if current is a duplicate
            // even at the start if its duplicate then it means we can skip to the last 'a'
            // as all the previous would just give the same triplet with same 'a'
            if (a > 0 && nums[a] == nums[a - 1]){
                continue;
            }    

            // two sum pointers
            b = a+1; //start after a to not repeat combinations, anything before a we already seen
            c = nums.Count()-1; 
            while (b<c){
            
                // found a valid triplet
                if(nums[a]+nums[b]+nums[c] == 0){
                    
                    // add triplet
                    result.Add(new List<int>{nums[a],nums[b],nums[c]});

                    // move as we already considered this triplet
                    b++;
                    c--;

                    // now check for dupliate values, so move b,c past the dups
                    // its SORTED so duplicate values are just next to each other
                    while(b<c && nums[b] == nums[b-1]){ // this is asking is my current one, same as previous
                        b++;
                    }
                    while(b<c && nums[c] == nums[c+1]){ // the new one is compared with prev to see if dup
                        c--;
                    }                    
                }
                else if(nums[a]+nums[b]+nums[c] < 0){
                    b++;
                }
                else if(nums[a]+nums[b]+nums[c] > 0){
                    c--;
                }                
            }
        }

        // if we dedup at the end we need hashset<strings> so space is no longer O(1)

        return result;
    }
}
