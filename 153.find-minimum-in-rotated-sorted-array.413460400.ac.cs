public class Solution {
    
    public int Helper(int[] nums, int low, int high)
    {
        if(low >= high) return nums[low];
        
        int mid = low + (high - low) / 2;
        
        if(nums[mid] > nums[mid + 1])
        {
            return nums[mid + 1];
        }
        else if(nums[mid] < nums[mid - 1])
        {
            return nums[mid];
        }
        
        int l = int.MaxValue;
        int r = int.MaxValue;

        if(nums[0] < nums[mid])
        {
            l = Helper(nums, mid + 1, high);
        }
        else
        {
            r = Helper(nums, low, mid - 1);
        }
        return Math.Min(nums[mid], Math.Min(l, r));
    }
    
    public int FindMin(int[] nums) {
        
        if(nums[0] < nums[nums.Length - 1]) return nums[0];
        
        return Helper(nums, 0, nums.Length -1);
    }
}
