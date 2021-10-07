public class Solution {
    
    public int[] SearchRange2(int[] nums, int target) {
        
        if(nums.Length == 0) return new int[] { -1, -1 };
        
        int min = 0;
        int max = nums.Length;
        
        
        int look = -1;
        
        int prev = -1;
        
        while(true)
        {
            int avg = (min + max) / 2;
            
            if(prev == avg){
                return new int[] { -1, -1 };
            }
            
            if(nums[avg] > target){
                max = avg;
            }
            else if(nums[avg] < target){
                min = avg;
            }
            
            if(nums[avg] == target){
                
                look = avg;
                
                break;
            }
            
            prev = avg;
        }
        
        int leftMost = look;
        
        while(leftMost >= 0 && nums[leftMost] == nums[look]){
            leftMost--;
        }
        
        int rightMost = look;
        
        while(rightMost < nums.Length && nums[rightMost] == nums[look]){
            rightMost++;
        }
        
        return new int[] { leftMost + 1, rightMost - 1 };
    }
    
        public int[] SearchRange(int[] nums, int target) {
        var n = nums.Length;

        // find left
        var left = 0;
        var right = n;

        while (left < right) {
            var mid = left + (right - left) / 2;

            if (nums[mid] >= target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }

        var rangeLeft = left;
        if (rangeLeft == n || nums[left] != target) {
            return new int[] { -1, -1 };
        }

        left = rangeLeft;
        right = n;

        while (left < right) {
            var mid = left + (right - left) / 2;

            if (nums[mid] > target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }

        var rangeRight = left - 1;

        return new int[] { rangeLeft, rangeRight };
    }
}
