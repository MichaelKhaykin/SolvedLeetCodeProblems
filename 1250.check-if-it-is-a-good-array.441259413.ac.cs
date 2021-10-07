public class Solution {
    
    public int EuclidsGCD(int a, int b)
    {
        if(a % b == 0)
        {
            return b;
        }
        return EuclidsGCD(b, a % b);
    }
    
    public bool IsGoodArray(int[] nums) {
        
        int a = nums[0];
        
        for(int i = 1; i < nums.Length && a != 1; i++)
        {
            a = EuclidsGCD(a, nums[i]);
        }
        return a == 1;
    }
}
