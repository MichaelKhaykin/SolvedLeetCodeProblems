public class Solution {
    public int DominantIndex(int[] nums) {
     
        int max = int.MinValue;
        int ind = -1;
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] > max)
            {
                max = nums[i];
                ind = i;
            }
        }
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(i == ind) continue;
            
            if(max < 2 * nums[i]) return -1;
        }
        
        return ind;
    }
}
