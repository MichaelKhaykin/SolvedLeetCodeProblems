public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
    
        Dictionary<int, int> vals = new Dictionary<int, int>();
        
        for(int i = 0; i < tops.Length; i++)
        {
            if(!vals.ContainsKey(tops[i]))
            {
                vals.Add(tops[i], 0);
            }
            vals[tops[i]]++;
            
            if(!vals.ContainsKey(bottoms[i]))
            {
                vals.Add(bottoms[i], 0);
            }
            vals[bottoms[i]]++;
        }
        
        int minOperations = int.MaxValue;
        foreach (var kvp in vals)
        {                
            int amtTop = 0;
            int amtBot = 0;
            int overlap = 0;

            for (int i = 0; i < tops.Length; i++)
            {
                if(tops[i] == kvp.Key)
                {
                    amtTop++;
                }
                if(bottoms[i] == kvp.Key)
                {
                    amtBot++;
                }

                if(tops[i] == bottoms[i] && tops[i] == kvp.Key)
                {
                    overlap++;
                }
            }

            if (amtBot + amtTop - overlap < tops.Length) continue;

            var len = tops.Length - amtTop;
            var len2 = tops.Length - amtBot;

            minOperations = Math.Min(Math.Min(len, len2), minOperations);
        }

        
        return minOperations == int.MaxValue ? -1 : minOperations;
    }
}
