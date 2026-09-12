public class Solution {
    public int Search(int[] nums, int target) {
        
        int l = 0;
        int r = nums.Length-1;
        int mid;
        while(l<=r){

            mid = l+(r-l)/2;

            // base case
            if (nums[mid] == target) return mid;

            // is left sorted locally
            if(nums[l]<=nums[mid]){
                // check for value
                if(nums[l]<=target && target<nums[mid]){
                    r = mid-1;
                }
                // if not here then checkother half
                else{
                    l = mid+1;
                }
            }
            // right unsorted
            else{
                // check for value
                if(nums[mid]<=target && target<=nums[r]){
                    l = mid+1;
                }
                // if not here then checkother half
                else{
                    r = mid-1;
                }
            }
        }

        return -1;
    }
}
