public class Solution {
    
    /*
             [a   ,b   ,c   ,d   ,   e]

    right => [1   ,a   ,ab  ,abc ,abcd]
    left  => [bcde,cde ,de  ,e   ,   1]

    */
    public int[] ProductExceptSelf(int[] nums) {

        var result = new int[nums.Count()]; // a list you cant initialize the size, but array you can
        
        // populate first
        var leftArray = new int[nums.Count()];
        leftArray[0] = 1;

        // populate rest
        int i = 1;
        int numsPos = 0;
        int leftProduct = 1;
        while(i < nums.Count()){
            leftProduct *= nums[numsPos];
            leftArray[i] = leftProduct;
            
            i ++;
            numsPos ++;
        }

        // populate first
        var rightArray = new int[nums.Count()];
        rightArray[nums.Count()-1] = 1;

        // populate rest
        var rightProduct = 1;

        for(int j = nums.Count()-2; j >= 0; j--){
            rightProduct *= nums[j+1];
            rightArray[j] = rightProduct;
        }

        // Console.WriteLine(string.Join(",",leftArray));
        // Console.WriteLine(string.Join(",",rightArray));

        // multiply both together, left and right components
        int x = 0;
        while(x < nums.Count()){

            result[x] = leftArray[x] * rightArray[x];
            
            x += 1;
        }

        return result;
    }
}
