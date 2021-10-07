public class MajorityChecker {

    Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
    public MajorityChecker(int[] arr) { 
        for(int i = 0; i < arr.Length; i++)
        {
            if(!map.ContainsKey(arr[i]))
            {
                map.Add(arr[i], new List<int>());
            }
            map[arr[i]].Add(i);
        }
    }
    
    public int Query(int left, int right, int threshold) {
        foreach(var item in map)
        {
            if(item.Value.Count >= threshold)
            {
                var start = item.Value.BinarySearch(left);
                var end = item.Value.BinarySearch(right);
                
                if(start < 0) start = ~start;
                if(end < 0) end = ~end - 1;
                
                if(end - start + 1 >= threshold)
                {
                    return item.Key;
                }
            }
        }
        return -1;
    }
}

/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.Query(left,right,threshold);
 */
