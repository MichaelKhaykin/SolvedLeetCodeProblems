public class Solution {
    
    
    public IList<IList<int>> Subsets(int[] nums) {
     
        List<IList<int>> val = new List<IList<int>>();
        val.Add(new List<int>() { });
        
        for(int i = 0; i < nums.Length; i++)
        {
            List<List<int>> p = new List<List<int>>();
            for(int x = 0; x < val.Count; x++)
            {
                List<int> newList = new List<int>(val[x]);
                newList.Add(nums[i]);
                
                p.Add(newList);
            }
            
            val.AddRange(p);
        }
        
        return val;
    }
}
