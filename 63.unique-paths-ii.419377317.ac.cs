public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        
        if(obstacleGrid.Length == 0) return 0;
        
        var h = obstacleGrid.Length;
        var w = obstacleGrid[0].Length;
        
        int[,] dp = new int[h, w];
        dp[0, 0] = obstacleGrid[0][0] == 0 ? 1 : 0;
        
        for(int i = 1; i < w; i++)
        {
            if(obstacleGrid[0][i] == 0)
            {
                dp[0, i] = dp[0, i - 1];
            }   
            else
            {
                dp[0, i] = 0;
            }
        }
        for(int j = 1; j < h; j++)
        {
            if(obstacleGrid[j][0] == 0)
            {
                dp[j, 0] = dp[j - 1, 0];
            }   
            else
            {
                dp[j, 0] = 0;
            }
        }
        
        for(int i = 1; i < h; i++)
        {
            for(int j = 1; j < w; j++)
            {
                if(obstacleGrid[i][j] == 1)
                {
                    dp[i, j] = 0;
                    continue;
                }
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }
        
        return dp[h - 1, w - 1];
    }
}
