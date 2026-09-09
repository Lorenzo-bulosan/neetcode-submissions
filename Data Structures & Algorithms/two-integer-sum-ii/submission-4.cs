public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        // we are told there's always one solution

        // plan a: pass through and binary search for complement => n + logn, 1 space

        // plan b: pass through with a hashset => n, n space

        // plan c: two pointer

        int l = 0;
        int r = numbers.Count()-1;
        int currentSum;
        while(l < r){
            currentSum = numbers[l]+numbers[r];
            if(currentSum == target){
                break;
            }
            else if(currentSum < target){
                l++;
            }
            else if(currentSum > target){
                r--;
            }            
        }
        // they want the answer as a 1-indexed array
        return new int[] {l+1, r+1};
    }
}
