public class Solution {
    public string LargestNumber(int[] nums) 
    {    
        bool allZereos = true;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] != 0) 
            {
                allZereos = false;
            }
        }
        
        if(allZereos) return "0";
        
        Comparison<string> comparer = new Comparison<string>((x, y) =>
        {
            if (long.Parse(x + y) > long.Parse(y + x)) return -1;
            else if (long.Parse(x + y) == long.Parse(y + x)) return 0;
            return 1;
        });

        var list = nums.Select((x) => x.ToString()).ToList();
        list.Sort(comparer);

        string append = "";
        for(int i = 0; i < list.Count; i++)
        {
            append += list[i];
        }

        return append;
    }
}
