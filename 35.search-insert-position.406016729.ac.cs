public class Solution {
    public int SearchInsert(int[] nums, int target) {
        for(int i = 0; i < nums.Length; i++)
        {
            if(i + 1 >= nums.Length && nums[i] < target)
            {
                return i + 1;
            }
            if(nums[i] >= target)
            {
                return i;
            }
        }
        return 0;
    }
}
