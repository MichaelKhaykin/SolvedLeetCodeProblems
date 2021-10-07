public class Solution {

    int global = int.MaxValue;
    
    public void MinOperations(int[] freqCount, int iter)
    {
        Dictionary<int, int> maps = new Dictionary<int, int>();
        HashSet<int> tryOuts = new HashSet<int>();
        
        for(int i = 0; i < freqCount.Length; i++)
        {
            if(freqCount[i] == 0) continue;
            
            if(maps.ContainsKey(freqCount[i]))
            {
                //intersection 
                tryOuts.Add(i);
                
                break;
                
                maps[freqCount[i]] = i;
                
                continue;
            }
            
            maps.Add(freqCount[i], i);
        }
        
        if(tryOuts.Count == 0)
        {
            global = Math.Min(global, iter);
            return;
        }
        
        foreach(var tryOut in tryOuts)
        {
            freqCount[tryOut]--;
            
            MinOperations(freqCount, iter + 1);
           
            freqCount[tryOut]++;
        }
    }
    
    public int MinDeletions(string s) {
        
        int[] freqCount = new int[26];
        for(int i = 0; i < s.Length; i++)
        {
            freqCount[s[i] - 'a']++;
        }
        
        global = int.MaxValue;
        MinOperations(freqCount, 0);
        
        return global;
        
    }
}
