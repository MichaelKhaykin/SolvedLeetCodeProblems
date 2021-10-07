public class Solution {
    
    public int FindLucky(int[] arr)
    {
        var sequence = arr.GroupBy(x => x).Where(x => x.Key == x.Count());
        if (sequence.Count() == 0) return -1;
        return sequence.Max(x => x.Key);
    }
}
