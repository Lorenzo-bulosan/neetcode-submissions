public class Solution {

    private char[][] _grid;
    private HashSet<(int x, int y)> _seen = new HashSet<(int x, int y)>();

    public int NumIslands(char[][] grid) {
        
        // expose grid to rest
        _grid = grid;

        var numIsland = 0;
        for(int i=0; i<grid.Length; i++){
            for(int j=0; j<grid[i].Length; j++){

                // check for valid start and count
                if(IsValidNode(i, j)){
                    TraverseNode(i, j);
                    numIsland++;
                }
            }
        }
        return numIsland;
    }

    public bool IsValidNode(int r, int c) {
        
        // check boundaries
        if( r >= 0 && r < _grid.Length            // row boundaries
            && c >= 0 && c < _grid[r].Length      // column boundaries
        ){  
            if(_grid[r][c] == '1'){               // valid land
                if( !_seen.Contains((r,c)) ){     // check if seen before
                    return true;
                }
            }
        }

        return false;
    }

    public void TraverseNode(int r, int c){
        
        // helpers
        var possibleDirections = new (int, int)[] { (0,1), (0,-1), (1,0), (-1,0) };
        
        var stack = new Stack<(int x, int y)>();
        stack.Push((r, c));

        // dfs algo
        while(stack.Count > 0){

            // process current node and mark as visited
            var (x, y) = stack.Pop();
            _seen.Add((x, y));
            
            // explore possible directions from this node
            foreach(var (xd, yd) in possibleDirections){
                if(IsValidNode(x+xd, y+yd)){
                    stack.Push((x+xd, y+yd));
                }
            }
        }
    }
}
