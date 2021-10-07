public class Solution {
    
    public int MinJumps(int[] arr)
    {
        Dictionary<int, List<int>> sames = new Dictionary<int, List<int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (sames.ContainsKey(arr[i]))
            {
                sames[arr[i]].Add(i);
            }
            else
            {
                sames.Add(arr[i], new List<int>() { i });
            }
        }

        
        HashSet<int> visited = new HashSet<int>();
        List<int> current = new List<int>();
        current.Add(0);
       
        int step = 0;
        
        while(current.Count > 0)
        {
            List<int> next = new List<int>();
            
            for(int i = 0; i < current.Count; i++)
            {
                if(current[i] == arr.Length - 1) return step;
                
                var list = sames[arr[current[i]]];
                for(int x = 0; x < list.Count; x++)
                {
                    if(!visited.Contains(list[x]))
                    {
                        visited.Add(list[x]);
                        next.Add(list[x]);
                    }
                }
                
                sames[arr[current[i]]].Clear();
                
                if(current[i] + 1 < arr.Length && !visited.Contains(current[i] + 1))
                {
                    visited.Add(current[i] + 1);
                    next.Add(current[i] + 1);
                }
                if(current[i] - 1 >= 0 && !visited.Contains(current[i] - 1))
                {
                    visited.Add(current[i] - 1);
                    next.Add(current[i] - 1);
                }
            }
            
            current = next;
            step++;
        }
        
        return -1;
    }
}
