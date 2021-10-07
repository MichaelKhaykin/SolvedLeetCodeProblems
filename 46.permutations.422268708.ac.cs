public class Solution {
    
    List<IList<int>> idiot = new List<IList<int>>();
    
    void Go(int[] nums, HashSet<int> curr)
    {
        if(curr.Count == nums.Length)
        {
            idiot.Add(curr.ToList());
            return;
        }
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(curr.Contains(nums[i])) continue;
            
            curr.Add(nums[i]);
            Go(nums, curr);
            curr.Remove(nums[i]);
        }
    }
    
    public IList<IList<int>> Permute(int[] nums) {
        Go(nums, new HashSet<int>());
        
        return idiot;
    }
}
