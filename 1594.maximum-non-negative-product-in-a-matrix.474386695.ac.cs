public class Solution {
    public int MaxProductPath(int[][] grid) {
        
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        long[,] dpmax = new long[rows, cols];
        long[,] dpmin = new long[rows, cols];
        
        dpmax[0, 0] = grid[0][0];
        dpmin[0, 0] = grid[0][0];
        
        for(int i = 1; i < rows; i++)
        {
            dpmax[i, 0] = dpmax[i - 1, 0] * grid[i][0];
            dpmin[i, 0] = dpmin[i - 1, 0] * grid[i][0];
        }
        for(int i = 1; i < cols; i++)
        {
            dpmax[0, i] = dpmax[0, i - 1] * grid[0][i];
            dpmin[0, i] = dpmin[0, i - 1] * grid[0][i];
        }
        
        for(int i = 1; i < rows; i++)
        {
            for(int j = 1; j < cols; j++)
            {
                var val1 = Math.Max(grid[i][j] * dpmax[i - 1, j], grid[i][j] * dpmax[i, j - 1]);
                
                val1 = Math.Max(val1, grid[i][j] * dpmin[i - 1, j]);
                val1 = Math.Max(val1, grid[i][j] * dpmin[i, j - 1]);
                
                var val2 = Math.Min(grid[i][j] * dpmin[i - 1, j], grid[i][j] * dpmin[i, j - 1]);
                val2 = Math.Min(val2, grid[i][j] * dpmax[i - 1, j]);
                val2 = Math.Min(val2, grid[i][j] * dpmax[i, j - 1]);
                
                dpmax[i, j] = val1;
                dpmin[i, j] = val2;
                
            }
        }
        
        var final = dpmax[rows - 1, cols - 1];
        
        int mod = (int)Math.Pow(10, 9) + 7;
        
        return final < 0 ? -1 : (int)(final % mod);
    }
}
