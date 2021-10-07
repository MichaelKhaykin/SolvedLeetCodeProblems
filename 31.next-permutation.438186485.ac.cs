public class Solution {
    
    public void NextPermutation(int[] nums) {
        
        int i = nums.Length - 2;
        while(i >= 0 && nums[i + 1] <= nums[i])
        {
            i--;
        }
        
        if(i >= 0)
        {
            int j = nums.Length - 1;
            while(j >= 0 && nums[j] <= nums[i])
            {
                j--;
            }
            
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        
        reverse(nums, i + 1);
    }
    
    public void reverse(int[] nums, int index)
    {
        int i = index;
        int j = nums.Length - 1;
        while(i < j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            
            i++;
            j--;
        }
    }
}
