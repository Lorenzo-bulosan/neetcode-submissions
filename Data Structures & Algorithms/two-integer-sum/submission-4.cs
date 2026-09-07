public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // only one possible answer pair
        // not sorted

        // plan: see prior but from current.
        //      Dont build dicitonary first because you cannot distinguish [5,5] and Target = 10
        //      So do a pass, and for the current number check prior seen ones. We build the seen collection while we iterate
        var seen = new Dictionary<int, int>();

        var complement = 0;
        var i = 0;
        foreach(var num in nums){
            
            complement = target-num;
            if(seen.ContainsKey(complement)){ // if seen before then we have an answer
                return [seen[complement], i];
            }
            else{
                seen.Add(num, i); // we are adding all of them, building at the same time
            }

            i+=1;
        }

        // we are guaranteed one at least so if not then something went wrong
        throw new Exception("No possible solution pair");
    }
}
