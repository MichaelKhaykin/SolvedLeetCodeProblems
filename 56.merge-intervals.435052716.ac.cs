public class Solution {
    public int[][] Merge(int[][] intervals) {
        
        List<(int s, int e)> x = new List<(int, int)>();
        for(int i = 0; i < intervals.Length; i++)
        {
            x.Add((intervals[i][0], intervals[i][1]));
        }
        
        x = x.OrderBy((t) => t.s).ToList();
        
        for(int i = 0; i < x.Count; i++)
        {
            if(i + 1 < x.Count && x[i].e >= x[i + 1].s)
            {
                x.Insert(i, (x[i].s, Math.Max(x[i + 1].e, x[i].e)));
                
                x.RemoveAt(i + 1);
                x.RemoveAt(i + 1);
                
                i -= 1;
             }
        }
        
        return x.Select((t) => new int[] { t.s, t.e }).ToArray();
    }
}
