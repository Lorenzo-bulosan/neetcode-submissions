public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        // helpers
        var seen = new HashSet<(int,int)>();

        var maxArea = 0;
        var area = 0;

        for(int i=0; i<grid.Length; i++){
            for(int j=0; j<grid[i].Length; j++){

                // check if within bounds and is land
                // dfs traverse and mark all connected
                if(IsValid(i, j, seen, grid)){
                    area = Traverse(i, j, seen, grid);
                    maxArea = Math.Max(area, maxArea);
                }
            }            
        }

        return maxArea;        
    }

    private bool IsValid(int i, int j, HashSet<(int,int)> seen, int[][] grid){
        
        return (
            i>=0 && i<grid.Length && j>=0 && j<grid[i].Length // within bounds
            && grid[i][j] == 1                                // is land
            && !seen.Contains((i,j))                          // not seen before
        );
    }

    private int Traverse(int i, int j, HashSet<(int,int)> seen, int[][] grid){

        // helpers
        var area = 0;
        var stack = new Stack<(int,int)>();
        var possibleDirections = new (int,int)[]{(0,1), (0,-1), (1,0), (-1,0)};

        // init
        stack.Push((i,j));

        while(stack.Count > 0){

            // process the node
            var (x, y) = stack.Pop();

            // if seen, skip, otherwise mark it
            if(seen.Contains((x,y))) continue;
            else seen.Add((x,y));

            // after we make sure is not seen then add
            area++;

            // check neighbours
            foreach(var (xd, yd) in possibleDirections){
                
                // current neighbour
                var (xn, yn) = (x+xd, y+yd);

                if(IsValid(xn, yn, seen, grid)){
                    stack.Push((xn, yn));
                }
            }
        }

        return area;
    }    
}



























