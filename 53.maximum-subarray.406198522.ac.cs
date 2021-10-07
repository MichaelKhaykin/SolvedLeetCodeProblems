public class Solution {
    public int MaxSubArray(int[] nums) {
        int global = nums[0];
        int current = nums[0];
        
        for(int i = 1; i < nums.Length; i++)
        {
            current = Math.Max(nums[i], current + nums[i]);
            if(current > global)
            {
                global = current;
            }
        }
        
        return global;
    }
}
