public class Solution {
    /*
    Sorted ascending
    No duplicates

    => classic binary search
    */
    public int Search(int[] nums, int target) {
        
        int l = 0, r = nums.Length-1;
        int mid;
        while(l<=r)
        {
            mid = l + (r-l) / 2;

            if(nums[mid] == target) return mid;
            else if(nums[mid] < target) l = mid+1;
            else r = mid-1;
        }
        return -1;
    }
}
