public class Solution {
   
    public int NumTrees(int n) {
          if (n <= 1) return 1;

        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++) {
			// e.g. dp(3) = dp(0) * dp(2) + dp(1) * dp(1) + dp(2) * dp(0)
            var local = 0;
            for (int j = 0; j < i; j++) {
                local += dp[j] * dp[i - j - 1];
            }
            dp[i] = local;
        }

        return dp[n];
    }
}
