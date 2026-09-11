public class Solution {
    /*
    [[1,2,4,8],[10,11,12,13],[14,20,30,40]]
    plan a) n+logm => sweep to see which array and then binary search
    plan b) logn + logm => binary search to find which array and then binary search on those
    */

    // PLAN A)
    // public bool SearchMatrix(int[][] matrix, int target) {

    //     // find in which subArray it might be in
    //     int possibleRow = -1;
    //     var isPossible = false;
    //     for(int i=0; i<matrix.Length; i++){ // rows

    //         if(matrix[i][0]<=target && target<=matrix[i][matrix[0].Length-1]){

    //             isPossible = true;
    //             possibleRow = i; // instead of using extra array space just keep track of index
    //             break;
    //         }
    //     }

    //     if (!isPossible) return false;

    //     // binary search inside possible array
    //     int l = 0;
    //     int r = matrix[0].Length-1;
    //     int mid;
    //     while(l<=r){

    //         mid = l+(r-l)/2;

    //         if(matrix[possibleRow][mid] == target) return true;
    //         else if(target < matrix[possibleRow][mid]) r = mid-1;
    //         else l = mid+1;
    //     }

    //     return false;
    // }

    // PLAN B)
    public bool SearchMatrix(int[][] matrix, int target){

        // binary search to find which row it should be located if it exists
        int possibleRow = -1;
        var isPossible = false;

        int a = 0;
        int z = matrix.Length-1;
        int m;
        while(a<=z){

            m = a+(z-a)/2;

            if(matrix[m][0]<=target && target<=matrix[m][matrix[0].Length-1]){
                isPossible = true;
                possibleRow = m;
                break;
            }
            else if(target < matrix[m][0]) z = m-1;
            else a = m+1;
        }

        if (!isPossible) return false;

        // binary search inside the possible array
        int l = 0;
        int r = matrix[0].Length-1;
        int mid;
        while(l<=r){

            mid = l+(r-l)/2;

            if(matrix[possibleRow][mid] == target) return true;
            else if(target < matrix[possibleRow][mid]) r = mid-1;
            else l = mid+1;
        }

        return false;
    }
}



