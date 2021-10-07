public class Solution {
    
   
    public int MaxProduct(int[] nums) {
        
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int res = 0;
            int[] maxes = new int[nums.Length];
            int[] mins = new int[nums.Length];
        
            maxes[0] = nums[0];
            mins[0] = nums[0];
        
            for (int i = 1; i < nums.Length; i++)
            {
                maxes[i] = Math.Max(nums[i], Math.Max(maxes[i-1] * nums[i], mins[i-1]*nums[i]));
                mins[i] = Math.Min(nums[i], Math.Min(maxes[i-1]*nums[i], mins[i-1]*nums[i]));
            }
            return maxes.Max();
        
    }
}
