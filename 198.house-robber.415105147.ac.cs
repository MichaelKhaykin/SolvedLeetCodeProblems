public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return nums[0];
        if(nums.Length == 2) return Math.Max(nums[0], nums[1]);
        
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = nums[1];
    
        for(int i = 2; i < nums.Length; i++)
        {
            int newAns = 0;
            int c = i - 2;
            while(c >= 0)
            {
                newAns = Math.Max(dp[c], newAns);
                c--;
            }
            
            dp[i] = newAns + nums[i];
        }
        
        return dp.Max();
    }
    
    public int Rob2(int[] nums)
    {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return nums[0];
        if(nums.Length == 2) return Math.Max(nums[0], nums[1]);
        
        int ans = int.MinValue;
        for(int i = 0; i < nums.Length; i++)
        {
            int acc = nums[i];
            int start = i;
            for(int j = i + 2; j < nums.Length; j += 2)
            {
                acc += nums[j];
            }
            
            ans = Math.Max(ans, acc);
        }
        
        return ans;
    }
}
