public class Solution {
    public bool IsMatch(string s, string p) {
        
        if(s.Length == 0 && p.Length == 0) return true;
        if(p.Length == 0) return false;
        
        bool[,] dp = new bool[p.Length + 1, s.Length + 1];
        
        dp[0, 0] = true;
        if(p[0] == '*')
        {
            dp[1, 0] = true;
        }
        
        for(int i = 2; i < p.Length + 1; i++)
        {
            if(p[i - 1] == '*')
            {
                dp[i, 0] = dp[i - 1, 0];
            }
        }
        
        
        for(int i = 1; i < p.Length + 1; i++)
        {
            for(int j = 1; j < s.Length + 1; j++)
            {
                if(p[i - 1] == s[j - 1] || p[i - 1] == '?') 
                {
                    dp[i,j] = dp[i - 1, j - 1];
                }
                else if(p[i - 1] == '*')
                {
                    dp[i,j] = (dp[i - 1,j] | dp[i, j - 1] | dp[i - 1, j - 1]);
                }
            }
        }
        
        return dp[p.Length, s.Length];
    }
}
