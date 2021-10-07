public class Solution {
    public int MaximumGap(int[] nums) {
        
        nums = nums.OrderBy((x) => x).ToArray();
        
        int maxDiff = 0;
        
        for(int i = 0; i < nums.Length - 1; i++)
        {
            maxDiff = Math.Max(maxDiff, Math.Abs(nums[i] - nums[i + 1]));
        }
        
        return maxDiff;
    }
}
