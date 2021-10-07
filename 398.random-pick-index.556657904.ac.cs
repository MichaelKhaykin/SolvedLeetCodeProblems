public class Solution {

    Dictionary<int, List<int>> r = new Dictionary<int, List<int>>();
    int[] nums;
    Random random;
    
    public Solution(int[] nums) {
        random = new Random();
        this.nums = nums;
        for(int i = 0; i < nums.Length; i++)
        {
            if(r.ContainsKey(nums[i]))
            {
                r[nums[i]].Add(i);
            }
            else
            {
                r.Add(nums[i], new List<int>() { i });
            }
        }
        
    }
    
    public int Pick(int target) {
        
        var list = r[target];
        return list[random.Next(0, list.Count)];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */
