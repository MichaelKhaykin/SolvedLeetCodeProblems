public class Solution {
    
    public int[][] Merge(List<(int s, int e)> x)
    {
        for (int i = 0; i < x.Count; i++)
        {
            if (i + 1 < x.Count && x[i].e >= x[i + 1].s)
            {
                x.Insert(i, (x[i].s, Math.Max(x[i + 1].e, x[i].e)));

                x.RemoveAt(i + 1);
                x.RemoveAt(i + 1);

                i -= 1;
            }
        }

        return x.Select((t) => new int[] { t.s, t.e }).ToArray();
    }
    
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        
        List<(int s, int e)> x = new List<(int, int)>();
        bool insert = false;
        for(int i = 0; i < intervals.Length; i++)
        {
            if(newInterval[0] < intervals[i][0] && !insert)
            {
                x.Add((newInterval[0], newInterval[1]));
                insert = true;
            }
            x.Add((intervals[i][0], intervals[i][1]));
        }
        
        if(!insert)
        {
            x.Add((newInterval[0], newInterval[1]));
        }
        
        return Merge(x);
    }
}
