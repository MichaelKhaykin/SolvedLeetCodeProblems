public class Solution {
    public int MaxEnvelopes(int[][] envelopes)
    {
        if(envelopes.Length == 0) return 0;
    
        List<(int, int)> env = new List<(int, int)>();
        for (int i = 0; i < envelopes.Length; i++)
        {
            env.Add((envelopes[i][0], envelopes[i][1]));
        }

        env = env.OrderBy((t) => t.Item1).ToList();

        int[] dp = new int[env.Count];
        dp[0] = 1;

        for(int i = 1; i < env.Count; i++)
        {
            int x = i - 1;
            int max = 0;
            bool wentin = false;
            while(x >= 0)
            {
                if((env[i].Item1 > env[x].Item1 && env[i].Item2 > env[x].Item2))
                {
                    if(dp[x] > max)
                    {
                        max = dp[x];
                    }
                    wentin = true;
                }
                x--;
            }
            dp[i] = wentin ? max + 1 : 1;
        }

        return dp.Max();
    }
}
