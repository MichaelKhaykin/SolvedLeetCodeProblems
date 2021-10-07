public class Solution {
    public int MaxScore(string s) {
    
        int[] dp = new int[s.Length];
        dp[s.Length - 1] = s[s.Length - 1] == '1' ? 1 : 0;
        
        for(int i = s.Length - 2; i >= 0; i--)
        {
            dp[i] = dp[i + 1] + (s[i] == '1' ? 1 : 0);
        }
        
        int max = dp[0] - 1;
        int left = 0;
        
        for(int i = 0; i < s.Length - 1; i++)
        {
            if(s[i] == '0')
            {
                left++;
                
                max = Math.Max(max, left + dp[i]);
            }
        }
        
        return max;
    }
}
