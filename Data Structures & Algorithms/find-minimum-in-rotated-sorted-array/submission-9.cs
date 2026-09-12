public class Solution {
    public int FindMin(int[] nums) {

        int l=0, r = nums.Length-1;
        int mid;
        while(l<r){ // would be infinite loop with l<=r

            mid = l+(r-l)/2;

            // no target
            // so check right first if unsorted - when unsorted is always on the right for example [3,4,5,6,1,2]
            if(nums[mid] > nums[r]){
                l = mid+1;
            }
            else{
                r = mid; // dont -1 as it can skip the min, need to test mid
            }
        }

        // no target to check if exist so no bounds check - l will be the min
        return nums[l];
    }
}
