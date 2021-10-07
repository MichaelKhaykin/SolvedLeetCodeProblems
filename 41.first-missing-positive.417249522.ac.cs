public class Solution {
    public int FirstMissingPositive(int[] nums) {
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0) nums[i] = -1;
        }        
        
        for(int i = 0; i < nums.Length; i++)
        {
            int k = nums[i];
            
            while(k > 0 && k <= nums.Length)
            {
                int num = nums[k - 1];
                nums[k - 1] = 0;
                
                if(num < 0) break;
                
                k = num;
            }
        }
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] != 0) return i + 1;
        }
        
        return nums.Length + 1;
    }
}
