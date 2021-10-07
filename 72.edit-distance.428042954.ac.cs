public class Solution {
    
    public int Answer(string a, string b)
    {
        int[,] dp = new int[a.Length + 1, b.Length + 1];
        
        dp[0, 0] = 0;
        for(int i = 1; i < a.Length + 1; i++)
        {
            dp[i, 0] = i;
        }
        for(int j = 1; j < b.Length + 1; j++)
        {
            dp[0, j] = j;
        }
        
        for(int i = 1; i < a.Length + 1; i++)
        {
            for(int j = 1; j < b.Length + 1; j++)
            {
                if(a[i - 1] == b[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                }
            }
        }
        
        return dp[a.Length, b.Length];
    }
    
    public int MinDistance(string word1, string word2) {
        return Answer(word1, word2);
    }
}
