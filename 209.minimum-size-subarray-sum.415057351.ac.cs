public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        int left = 0;
        int sum = 0;
        int ans = int.MaxValue;
        
        for(int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            while(sum >= s)
            {
                ans = Math.Min(ans, i + 1 - left);
                
                sum -= nums[left];
                left++;
            }
        }
        
        return ans == int.MaxValue ? 0 : ans;
    }
}
