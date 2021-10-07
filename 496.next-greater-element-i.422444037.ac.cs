public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        
        Dictionary<int, int> lookup = new Dictionary<int, int>();
        for(int i = 0; i < nums2.Length; i++)
        {
            lookup.Add(nums2[i], i);
        }
        
        int[] newArr = new int[nums1.Length];
        
        Array.Fill(newArr, -1);
        
        for(int i = 0; i < nums1.Length; i++)
        {
            var other = lookup[nums1[i]] + 1;
            
            for(int x = other; x < nums2.Length; x++)
            {
                if(nums2[x] > nums1[i])
                {
                    newArr[i] = nums2[x];
                    break;
                }
            }
        }
        
        return newArr;
    }
}
