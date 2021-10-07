public class Solution {
    
    public int EraseOverlapIntervals(int[][] intervals) {
        
        if(intervals.Length <= 1) return 0;
        
        List<(int, int)> interv = new List<(int, int)>();
        for(int i = 0; i < intervals.Length; i++)
        {
            interv.Add((intervals[i][0], intervals[i][1]));
        }
        
        interv = interv.OrderBy((tuple) => tuple.Item1).ToList();
        
        int left = 0;
        int right = 1;
        int removal = 0;
        
        while(right < interv.Count)
        {
            var leftitem = interv[left];
            var rightitem = interv[right];
            
            if(leftitem.Item2 <= rightitem.Item1)
            {
                left = right;
                right++;
            }
            else if(leftitem.Item2 <= rightitem.Item2)
            {
                removal++;
                right++;
            }
            else if(leftitem.Item2 > rightitem.Item2)
            {
                removal++;
                left = right;
                right++;
            }
        }
        
        return removal;
    }
}
