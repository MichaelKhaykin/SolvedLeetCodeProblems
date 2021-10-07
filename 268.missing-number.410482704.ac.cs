public class Solution {
    public int MissingNumber(int[] nums) {
        
        int n = nums.Length;
        HashSet<int> b = new HashSet<int>();
        for(int i = 0; i < n; i++)
        {
            b.Add(nums[i]);
        }
        
        for(int i = 0; i <= n; i++)
        {
            if(b.Add(i)) return i;
        }
        
        return 0;
    }
}
