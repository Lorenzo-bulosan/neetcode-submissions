public class Solution {
    /*
        Not sorted,
        Total area is length*height
        We can start at max distance length and the check the max pair of heights.
        The minimum of the tallest is what we will consider as height as its what the water can fill
       up to
    */
    public int MaxArea(int[] heights) {
        
        int result = int.MinValue;
        
        int w, h, area;
        int l = 0, r = heights.Count()-1;
        while(l<r){
            
            // check area
            h = heights[l] <= heights[r] ? heights[l] : heights[r]; // the smallest of the two heights
            w = r-l;
            area = w*h;

            // for next iteration move whichever is smallest in hopes to find a taller height
            if(heights[l] <= heights[r]){
                l++;
            }
            else{
                r--;
            }

            // update max retention
            result = Math.Max(area, result);
        }

        return result;
    }
}
