public class Solution {
    public bool IsPalindrome(string s) {
        
        // put inside a stack and will be poped in reversed
        var stack = new Stack<char>();
        var queue = new Queue<char>();

        char lower;
        foreach(char i in s){

            // add only alpha numeric, and make them all lower so its case insensitive
            if(char.IsLetterOrDigit(i)){
                lower = char.ToLower(i);

                stack.Push(lower);
                queue.Enqueue(lower);
            }
        }
    
        // Console.WriteLine(string.Join(",", queue));
        // Console.WriteLine(string.Join(",", stack));

        while(stack.Count() > 0 
           && queue.Count() > 0)
        {
            if(stack.Pop() != queue.Dequeue()){
                return false;
            }
        }

        return true;
    }
}
