public class Solution {
    public int IslandPerimeter(int[][] grid) {
        
        int count = 0;
        for(int i = 0; i < grid.GetLength(0); i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                if(grid[i][j] == 0) continue;
                
                if(i == 0)
                {
                    count++;
                }
                if(j == 0)
                {
                    count++;
                }
                
                if(i == grid.GetLength(0) - 1)
                {
                    count++;
                }
                
                if(j == grid[i].Length - 1)
                {
                    count++;
                }
                
                if(i - 1 >= 0 && grid[i - 1][j] == 0)
                {
                    count++;
                }
                
                if(i + 1 < grid.GetLength(0) && grid[i + 1][j] == 0)
                {
                    count++;
                }
                
                if(j - 1 >= 0 && grid[i][j - 1] == 0)
                {
                    count++;
                }
                
                if(j + 1 < grid[i].Length && grid[i][j + 1] == 0)
                {
                    count++;
                }
            }
        }
        
        return count;
    }
}
