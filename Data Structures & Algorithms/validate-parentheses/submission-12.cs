public class Solution {
    /*
    t1="[[[[]]]]"
    t2="{([])}"
    t3="{}{}[]"
    t4="({}[])"

    Track it when its an open, and if its a close then check latest
    t2 => add {, add (, add [, then next is ], so check latest
    Therefore use a Stack

    O(n) time
    O(n) space 

    Edge cases:
    "(((" => when always open then stack is never 0
    ")))" => when always close then we never put on stack
    ")(){}" => has one opening, but doesnt close
    */
    public bool IsValid(string s) {

        var stack = new Stack<char>();
        var opening = new HashSet<char>(){'(','[','{'};
        var closing = new Dictionary<char,char>(){ 
            {')','('}, // this is saying that if you are closing with ')', then the latest should be '('
            {']','['},
            {'}','{'}
        };
        char current;

        // Edge case: if you start with a closing one
        if(closing.ContainsKey(s[0])){return false;}

        for(int i=0; i<s.Length; i++){

            current = s[i];

            // if its opening keep track until we try to close it
            if(opening.Contains(current)){
                stack.Push(current);
            }
            // when its closing, check the latest open bracket, and compare if its the opening the the closing
            else if(closing.ContainsKey(current)){
                if(stack.Count>0 && stack.Peek() == closing[current]){
                    stack.Pop();
                }
                else{
                    return false;
                }
            }
        }        

        return stack.Count == 0;
    }
}
