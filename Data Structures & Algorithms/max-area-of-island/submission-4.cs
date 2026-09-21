public class Solution {

    private int[][] _grid;
    private HashSet<(int, int)> _seen = new HashSet<(int, int)>();

    public int MaxAreaOfIsland(int[][] grid) {

        _grid = grid;

        var areaIsland = 0;
        var maxArea = 0;
        for(int i=0; i<grid.Length; i++){
            for(int j=0; j<grid[i].Length; j++){
                if(IsValidNode(i, j)){
                    areaIsland = TraverseAndCountFromNode(i, j);
                    maxArea = Math.Max(areaIsland, maxArea);
                    // Console.WriteLine($"({i}, {j}) => {areaIsland}. Max: {maxArea}");
                }
            }
        }  

        return maxArea;  
    }

    private bool IsValidNode(int r, int c){

        if(r>=0 && r<_grid.Length && c>=0 && c<_grid[r].Length
           && _grid[r][c] == 1
           && !_seen.Contains((r,c))
        ){
            return true;
        }

        return false;
    }

    private int TraverseAndCountFromNode(int r, int c){

        // helper
        var stack = new Stack<(int, int)>();
        var possibleDirections = new (int, int)[]{ (-1,0), (1,0), (0,1), (0,-1) };

        int area = 0;
        stack.Push((r,c));

        while(stack.Count > 0){

            var (x, y) = stack.Pop();
            
            if(!_seen.Add((x, y))) continue; // hashset returns false if already added, as set contains no dups
                                             // DFS can push the same child from different nodes - skip is important
            area++;                          // only count if we added
            

            foreach(var (xn, yn) in possibleDirections){
                if(IsValidNode(x+xn, y+yn)){
                    stack.Push((x+xn, y+yn));
                }
            }
        }
        return area;
    }
}
