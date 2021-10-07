public class Solution {
    
    public bool CanJump(int[] nums) {
        
        int far = 0;
        for(int i = 0; i <= far && i < nums.Length; i++)
        {
            far = Math.Max(far, nums[i] + i);
        }
        return far >= nums.Length - 1;
    }
}
