public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        
        // use max heap and only keep kth len
        // as the max will be the top 3 from the min, the last will be the min
        // the opposite of kth largest using min
        // kth smallest using max

        var maxHeap = new PriorityQueue<int[], int>();
        int distance = 0;
        foreach(var point in points){
            
            distance = (point[0]*point[0] + point[1]*point[1]);
            maxHeap.Enqueue(point, -distance); // max heap

            if(maxHeap.Count > k){
                maxHeap.Dequeue(); // if smaller then we already added and pop largest
                                   // if larger then we add and remove the larger i.e keeping kth smallest
            }
        }

        // add heap points to result
        var res = new int[k][]; // can't add to array so create with size already known
        for(int i=0; i<k; i++){
            var pair = maxHeap.Dequeue();
            res[i] = new int[]{pair[0], pair[1]};
        }

        return res;
    }
}
