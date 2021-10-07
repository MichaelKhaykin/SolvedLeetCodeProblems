public class Solution {
   
    public int TotalHammingDistance(int[] nums) {
        
        int[,] c = new int[32, 2];
        foreach(var num in nums)
        {
            for(int i = 0; i < 32; i++)
            {
                int bit = (num & (1 << i)) >> i;
                c[i, bit]++;
            }
        }
        
        int ans = 0;
        foreach(var num in nums)
        {
            for(int i = 0; i < 32; i++)
            {
                int bit = (num & (1 << i)) >> i;
                int rev = bit == 0 ? 1 : 0;
                
                ans += c[i, rev];
                
                c[i, bit]--;
            }
        }
        
        return ans;
    }
}
