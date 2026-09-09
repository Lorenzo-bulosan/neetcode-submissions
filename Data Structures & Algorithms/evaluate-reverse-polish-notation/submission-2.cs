public class Solution {

    /*
    1+1         [1,1,+]
    1+2/3       [1,2,3,/,+]
    (1+2)/3     [1,2,+,3,/]
    (1+1)*(1-1) [1,1,+,1,1,-,*]

    put all on a stack
    peek until you find an operator +-/*
    then get do the operation with the last two and put the resulting value back

    O(n)
    O(1)

    Assume that division between integers always truncates toward zero.
    Assume is valid expression
    */
    public int EvalRPN(string[] tokens) {
        
        // edge case: ["100"] single is valid
        if (tokens.Length == 1){ 
            int.TryParse(tokens[0], out int a);
            return a;
        }

        var stack = new Stack<string>();
        var operators = new HashSet<string>(){"+","-","*","/"};
        var result = 0;

        // operate on the stack
        foreach(string current in tokens){

            // continue adding until we find an operator
            if(!operators.Contains(current)){
                stack.Push(current);
                continue;
            }
            
            // then get both previous and operate, put the result back for next operation
            int.TryParse(stack.Pop(), out int b);
            int.TryParse(stack.Pop(), out int a);
            
            // evaluate depending on operator
            if(current == "+"){
                result = a+b;
            }
            else if(current == "-"){
                result = a-b;
            }
            else if(current == "*"){
                result = a*b;
            }
            else if(current == "/"){
                result = a/b; // if a, b int then result is c int aswell in C#, truncates towards 0. 
                              // if you want to floor or ceil instead then Math.Floor(c) or Math.Ceiling(c)
            }

            stack.Push(result.ToString());
        }

        return result;
    }
}
