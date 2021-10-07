public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] newNums = new int[nums1.Length + nums2.Length];
        int lI = 0;
        int rI = 0;
        for(int i = 0; i < newNums.Length; i++)
        {
            if(lI >= nums1.Length)
            {
                newNums[i] = nums2[rI];
                rI++;
                continue;
            }
            if(rI >= nums2.Length)
            {
                newNums[i] = nums1[lI];
                lI++;
                continue;
            }
            
            if(nums1[lI] <= nums2[rI])
            {
                newNums[i] = nums1[lI];
                lI++;
            }
            else
            {
                newNums[i] = nums2[rI];
                rI++;
            }
        }
        
        bool shouldAverage = newNums.Length % 2 == 0;
        int half = newNums.Length / 2;
        if(shouldAverage)
        {
            return (newNums[half] + newNums[half - 1])/2.0;
        }
        return newNums[half];
    }
}
