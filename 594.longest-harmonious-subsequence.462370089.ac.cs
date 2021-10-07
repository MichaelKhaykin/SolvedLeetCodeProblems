public class Solution {
    public int FindLHS(int[] nums) {
        
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
            {
                map.Add(nums[i], 1);
            }
        }
        
        int max = 0;
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(map.ContainsKey(nums[i] + 1))
            {
                max = Math.Max(max, map[nums[i]] + map[nums[i] + 1]);
            }
        }
        
        return max;
    }
}
