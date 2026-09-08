public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        
        // Bucket sort
        var countNums = nums.Count();
        // the position denotes the frequency; max frequency is nums.Length
        // freq starts at 0 so +1
        var freqList = new List<int>[countNums + 1];

        // get frequency of each
        var numCount = new Dictionary<int,int>();
        foreach(var num in nums){
            numCount[num] = numCount.GetValueOrDefault(num, 0) + 1;
        }

        // place each number in correct position to denote frequency
        // the higher the frequency the later will appear in the list
        foreach(var kvp in numCount){
            var number = kvp.Key;
            var freq = kvp.Value;

            // initialize bucket if empty
            if(freqList[freq] == null){
                freqList[freq] = new List<int>();
            }

            freqList[freq].Add(number);
            // Console.WriteLine($"{number}:{freq}");
        }

        // return the top k most frequent
        var result = new List<int>();
        for(int i = freqList.Count() - 1; i >= 0; i--){
            
            // use freq list not numCount
            var bucket = freqList[i];

            if(bucket != null){
                foreach(var number in bucket){
                    if(result.Count < k){ // keep adding only if we have space i.e the top k only
                        result.Add(number);
                    }
                }
            }
        }

        return result.ToArray();
    }
}
