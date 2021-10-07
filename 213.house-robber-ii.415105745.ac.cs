public class Solution {
    public int Rob(int[] nums) {
        
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return nums[0];
        if(nums.Length == 2) return Math.Max(nums[0], nums[1]);
        
        var copy = new int[nums.Length - 1];
        for(int i = 0; i < copy.Length; i++)
        {
            copy[i] = nums[i];
        }
        var other = new int[nums.Length - 1];
        for(int i = 1; i < nums.Length; i++)
        {
            other[i - 1] = nums[i];
        }
        
        return Math.Max(Helper(other), Helper(copy));
    }
    
    public int Helper(int[] nums)
    {   
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
}
