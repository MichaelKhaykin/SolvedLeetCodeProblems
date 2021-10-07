public class Solution {
    
    public int FindPeakElement(int[] nums) {
        
        if(nums.Length == 1) return 0;
        
        int left = 0;
        int right = nums.Length - 1;
        
        while(left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if(mid - 1 < 0 && nums[mid] > nums[mid + 1])
            {
                return mid;
            }
            else if(mid + 1 >= nums.Length && nums[mid] > nums[mid - 1]) 
            {
                return mid;
            }
            
            if(mid - 1 >= 0 && mid + 1 < nums.Length && nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
            {
                return mid;
            }
            
            if(nums[mid + 1] > nums[mid]) 
            {
                left++;
            }
            else if(nums[mid - 1] > nums[mid])
            {
                right--;
            }
        }
        
        return 0;
    }
}
