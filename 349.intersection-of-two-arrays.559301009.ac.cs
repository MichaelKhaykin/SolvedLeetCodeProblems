public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        
        HashSet<int> hash1 = new HashSet<int>(nums1);
        HashSet<int> hash2 = new HashSet<int>(nums2);
        
        List<int> res = new List<int>();
        
        foreach(var num in hash1)
        {
            if(hash2.Contains(num))
            {
                res.Add(num);
            }
        }
        
        return res.ToArray();
        
    }
}
