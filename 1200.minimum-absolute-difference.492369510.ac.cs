public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        
        Array.Sort(arr);
        
        int minAbsolouteDiff = int.MaxValue;
        for(int i = 0; i < arr.Length - 1; i++)
        {
            var diff = arr[i] - arr[i + 1];
            var absDiff = Math.Abs(diff);
            minAbsolouteDiff = Math.Min(minAbsolouteDiff, absDiff);
        }
        
        List<IList<int>> lists = new List<IList<int>>();
        
        for(int i = 0; i < arr.Length - 1; i++)
        {
            if(Math.Abs(arr[i] - arr[i+1]) == minAbsolouteDiff){
                lists.Add(new List<int>() { arr[i], arr[i + 1] });
            }    
        }
        
        return lists;
    }
}
