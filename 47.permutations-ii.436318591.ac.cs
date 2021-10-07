public class Solution {
    
    List<IList<int>> all = new List<IList<int>>();
    
    public void BackTrack(List<int> currentBuild, Dictionary<int, int> count, int N)
    {
        if(currentBuild.Count == N)
        {
            all.Add(new List<int>(currentBuild));
            return;
        }
        
        Dictionary<int, int> copy = new Dictionary<int, int>(count);
        foreach(var kvp in count)
        {
            if(copy[kvp.Key] == 0) continue;
        
            copy[kvp.Key]--;
            currentBuild.Add(kvp.Key);
            
            BackTrack(currentBuild, copy, N);
        
            currentBuild.RemoveAt(currentBuild.Count - 1);
            copy[kvp.Key]++;
        }
    }
    
    public IList<IList<int>> PermuteUnique(int[] nums) {
        
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach(var num in nums)
        {
            if(count.ContainsKey(num) == false)
            {
                count.Add(num, 0);
            }
            count[num]++;
        }
        
        
        BackTrack(new List<int>(), count, nums.Length);
        
        return all;
    }
}
