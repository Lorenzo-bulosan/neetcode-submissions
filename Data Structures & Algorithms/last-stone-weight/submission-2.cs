public class Solution {

    public int LastStoneWeight(int[] stones) {

        // edge case only 1 nothing to clash
        if (stones.Length == 1) return stones[0];

        // max heap - in C#
        // var maxHeap = new PriorityQueue<int, int>(
        //     Comparer<int>.Create((x,y)=>y.CompareTo(x))
        // );

        // if you can't remember it then turn min heap into max heap
        // by making them negatives
        var maxHeap = new PriorityQueue<int, int>();
        foreach(int stone in stones){
            maxHeap.Enqueue(stone, -stone);
        }

        // now take 2 largest stones out and compare
        int x, y;
        while (maxHeap.Count>=2){

            // take two largest stones
            x = maxHeap.Dequeue();
            y = maxHeap.Dequeue();

            // simulate clash
            // handle equal
            if(x == y){
                continue; // i.e nothing left so nothing to add back
            }
            else{
                // a remaining stone is guaranteed
                // x is bigger as you dequeue it first
                x = x-y;
                maxHeap.Enqueue(x, -x);
            }
        }

        // scenario with 1 left
        if (maxHeap.Count == 1) return maxHeap.Dequeue();

        // if nothing remaining from the clashes i.e x==y
        return 0;
    }
}
