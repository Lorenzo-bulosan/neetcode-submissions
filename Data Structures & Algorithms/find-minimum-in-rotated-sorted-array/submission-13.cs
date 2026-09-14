public class Solution {
    public int FindMin(int[] nums) {
        
        int l=0, r=nums.Length-1;
        int mid;
        int res = int.MaxValue;
        while(l<=r){
            
            mid = l+(r-l)/2;

            res = Math.Min(res, nums[mid]);
            
            // remove right if sorted normally as min will be in left
            if(nums[mid] <= nums[r]){
                r = mid-1;
            }
            // if right is unsorted then min will be in right side
            else{
                l = mid+1;
            }
        }
        return res;
    }
}
