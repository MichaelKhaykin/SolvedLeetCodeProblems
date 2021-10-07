public class Solution {
    public int FindPairs(int[] nums, int k) {
        
        Dictionary<int, int> dups = new Dictionary<int, int>();
        
        int ans = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(!dups.ContainsKey(nums[i]))
            {
                dups.Add(nums[i], 1);
            }
            else
            {
                dups[nums[i]]++;
            }
        }
        
        foreach(var item in dups.Keys)
        {
            if((dups.ContainsKey(item + k) && k != 0) || (dups[item] > 1 && k == 0)) 
            {
                ans++;
            }
        }
        
        return ans;
    }
}
