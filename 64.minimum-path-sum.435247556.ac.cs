public class Solution {
    public int MinPathSum(int[][] grid) {
        
        if(grid.Length == 0) return 0;
        
        int m = grid.GetLength(0);
        int n = grid[0].Length;
        
        int[,] dp = new int[m, n];
        dp[0, 0] = grid[0][0];
        
        //initalize all right to 1
        for(int i = 1; i < n; i++)
        {
            dp[0, i] = dp[0, i - 1] + grid[0][i];
        }
        
        //initialze all down to 1
        for(int i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }
        
        
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        
        return dp[m - 1, n - 1];
        
    }
}
