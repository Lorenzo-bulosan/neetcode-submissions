public class Solution {
    public int FindMin(int[] nums) {
        
        int res = nums[0];
        int l=0, r = nums.Length-1;
        int mid;
        while(l<=r){

            mid = l+(r-l)/2;

            // no target, track middle instead
            res = Math.Min(nums[mid], res);

            // check globally sorted means that m<r
            if(nums[mid]<=nums[r]){
                r = mid-1;
            }
            // otherwise is on right side i.e right is unsorted which will have the minimum
            else{
                l = mid+1;
            }
        }

        return res;
    }
}
