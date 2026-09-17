public class KthLargest {

    public PriorityQueue<int, int> _minHeap = new PriorityQueue<int, int>();
    private int kth = 0;

    /*
    add to priority queue
    min queue quarantes we only have the top k, and the top is the smallest of the k
    why can we enqueue without checking?
    --> we are looking for top k largest
        so if the new value is lower and we add it then we have a new min
        so it would be the top k+1 largest, so remove the min so we get only k
        IF the new value is larger, we want to keep it so remove the smallest
        as we want only k largest    
    */
    public KthLargest(int k, int[] nums) {
        
        // initialize heap/pq
        foreach(var num in nums){
            _minHeap.Enqueue(num, num);
            if (_minHeap.Count > k) _minHeap.Dequeue();
        }

        // expose kth to other functions
        kth = k;
    }
    
    /*
    Add if larger than top, and remove the smallest to reorder
    Ignore if smaller than top
    */
    public int Add(int val) {

        // add everything no checks
        if(_minHeap.Count < kth){
            _minHeap.Enqueue(val, val);
            return _minHeap.Peek(); 
        }

        // assume not empty
        // if we want to add a larger element
        // then remove our current min as we want to keep this larger one
        if (val > _minHeap.Peek()){
            _minHeap.Dequeue();
            _minHeap.Enqueue(val, val);
        }
        // smaller than current so dont add, we only want top largest
        // only return the current top k as thats the requirement
        return _minHeap.Peek();
    }
}
