public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int[] grabFrom = new int[m];
        for(int i = 0; i < m; i++)
        {
            grabFrom[i] = nums1[i];
        }
        
        int lIndex = 0;
        int rIndex = 0;
        for(int i = 0; i < nums1.Length; i++)
        {
            if(lIndex >= grabFrom.Length)
            {
                nums1[i] = nums2[rIndex];
                rIndex++;
                continue;
            }
            if(rIndex >= nums2.Length)
            {
                nums1[i] = grabFrom[lIndex];
                lIndex++;
                continue;
            }
            
            if(grabFrom[lIndex] < nums2[rIndex])
            {
                nums1[i] = grabFrom[lIndex];
                lIndex++;
            }
            else
            {
                nums1[i] = nums2[rIndex];
                rIndex++;
            }
        }
    }
}
