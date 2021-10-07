public class SummaryRanges {

    SortedList<int, (int, int)> intervals = new SortedList<int, (int, int)>();
    
    /** Initialize your data structure here. */
    public SummaryRanges() {
        
    }
    
    private List<int[]> Merge()
    {
        List<int[]> result = new List<int[]>();
        SortedList<int, (int, int)> newIntervals = new SortedList<int, (int, int)>();
        
        int i = 0;
        int j = 1;
        
        while(i < intervals.Count)
        {
            int from = intervals.Values[i].Item1;
            int to = intervals.Values[i].Item2;
            
            while(j < intervals.Count && intervals.Values[j].Item1 <= to + 1)
            {
                to = Math.Max(to, intervals.Values[j].Item2);
                j++;
            }
            
            result.Add(new int[] { from, to });
            newIntervals.Add(from, (from, to));
            
            i = j;
            j += 1;
        }
        
        
        intervals = newIntervals;
        return result;
    }
    
    public void AddNum(int val) {
        if(intervals.ContainsKey(val)) return;
        intervals.Add(val, (val, val));
    }
    
    public int[][] GetIntervals() {
        var result = Merge();
        return result.ToArray();
    }
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(val);
 * int[][] param_2 = obj.GetIntervals();
 */
