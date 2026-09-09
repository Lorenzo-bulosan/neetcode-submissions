public class MinStack {

    private Stack<int> _main {get; set;}
    private Stack<int> _min {get; set;}

    public MinStack() {
        _main = new Stack<int>();
        _min = new Stack<int>();
    }
    
    /*
    [4,3,5,8,2,100]
    [4,3,2]
    */
    public void Push(int val) {
        
        _main.Push(val);

        // add to min if first value
        if(_min.Count == 0){
            _min.Push(val);
        }
        // add to min if smaller than the top of min
        else if(val <= _min.Peek()){
            _min.Push(val);
        }
    }
    
    public void Pop() {
        
        // edge case when nothing there then can't pop
        if(_main.Count == 0){return;}

        // popping only from main, doesn't  remove from min
        // we pop when they're the same 
        // duplicates do not matter as its ordered as lifo
        if(_main.Peek() == _min.Peek()){
            _min.Pop();
        }

        _main.Pop();
    }
    
    public int Top() {
        // it says that this will always be called when not empty
        // if(_main.Count == 0){throw new InvalidOperationException;} 
        return _main.Peek();
    }
    
    public int GetMin() {
        return _min.Peek();
    }
}
