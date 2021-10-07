public class Solution
{

public string LargestNumber(int[] cost, int target) {
        Dictionary<int, int> lookup = new Dictionary<int, int>();
        
        for(int i=0; i< cost.Length; i++)
        {
            if (!lookup.ContainsKey(cost[i]) || lookup[cost[i]] < i+1)
            { 
               lookup[cost[i]] = i+1;
            }
        }
        
        List<int> costKeys =  lookup.OrderByDescending(x=>x.Value).Select(x=>x.Key).ToList();
        
        Dictionary<int, string> memory = new  Dictionary<int, string>();
        memory[0] = string.Empty;
                
        BuildNumber(costKeys, lookup, target, memory);
        
        return (memory.ContainsKey(target) && memory[target] != null)? memory[target]: "0"; 
    }
    
    private bool BuildNumber(List<int> costKeys, Dictionary<int, int> lookup, int target, Dictionary<int, string> memory)
    {
        if (target < 0) { return false; }
        if (target == 0) { return true; }         
        if (memory.ContainsKey(target)) { return memory[target] != null;}
        
        int cost;
        StringBuilder st = new StringBuilder();
        bool reply = false;
        
        for(int i=0; i < costKeys.Count; i++)
        {
            cost = costKeys[i];
            if (target < cost) { continue; }
            
            if (BuildNumber(costKeys, lookup, target - cost, memory))
            {
                reply = true;
                
                st.Append(lookup[cost]); 
                st.Append(memory[target-cost]);
                
                if (!memory.ContainsKey(target) || memory[target].Length < st.Length) { memory[target] = st.ToString(); }  
                
                 st.Length = 0;
            }
        }
        
        if (reply == false) { memory[target] = null; }
        return reply;
    }
}
